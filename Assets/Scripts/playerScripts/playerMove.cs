using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public AudioSource audioSource;
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
    public float jumpheightInput;
    public float jumpHeight;
    public float gravityMultiplier;
    //private bool dash = false;
    public float dashSpeed;
    [SerializeField]
    private bool duringDash = false;
    [SerializeField]
    private bool haveDashed = false;
    private float dashTimer = 0;
    public float sparkleJump = 3;
    public bool canJump = true;

    //private bool duringSecondJump = false;
    [SerializeField]
    private bool haveSecondJump = false;


    public static bool faceRight = true;

    public bool onFloor;
    public bool onCloud;
    public GameObject cloud;
    bool onLand;
    bool onIce;
    public float test = 3;
    public float rayDis = 1;
    public Transform rayCastOrigin;
    float jumpTimer = 0;
    public float theTimer;
    public bool canFlip = true;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        jumpHeight = jumpheightInput;
    }

    // Update is called once per frame
    void Update()
    {
        //Physics2D.Raycast()
        if ( !canJump)
        {
            jumpTimer -= Time.deltaTime;
        }
        checkKey();
        if (!duringDash)
        {
            JumpPhysics();
        }
        exitOnfloor();
        timer += Time.deltaTime;

        if (onCloud && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            myBody.velocity = new Vector3(cloud.GetComponent<CloudMove>().cloudSpeed, myBody.velocity.y);
        }

    private void FixedUpdate()
    {
        //if (Physics2D.Raycast(transform.position, Vector2.up))
        //{
            //Debug.Log("ray");
            
            RaycastHit2D hit = Physics2D.Raycast(rayCastOrigin.position, Vector2.down, rayDis,7);
            //Debug.Log("distance: " + hit.distance);
            //Debug.DrawRay(transform.position, Vector2.up*10, Color.red, 1, false);

            //Debug.Log(Vector2.up);

        if (hit.collider)
        {
            //Debug.Log(hit.collider.name);
            if ((hit.collider.tag == "land" || hit.collider.tag == "ice") && jumpTimer<= 0)
            {
                Debug.Log("floor below, can't jump");
                canJump = true;
                jumpTimer = theTimer;
                haveDashed = false;
                haveSecondJump = false;
            }
            
        }
        //}
    }
    void checkKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            LRMovement(-speed);
            if (canFlip)
            {
                myRenderer.flipX = true;
                faceRight = false;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LRMovement(speed);
            if (canFlip)
            {
                myRenderer.flipX = false;
                faceRight = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && canJump) //start jump
        {
            audioManager.Instance.PlaySound(audioManager.Instance.jumpSound, audioManager.Instance.jumpVolume);
            JumpMovement(jumpHeight, 1.6f);
            canJump = false;

            Debug.Log("jump");
        }
        else if (!canJump)    //during jump
        {
            if (Input.GetKeyDown(KeyCode.W) && FindObjectOfType<LilyActivate>().upgrade == true)    //during jump, can dash
            {   
                if (haveDashed == false)
                {
                    if (FindObjectOfType<circleSparkBar>().sparkles >= sparkleJump)
                    {
                        //dash = true;
                        duringDash = true;
                        haveDashed = true;
                        Debug.Log("jump2");
                        FindObjectOfType<circleSparkBar>().sparkles = FindObjectOfType<circleSparkBar>().sparkles - sparkleJump;
                        
                    }
                    else
                    {
                        Debug.Log("out of power");
                    }
                 }
                

                else if (haveDashed == true)
                {
                    if (haveSecondJump == false)
                    {
                        if (FindObjectOfType<circleSparkBar>().sparkles >= sparkleJump)
                        {
                            Debug.Log("second jump");
                            SecondJumpMovement();
                            //duringSecondJump = true;
                            haveSecondJump = true;
                            FindObjectOfType<circleSparkBar>().sparkles = FindObjectOfType<circleSparkBar>().sparkles - sparkleJump;
                        }
                        else
                        {
                            Debug.Log("out of power");
                        }

                    }

                }
            }
            else
            {
                myBody.velocity += Vector2.up * Physics2D.gravity.y * (jumpHeight - 1f) * Time.deltaTime;       //normal jump
            }

            if (duringDash)
            {                
               dashTimer += Time.deltaTime;
               //Debug.Log("timer" + dashTimer);
               DashMovement(dashSpeed);
               if (dashTimer > 0.1f)
                {
                    duringDash = false;
                    //dash = false;
                    dashTimer = 0;
                } 
            }    
        }

    }

    void LRMovement(float dir)
    {   if(onCloud)
            myBody.velocity = new Vector3(dir * drag + cloud.GetComponent<CloudMove>().cloudSpeed, myBody.velocity.y);
        else
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
    void JumpMovement(float jumpHeightValue, float dragValue)
    {
        myBody.velocity = new Vector3(myBody.velocity.x, jumpHeightValue);
        drag = dragValue; //jump forward more
    }

    void DashMovement(float dashSpeed)
    {
        if (faceRight)
        {
            myBody.velocity = new Vector3(dashSpeed, 0);
        }
        if (faceRight == false)
        {
            myBody.velocity = new Vector3(-dashSpeed, 0);
        }
    }

    void SecondJumpMovement()
    {
        if (faceRight)
        {
            myBody.velocity = new Vector3(4, myBody.velocity.y+ jumpHeight );
        }
        if (faceRight == false)
        {
            myBody.velocity = new Vector3(-4, myBody.velocity.y + jumpHeight);
        }
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
            Debug.Log("touched floor");
            onFloor = true;
            //onLand = true;
            drag = 0.9f;
            //dash = false;   //reset dash
            //dashTimer = 0;
            
            //duringSecondJump = false;
        }
        if(collision.gameObject.tag == "ice")
        {
            onFloor = true;
            //onIce = true;
            drag = 5f;

        }
    }
}
