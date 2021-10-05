using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float enemySpeed;
    public float enemyMaxDistance;
    private float enemyCurrentDistance;
    private float enemyCurrentX;
    private float enemyX;
    Rigidbody2D enemyBody;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = gameObject.GetComponent<Rigidbody2D>();
        enemyX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        enemyCurrentX = gameObject.transform.position.x;
        enemyCurrentDistance = Mathf.Abs(enemyCurrentX- enemyX);

        //Debug.Log(enemyCurrentDistance);
        if ((enemyCurrentDistance > enemyMaxDistance)
            &&
            (Mathf.Sign(enemyCurrentX - enemyX) == Mathf.Sign(enemySpeed))) //speed and direction consistant
        {
            enemySpeed = -1* enemySpeed;
            //Debug.Log("change dir");
        }

        enemyBody.velocity = new Vector3(enemySpeed, enemyBody.velocity.y);

    }
}
