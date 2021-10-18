using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaEnemy : MonoBehaviour
{
    public int ball = 0;
    public bool ballHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball >= 3)
        {
            ballHit = true;
            //Debug.Log("hehe, can't beat me");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            ball++;
        }
    }
}
