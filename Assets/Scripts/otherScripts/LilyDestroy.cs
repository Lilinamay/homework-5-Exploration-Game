using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyDestroy : MonoBehaviour
{
    public GameObject Lily2;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Lily2 = GameObject.Find("LilyReturn");
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<playerInteract>().sparkleAchieved == true)
        {
            Debug.Log("Destroy lily 1 and respawn lily 2");
            Lily2.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            Lily2.SetActive(false);
        }
    }
}
