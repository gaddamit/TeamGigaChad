using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public float timealive;
    public bool bigfire;
    bool Spread;
    bool Spread2;

    int hits;
    public PlaneScript PlaneSC;
    public GameObject Fire;

    // Start is called before the first frame update
    void Start()
    {
        Spread = true;
        Spread2 = true;
        timealive = 0;
        var PlaneOB = GameObject.Find("Plane");
        var PlaneSC = PlaneOB.GetComponent<PlaneScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timealive = timealive + Time.deltaTime;
       if (bigfire && timealive > 10&&Spread)
        {
            Instantiate(Fire, new Vector2(transform.position.x + 0.5f , transform.position.y), Quaternion.identity);
            Spread = false;
        }
        if (bigfire && timealive > 15 && Spread2)
        {
            Instantiate(Fire, new Vector2(transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
            Spread2 = false;
        }
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
                if (hits > 8)
                {
                    PlaneSC.score = PlaneSC.score + 10 - (int)timealive;

                    Destroy(gameObject);
                }
            }
        }
    }
   
}
