using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    Rigidbody2D myBody;
    SpriteRenderer myRenderer;

    //[SerializeField] private Sprite[] LRSprites;
    //[SerializeField] private Sprite[] JumpSprites;
    //[SerializeField] private Sprite[] IdleSprites;
    //[SerializeField] private Sprite[] IceSprites;

    [SerializeField] private float animationSpeed = 0.3f;
    private float timer;
    private int currentSpriteIndex = 0;

    public float speed;
    public float drag;
    public float jumpHeight;
    public float gravityMultiplier;

    public static bool faceRight = true;

    bool onFloor;
    bool onLand;
    bool onIce;


    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        checkKey();
        JumpPhysics();
        exitOnfloor();
        timer += Time.deltaTime;
    }

    void checkKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LRMovement(-speed);
            myRenderer.flipX = true;
            faceRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LRMovement(speed);
            myRenderer.flipX = false;
            faceRight = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)&& onFloor) //start jump
        {
            JumpMovement();
            Debug.Log("jump");
        } else if (!onFloor)    //jump
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (jumpHeight - 1f) * Time.deltaTime;
        }

    }

    void LRMovement(float dir)
    {
        myBody.velocity = new Vector3(dir * drag, myBody.velocity.y);
        /*if (onIce == true)
        {
            PlayerAnimation(IceSprites);
        }
        else if (onLand == true)
        {
            PlayerAnimation(LRSprites);
        }*/
    }

    void PlayerAnimation(Sprite[] currentSprite)
    {
        timer += Time.deltaTime;
        if (timer >= animationSpeed)
        {
            timer = 0;
            currentSpriteIndex++;
            currentSpriteIndex %= currentSprite.Length;
        }
        myRenderer.sprite = currentSprite[currentSpriteIndex];
    }
    void JumpMovement()
    {
        myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
        drag = 2f; //jump forward more
    }

    void JumpPhysics()
    {
        if (myBody.velocity.y < 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    void exitOnfloor()
    {
        if (onFloor && myBody.velocity.y > 0.1)
        {
            onFloor = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "land")
        {
            onFloor = true;
            //onLand = true;
            drag = 0.9f;
        }
        if(collision.gameObject.tag == "ice")
        {
            onFloor = true;
            //onIce = true;
            drag = 5f;
        }
    }
}
