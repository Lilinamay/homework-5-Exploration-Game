using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanBehavior : MonoBehaviour
{
    //int hit = 0;
    public playerShoot pShoot;
    public enemyBehavior enemyHealth;   //change enemyhealth
    //public playerShoot pBullets;
    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //pShoot.hit++;           //count hits
            Destroy(gameObject);    //destroy bullet
            /*if (pShoot.hit >= 3)    //hit>3 kill enemy
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }*/
            collision.gameObject.GetComponent<enemyBehavior>().enemyHealth--;
            Debug.Log(collision.gameObject.GetComponent<enemyBehavior>().enemyHealth);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
