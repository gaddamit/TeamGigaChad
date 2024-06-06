using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _waterJet;
    // Start is called before the first frame update
    void Start()
    {
        _waterJet.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.DORotateQuaternion(Quaternion.LookRotation(Vector3.forward, mousePosition - (Vector2)transform.position), 0.5f);
            transform.DOMove(mousePosition, 2.0f).SetEase(Ease.Linear);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if(!_waterJet.isPlaying)
            {
                _waterJet.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _waterJet.Stop();
        }
    }
}
