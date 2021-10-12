using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanBehavior : MonoBehaviour
{
    public playerShoot pShoot;
    public enemyBehavior enemyHealth;   //change enemyhealth

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
            if (collision.gameObject.name == "megaEnemy")
            {
                Destroy(gameObject);    //destroy bullet
                Debug.Log("that's not going to work");
            }
            else
            {
                Destroy(gameObject);    //destroy bullet
                collision.gameObject.GetComponent<enemyBehavior>().enemyHealth--;
                Debug.Log(collision.gameObject.GetComponent<enemyBehavior>().enemyHealth);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
