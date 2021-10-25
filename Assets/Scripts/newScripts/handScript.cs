using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handScript : MonoBehaviour
{
    public float speed=0;
    public bool collide = false;
    [SerializeField] GameObject player;

    //[SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0);

        if (collide)
        {
            speed = -5;
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(speed, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            collide = true;
        }
    }
}
