using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    SpriteRenderer myRenderer;
    float timer;
    public bool respawn = false;
    // Start is called before the first frame update
    void Start()
    {

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        death();
        //playerRestart();

    }

    public void death()
    {
        if (gameObject.GetComponent<playerInteract>().dead == true)
        {
            //Destroy(gameObject);
            myRenderer.enabled = false;     //invisible to the player AKA dead without losing the camera
            gameObject.GetComponent<playerMove>().speed = 0;
            gameObject.GetComponent<playerMove>().jumpHeight = 0;
            timer += Time.deltaTime;
            if (timer > 1)
            {
                myRenderer.enabled = true;
                respawn = true;
                gameObject.GetComponent<playerMove>().speed = 7;
                gameObject.GetComponent<playerMove>().jumpHeight = gameObject.GetComponent<playerMove>().jumpheightInput;
                gameObject.GetComponent<playerInteract>().dead = false;
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }
    }

    /*void playerRestart()
    {
        if (gameObject.GetComponent<playerInteract>().dead == true)
        {
            if (Input.GetKey(KeyCode.P))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }*/
}
