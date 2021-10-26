using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSound : MonoBehaviour
{
    public bool playSound = false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<dialogueTrigger>().ConvEnter)
        {
            if(playSound == false)
            {
                audioManager.Instance.PlaySound(audioManager.Instance.CheckSound, audioManager.Instance.CheckVolume);
                playSound = true;
                timer = 0;
            }
        }
        if (gameObject.GetComponent<dialogueTrigger>().dialogueComplete)
        {
            timer += Time.deltaTime;
            if (playSound == true && timer == 1f)
            {
                playSound = false;
            }
        }
    }
}
