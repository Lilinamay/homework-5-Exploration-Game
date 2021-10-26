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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stars")
        {
            //Destroy(collision.gameObject);
            audioManager.Instance.PlaySound(audioManager.Instance.starSound, audioManager.Instance.starVolume);
            collision.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(flower, transform.position);
            gameObject.GetComponent<checkManager>().itemList.Add(collision.gameObject);
            Debug.Log("star");
            starCount++;
        }

        if (collision.gameObject.tag == "bullet")
        {
            audioManager.Instance.PlaySound(audioManager.Instance.bulletSound, audioManager.Instance.bulletVolume);
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            //AudioSource.PlayClipAtPoint(flower, transform.position);
            gameObject.GetComponent<checkManager>().itemList.Add(collision.gameObject);
            Debug.Log("bullet");
            gameObject.GetComponent<playerShoot>().bulletCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

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
            audioManager.Instance.PlaySound(audioManager.Instance.starSound, audioManager.Instance.starVolume);
            Destroy(collision.gameObject);
        }

        
    }

    void displayNum()
    {
        bulletText.text = (gameObject.GetComponent<playerShoot>().bulletCount+"");
        sparkleText.text = (starCount + " /12 sparkles");
    }

    void sparkleActivate()
    {
        if (starCount >= 10)
        {
            sparkleAchieved = true;
        }
        else
        {
            sparkleAchieved = false;
        }
    }


}
