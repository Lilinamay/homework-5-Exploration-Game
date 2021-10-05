using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    public GameObject ball;
    public float shootSpeed;
    public int hit;
    public int bulletCount;
    // Start is called before the first frame update
    void Start()
    {
        bulletCount = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<playerInteract>().dead == false)        //player alive and have positions
        {
            if (Input.GetKeyDown(KeyCode.K) && bulletCount >= 1) //key press only once and have bullets
            {
                GameObject newBall = Instantiate(ball, transform.position, transform.rotation); //default to player's position/rotation
                newBall.transform.SetParent(gameObject.transform);
                bulletCount--;
                float dir = 0f;
                if (playerMove.faceRight)
                {
                    dir = 1f;
                }
                else
                {
                    newBall.GetComponent<SpriteRenderer>().flipX = true;    //flip ball 
                    dir = -1f;      //opposite direction

                }
                newBall.transform.localPosition = new Vector3(dir * 1f, -0.1f); ///local position relative to player
                newBall.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x + dir * shootSpeed, 0f);  //ball move
                newBall.GetComponent<beanBehavior>().pShoot = this;     //store and count hits
            }
            else if (Input.GetKeyDown(KeyCode.K) && bulletCount < 1)
            {
                Debug.Log("out of bullets");
            }
        }
    }
}
