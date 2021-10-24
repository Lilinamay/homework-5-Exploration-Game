using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circleSparkBar : MonoBehaviour
{
    public Image bar;
    public float totalSparkles;
    public float maxSparkles;
    public float sparkles;
    float spaPercent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalSparkles = FindObjectOfType<playerInteract>().starCount;
        if (sparkles < totalSparkles)
        {
            sparkles= sparkles +0.1f;
        }
        if (sparkles > totalSparkles)
        {
            sparkles = totalSparkles;
        }
        sparkleUI();
        //Debug.Log("Sparkles" +sparkles);
    }

    void sparkleUI()
    {
        spaPercent = (sparkles / maxSparkles);   //get sparkle percentage
        //Debug.Log(spaPercent);
        bar.fillAmount = spaPercent;        //fill in circle
    }



}
