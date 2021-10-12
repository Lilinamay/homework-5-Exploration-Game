using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyActivate : MonoBehaviour
{
    public bool upgrade = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (FindObjectOfType<playerInteract>().sparkleAchieved == true)
        {
            Debug.Log("activate lily 2");
            gameObject.SetActive(true);
        }*/

        if ((gameObject.GetComponent<dialogueTrigger>().dialogueComplete == true)
            &&(upgrade == false))
        {
            Debug.Log("upgrade weapon, jump");
            upgrade = true;
        }
    }
}
