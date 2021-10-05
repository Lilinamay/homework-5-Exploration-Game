using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
    SpriteRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {

        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        death();
        playerRestart();

    }

    public void death()
    {
        if (gameObject.GetComponent<playerInteract>().dead == true)
        {
            //Destroy(gameObject);
            myRenderer.enabled = false;     //invisible to the player AKA dead without losing the camera
            gameObject.GetComponent<playerMove>().speed = 0;
            gameObject.GetComponent<playerMove>().jumpHeight = 0;
            //gameObject.GetComponent<SpriteRenderer>.
            //StopCoroutine(gameObject.GetComponent<CamBehavior>());
        }
    }

    void playerRestart()
    {
        if (gameObject.GetComponent<playerInteract>().dead == true)
        {
            if (Input.GetKey(KeyCode.P))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
