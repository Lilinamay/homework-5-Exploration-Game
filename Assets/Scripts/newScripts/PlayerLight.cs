using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] GameObject world1;
    //public GameObject LightSource;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Light2D>().intensity = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponentInChildren<Light2D>().intensity);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == world1)
        {
            GetComponentInChildren<Light2D>().intensity = 1f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == world1)
        {
            GetComponentInChildren<Light2D>().intensity = 0f;
        }
    }
}
