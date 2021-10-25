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
    //GameObject[] itemList;
    //GameObject items;
    public List<GameObject> itemList;
    GameObject collObject;
    // Start is called before the first frame update
    void Start()
    {
        SaveBullet = FindObjectOfType<playerShoot>().bulletCount;
        SaveSparkle = 0;
        SaveX = transform.position.x;
        SaveY = transform.position.y;

        itemList = new List<GameObject>();
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
                itemList.Clear();

            }
        }

 
        if (GetComponent<restart>().respawn == true)
        {
             transform.position = new Vector3(SaveX+2, SaveY);
             FindObjectOfType<playerInteract>().starCount = SaveSparkle;
             FindObjectOfType<playerShoot>().bulletCount = SaveBullet;
             foreach(GameObject item in itemList)
            {
                item.SetActive(true);
                if(item.tag == "enemy")
                {
                    item.GetComponent<enemyBehavior>().added = false;
                    item.GetComponent<enemyBehavior>().enemyHealth = 3;
                    if(item.name == "movingEnemy")
                    {
                        item.GetComponent<enemyBehavior>().enemyHealth = 1;
                    }
                }
            }
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
