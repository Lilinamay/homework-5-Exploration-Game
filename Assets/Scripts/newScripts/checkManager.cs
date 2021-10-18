using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkManager : MonoBehaviour
{
    float SaveX;
    float SaveY;
    int SaveSparkle;
    int SaveBullet;
    bool check = false;
    
    GameObject collObject;
    // Start is called before the first frame update
    void Start()
    {
        SaveBullet = FindObjectOfType<playerShoot>().bulletCount;
        SaveSparkle = 0;
        SaveX = transform.position.x;
        SaveY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            if(collObject.GetComponent<dialogueTrigger>().ConvEnter == true)
            {
                SaveX = transform.position.x;
                SaveY = transform.position.y;
                SaveSparkle = FindObjectOfType<playerInteract>().starCount;
                SaveBullet = FindObjectOfType<playerShoot>().bulletCount;
                Debug.Log("progress saved");
                check = false;
            }
        }

 
        if (GetComponent<restart>().respawn == true)
        {
             transform.position = new Vector3(SaveX+2, SaveY);
             FindObjectOfType<playerInteract>().starCount = SaveSparkle;
             FindObjectOfType<playerShoot>().bulletCount = SaveBullet;
             GetComponent<restart>().respawn =false;

         }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkPoint" )
        {
            Debug.Log("checkpoint");
            check = true;
            collObject = collision.gameObject;
        }
    }
}
