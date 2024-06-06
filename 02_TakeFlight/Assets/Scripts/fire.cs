using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float timealive;
    public bool bigfire;
    int hits;
    public PlaneScript PlaneSC;
    // Start is called before the first frame update
    void Start()
    {
        
        timealive = 0;
        var PlaneOB = GameObject.Find("Plane");
        var PlaneSC = PlaneOB.GetComponent<PlaneScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timealive = timealive + Time.deltaTime;

       if (bigfire)
        {
            this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f) * ((timealive + 10) * 0.07f);

        }
       else
        {
            this.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f) * ((timealive + 10) * 0.07f);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asd");
        if (collision.tag == "Projectile")
        {
            

            Destroy(collision.gameObject);
            if (bigfire)
            {

                hits++;
                if (hits > 14)
                {
                    PlaneSC.score = PlaneSC.score + 20 - (int)timealive;

                    Destroy(gameObject);

                }
            }
            else
            {
                hits++;
                if (hits > 5)
                PlaneSC.score = PlaneSC.score + 10 - (int)timealive;

                Destroy(gameObject);
            }
        }
    }
   
}
