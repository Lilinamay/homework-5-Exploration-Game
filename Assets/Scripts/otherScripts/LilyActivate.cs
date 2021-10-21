using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyActivate : MonoBehaviour
{
    public bool upgrade = false;
    [SerializeField] GameObject Lily1;
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
        if (FindObjectOfType<playerInteract>().sparkleAchieved == false)
        {
            Debug.Log("Destroy lily 1 and respawn lily 2");
            Lily1.SetActive(true);
            gameObject.SetActive(false);
        }

        if ((gameObject.GetComponent<dialogueTrigger>().dialogueComplete == true)
            &&(upgrade == false))
        {
            Debug.Log("upgrade weapon, jump");
            upgrade = true;
        }
    }
}
