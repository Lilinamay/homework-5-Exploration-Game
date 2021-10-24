using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyDestroy : MonoBehaviour
{
    [SerializeField] GameObject Bunny2;
    [SerializeField] GameObject Flora;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Flora.GetComponent<dialogueTrigger>().dialogueComplete == true)
        {
            Debug.Log("Destroy bunny 1 and respawn bunny 2");
            Bunny2.SetActive(true);
            gameObject.SetActive(false);
        }
        /*else
        {
            gameObject.SetActive(true);
            Bunny2.SetActive(false);
        }*/
        
    }
}

