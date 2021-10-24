using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyActivate : MonoBehaviour
{
    public bool lightUpgrade = false;
    [SerializeField] GameObject Bunny1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.GetComponent<dialogueTrigger>().dialogueComplete == true)
            && (lightUpgrade == false))
        {
            Debug.Log("upgrade weapon, jump");
            lightUpgrade = true;
        }
    }
}
