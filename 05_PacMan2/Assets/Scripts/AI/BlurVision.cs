using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
public class BlurVision : MonoBehaviour
{
    [SerializeField]
    private float _blurDuration = 5.0f;
    
    [SerializeField]
    private Color _blurColor = new Color(0, 0, 0, 0.5f);
    private GameObject _blurVision;

    private void Awake()
    {
        _blurVision = GameObject.Find("BlurVision");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (other.GetType() == typeof(BoxCollider)))
        {
            FadeOut fadeOut = _blurVision.GetComponent<FadeOut>();
            fadeOut.FadeOutObject(_blurColor, _blurDuration);

            Destroy(gameObject);
        }
    }
}
