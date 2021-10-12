using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerInteract : MonoBehaviour
{
    Rigidbody2D myBody;
    
    AudioSource myAudio;
    public int starCount = 0;
    public bool dead = false;
    public bool key = false;
    public bool sparkleAchieved = false;
    //public int enemyHealth; 
    public playerShoot bulletCount;     //change bulletCount

    public TMP_Text bulletText;
    public TMP_Text sparkleText;


    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        
        //myAudio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        displayNum();
        sparkleActivate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "stars")
        {
            Destroy(collision.gameObject);
            //AudioSource.PlayClipAtPoint(flower, transform.position);
            Debug.Log("star");
            starCount++;
        }

        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            //AudioSource.PlayClipAtPoint(flower, transform.position);
            Debug.Log("bullet");
            gameObject.GetComponent<playerShoot>().bulletCount ++;
        }

        if (collision.gameObject.tag == "enemy")
        { 
            dead = true;
            //AudioSource.PlayClipAtPoint(enemy, transform.position);
            Debug.Log("enemy");
            //deadText.text = ("Press P to Restart");
        }

        if (collision.gameObject.name == "door")
        {
            if (key == true)
            {
                Destroy(collision.gameObject);
            } 
        }

        if (collision.gameObject.name == "key")
        {
            key = true;
            Destroy(collision.gameObject);
        }

        
    }

    void displayNum()
    {
        bulletText.text = (gameObject.GetComponent<playerShoot>().bulletCount + " bullets");
        sparkleText.text = (starCount + " /12 sparkles");
    }

    void sparkleActivate()
    {
        if (starCount >= 2)
        {
            sparkleAchieved = true;
        }
    }


}
