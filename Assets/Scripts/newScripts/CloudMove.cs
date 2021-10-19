using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float cloudSpeed;
    public float cloudMaxDistance;
    private float cloudCurrentDistance;
    private float cloudCurrentX;
    private float cloudX;
    Rigidbody2D cloudBody;

    private GameObject target = null;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cloudBody = gameObject.GetComponent<Rigidbody2D>();
        cloudX = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        cloudCurrentX = gameObject.transform.position.x;
        cloudCurrentDistance = Mathf.Abs(cloudCurrentX - cloudX);

        //Debug.Log(enemyCurrentDistance);
        if ((cloudCurrentDistance > cloudMaxDistance)
            &&
            (Mathf.Sign(cloudCurrentX - cloudX) == Mathf.Sign(cloudSpeed))) //speed and direction consistant
        {
            cloudSpeed = -1 * cloudSpeed;
            //Debug.Log("change dir");
        }

        cloudBody.velocity = new Vector3(cloudSpeed, cloudBody.velocity.y);

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("oncloud");
        target = collision.gameObject;
        
        //Debug.Log(collision.gameObject.GetComponent<Rigidbody2D>().velocity);
        //offset = target.transform.position - transform.position;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        target.gameObject.GetComponent<playerMove>().onCloud = false;
        //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x - cloudSpeed, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        target = null;
        
    }

    void LateUpdate()
    {
        if (target != null)
        {
            //float onCloudSpeed = target.gameObject.GetComponent<Rigidbody2D>().velocity.x + cloudSpeed;
            //target.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(onCloudSpeed, target.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            //target.transform.position += new Vector3(cloudSpeed, 0, 0);
            target.gameObject.GetComponent<playerMove>().onCloud = true;
            target.gameObject.GetComponent<playerMove>().cloud = gameObject;
            Debug.Log("transform");
        }
    }
}
