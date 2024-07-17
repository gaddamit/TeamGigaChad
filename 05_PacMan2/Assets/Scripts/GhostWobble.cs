using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostWobble : MonoBehaviour
{
	public GameObject Ghost1;
	public GameObject Ghost2;
	public GameObject Ghost3;
	public GameObject Ghost4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ghost1.transform.Translate(1,1,1);
    }
}
