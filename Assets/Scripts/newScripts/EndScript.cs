using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<dialogueTrigger>().dialogueComplete)
        {
            player.GetComponent<playerMove>().speed = 0;    //freeze player 
            player.GetComponent<playerMove>().jumpHeight = 0;
            player.GetComponent<SpriteRenderer>().flipX = true;
            player.GetComponent<playerMove>().canFlip = false;
            if (!hand.GetComponent<handScript>().collide)
            {
                hand.GetComponent<handScript>().speed = 5;
            }
        }
    }


}
