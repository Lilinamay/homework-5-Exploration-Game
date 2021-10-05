using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public int enemyHealth;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HealthManage();
    }

    void HealthManage()
    {
        if (enemyHealth <= 0)
        {
            Debug.Log("i am dead");
            Destroy(gameObject);
        }
    }
}
