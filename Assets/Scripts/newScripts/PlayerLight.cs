using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] GameObject world1;
    //[SerializeField] GameObject world2;
    [SerializeField] GameObject Bunny;
    [SerializeField] float lightInt2;
    [SerializeField] float lightRad;

    [SerializeField] float sparkleLight;
    public bool lightOn = false;
    public bool underworld = false;
    //public GameObject LightSource;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Light2D>().intensity = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("light: "+ GetComponentInChildren<Light2D>().intensity);
        lightSwitch();
        if (lightOn)
        {   if (underworld)
            {
                if (FindObjectOfType<circleSparkBar>().sparkles >= sparkleLight)
                {
                    if (GetComponentInChildren<Light2D>().intensity < lightInt2)
                    {
                        GetComponentInChildren<Light2D>().intensity += 0.05f;
                    }
                    if (GetComponentInChildren<Light2D>().pointLightOuterRadius < lightRad)
                    {
                        GetComponentInChildren<Light2D>().pointLightOuterRadius += 0.5f;
                    }
                    FindObjectOfType<circleSparkBar>().sparkles = FindObjectOfType<circleSparkBar>().sparkles - sparkleLight;
                }
                else if (FindObjectOfType<circleSparkBar>().sparkles < sparkleLight)
                {
                    Debug.Log("out of power");
                    lightOn = false;
                }
            }
        }else if (!lightOn)
        {
            if (underworld)
            {
                if (GetComponentInChildren<Light2D>().intensity > 1)
                {
                    GetComponentInChildren<Light2D>().intensity -= 0.1f;
                }
                if (GetComponentInChildren<Light2D>().pointLightOuterRadius > 2.48f)
                {
                    GetComponentInChildren<Light2D>().pointLightOuterRadius -= 0.9f;
                }

            }
        }
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == world1)
        {
            if (!underworld)
            {
                if (GetComponentInChildren<Light2D>().intensity < 1)
                {
                    //GetComponentInChildren<Light2D>().intensity = 1f;
                    GetComponentInChildren<Light2D>().intensity += 0.05f;
                }else if (GetComponentInChildren<Light2D>().intensity >= 1)
                {
                    underworld = true;
                }
            }
        }

        /*if (collision.gameObject == world2)
        {
            if (GetComponentInChildren<Light2D>().intensity < 1)
            {
                GetComponentInChildren<Light2D>().intensity += 0.05f;       //normal underLight
            }

        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == world1)
        {
            GetComponentInChildren<Light2D>().intensity = 0f;
            GetComponentInChildren<Light2D>().pointLightOuterRadius = 2.48f;
            underworld = false;
            lightOn = false;
        }
    }

    void lightSwitch()
    {
        if (Bunny.GetComponent<BunnyActivate>().lightUpgrade)
        {
            Debug.Log("upgradedLight done");
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (!lightOn)
                {
                    lightOn = true;
                    Debug.Log("lights on");
                }
                else if (lightOn)
                {
                    lightOn = false;
                    Debug.Log("lights off");
                }
            }
        }
    }
}
