
    using UnityEngine;
    using Dreamteck.Forever;
using UnityEngine.Events;
using Unity.VisualScripting;
public class Player : MonoBehaviour
    {
        LaneRunner runner;
        float boost = 0f;
        public static Player instance;
        bool canBoost = true;
        float speed = 0f;
        float startSpeed = 0f;
        public Color regularColor;
        public Color boostColor;
        Material material;
        private Rigidbody rb;
        private bool isJumping = false;
        [SerializeField]
        private float _speedCap = 50;
        [SerializeField]
        private float _speedIncrement = 0.5f;
        private bool isDead = false;
        private Animator _animator;
        
        public UnityEvent onDeath;
        public UnityEvent onCleanup;
        private void Awake()
        {
            runner = GetComponent<LaneRunner>();
            startSpeed = speed = runner.followSpeed;
            instance = this;
            //material = GetComponent<MeshRenderer>().sharedMaterial;
            rb = GetComponent<Rigidbody>();
            
            _animator = GetComponent<Animator>();
        }

        void OnRestart()
        {
            LevelGenerator.instance.Restart();
            runner.followSpeed = speed = startSpeed;
            boost = 0f;
            canBoost = true;
        }

        void OnAnswer()
        {
            canBoost = true;
            boost = 0f;
        }

        private void Update()
        {
            if(isDead)
            {
                return;
            }
            
            if (boost == 0f)
            {
                //Lane switching logic
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) runner.lane--;
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) runner.lane++;
                //Capture Boost Input
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    boost = 1f;
                    canBoost = false;
                    isJumping = true;
                }
            }
            //Boosting logic
            if (boost > 0f) runner.followSpeed = speed + boost * speed * 2f;
            else runner.followSpeed = speed;
            Color col = Color.Lerp(regularColor, boostColor, boost);
            //material.SetColor("_Color", col);
            //material.SetColor("_EmissionColor", col);
            boost = Mathf.MoveTowards(boost, 0f, Time.deltaTime * speed * 0.075f);
        }

        private void FixedUpdate()
        {
            if (isJumping)
            {
                rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                isJumping = false;
            }
        }

        public void SetSpeed(float speed)
        {
            this.speed = speed;
            runner.followSpeed = speed;
            //if(speed == 0f) EndScreen.Open();
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void IncreaseSpeed()
        {
            if(speed < _speedCap)
            {
                SetSpeed(speed + _speedIncrement);
            }
        }

        public void OnDeath()
        {
            if(isDead)
            {
                return;
            }

            isDead = true;
            _animator.SetTrigger("Death");
            SetSpeed(0f);
            
            onDeath?.Invoke();
            Invoke("CleanUp", 3.0f);
        }

        public void CleanUp()
        {
            onCleanup?.Invoke();
        }
    }