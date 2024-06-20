using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParameter(string parameter, bool value)
    {
        //This is where we would set the parameter in the animator
        animator.SetBool(parameter, value);
    }

    public void SetParameter(string parameter, float value)
    {
        //This is where we would set the parameter in the animator
        animator.SetFloat(parameter, value);
    }
}
