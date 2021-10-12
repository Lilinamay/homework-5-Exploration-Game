using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBehavior : MonoBehaviour
{
    
    public enemyBehavior enemyHealth;   //change enemyhealth
    private bool shotComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 1f); //selfDestroy after amount of time
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Destroy(gameObject);    //destroy bullet
            if (shotComplete == false)
            {
                collision.gameObject.GetComponent<enemyBehavior>().enemyHealth = collision.gameObject.GetComponent<enemyBehavior>().enemyHealth - 3;
                //shotComplete = true;
                Debug.Log(collision.gameObject.GetComponent<enemyBehavior>().enemyHealth);
            }
        }
    }
}

