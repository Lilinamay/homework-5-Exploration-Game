using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    private float timer = 0;
    private float countTimer = 0;
    public float holdTime;
    public bool hasShoot = false;

    public bool resetA = false;
    public bool resetB = false;
    public GameObject ball;
    public GameObject mega;
    public GameObject sparkUp;
    //public GameObject newSpark;
    public float shootSpeed;
    public int hit;
    public int bulletCount;
    public GameObject Lily2;
    public float sparkleShoot;

    public bool hasSpark = false;
    SpriteRenderer myRenderer;

    [SerializeField] private Sprite[] ChargingSprites;
    [SerializeField] private Sprite ChargedSprites;
    [SerializeField] private float animationSpeed = 0.3f;
    private float Animetimer;
    private int currentSpriteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        bulletCount = 20;
        GameObject Lily2 = GameObject.Find("LilyReturn");
        myRenderer = sparkUp.GetComponent<SpriteRenderer>();
        myRenderer.enabled=false;

    }

    // Update is called once per frame
    void Update()
    {
        sparkAnimation();
        inputReset();
        //upgrade();
        if (gameObject.GetComponent<playerInteract>().dead == false)        //player alive and have positions
        {
            if (bulletCount >= 1)   //key press only once and have bullets
            {   if (Lily2.GetComponent<LilyActivate>().upgrade == false)
                {
                    if (Input.GetKeyUp(KeyCode.K))
                    {
                        if (hasShoot == false)
                        {
                            audioManager.Instance.PlaySound(audioManager.Instance.shootSound, audioManager.Instance.shootVolume);
                            GameObject newBall = Instantiate(ball, transform.position, transform.rotation); //default to player's position/rotation
                                newBall.transform.SetParent(gameObject.transform);
                                bulletCount--;
                                float dir = 0f;
                                if (playerMove.faceRight)
                                {
                                    dir = 1f;
                                }
                                else
                                {
                                    newBall.GetComponent<SpriteRenderer>().flipX = true;    //flip ball 
                                    dir = -1f;      //opposite direction
                                }
                                newBall.transform.localPosition = new Vector3(dir * 1f, -0.1f); ///local position relative to player
                                newBall.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x + dir * shootSpeed, 0f);  //ball move
                                newBall.GetComponent<beanBehavior>().pShoot = this;     //store and count hits
                                hasShoot = true;
                                resetA = true;
                        }
                    }
                }
                else if (Lily2.GetComponent<LilyActivate>().upgrade == true)
                {
                    if (Input.GetKey(KeyCode.K))
                    {
                        timer += Time.deltaTime;
                        Debug.Log(timer);
                    }
                    if (Input.GetKeyUp(KeyCode.K))
                    {
                        if (hasShoot == false)
                        {
                            if (timer <= holdTime)
                            {
                                audioManager.Instance.PlaySound(audioManager.Instance.shootSound, audioManager.Instance.shootVolume);
                                GameObject newBall = Instantiate(ball, transform.position, transform.rotation); //default to player's position/rotation
                                newBall.transform.SetParent(gameObject.transform);
                                bulletCount--;
                                float dir = 0f;
                                if (playerMove.faceRight)
                                {
                                    dir = 1f;
                                }
                                else
                                {
                                    newBall.GetComponent<SpriteRenderer>().flipX = true;    //flip ball 
                                    dir = -1f;      //opposite direction
                                }
                                newBall.transform.localPosition = new Vector3(dir * 1f, -0.1f); ///local position relative to player
                                newBall.GetComponent<Rigidbody2D>().velocity = new Vector3(gameObject.GetComponent<Rigidbody2D>().velocity.x + dir * shootSpeed, 0f);  //ball move
                                newBall.GetComponent<beanBehavior>().pShoot = this;     //store and count hits
                                hasShoot = true;
                                resetA = true;
                            }
                            else if (timer > holdTime)
                            {
                                audioManager.Instance.PlaySound(audioManager.Instance.megaSound, audioManager.Instance.megaVolume);
                                FindObjectOfType<circleSparkBar>().sparkles = FindObjectOfType<circleSparkBar>().sparkles - sparkleShoot;
                                GameObject newMega = Instantiate(mega, transform.position, transform.rotation); //default to player's position/rotation
                                newMega.transform.SetParent(gameObject.transform);
                                bulletCount--;
                                float dir = 0f;
                                if (playerMove.faceRight)
                                {
                                    dir = 1f;
                                }
                                else
                                {
                                    newMega.GetComponent<SpriteRenderer>().flipX = true;    //flip ball 
                                    dir = -1f;      //opposite direction
                                }
                                newMega.transform.localPosition = new Vector3(dir * 2.4f, -0.1f); ///local position relative to player
                                hasShoot = true;
                                resetB = true;
                            }
                        }
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.K) && bulletCount < 1)
            {
                Debug.Log("out of bullets");
            }        
        }
        
    }

    /*void upgrade()
    {
        if (Lily2.GetComponent<LilyActivate>().upgrade == true)
        {
            holdTime = 1;
        }
        else
        {
            holdTime = 99999;
        }
    }*/
    void sparkAnimation()
    {
        if (timer > 0.4f && timer < 1f)
        {
            myRenderer.enabled = true;
            /*if (!hasSpark)
            {
                newSpark = Instantiate(sparkUp, transform.position, transform.rotation); //default to player's position/rotation
                myRenderer = newSpark.GetComponent<SpriteRenderer>();
                newSpark.transform.SetParent(gameObject.transform);
                hasSpark = true;
            }*/
            GetAnimation(ChargingSprites);
            if (playerMove.faceRight)
            {
                sparkUp.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                sparkUp.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if(timer > 1f)
            {
                myRenderer.enabled = true;
                myRenderer.sprite = ChargedSprites;
                if (playerMove.faceRight)
                {
                    sparkUp.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    sparkUp.GetComponent<SpriteRenderer>().flipX = true;
                }
            }

    }

    void GetAnimation(Sprite[] currentSprite)                                    //animations
    {
        Animetimer += Time.deltaTime;
        if (Animetimer >= animationSpeed)
        {
            Animetimer = 0;
            currentSpriteIndex++;
            currentSpriteIndex %= currentSprite.Length;
        }
        myRenderer.sprite = currentSprite[currentSpriteIndex];
    }

    void inputReset()
    {
        if (resetA)
        {
            resetShoot(0.3f);
        }else if (resetB)
        {
            resetShoot(0.5f);
        }
    }

    void resetShoot(float resetTime)
    {
        
        if (countTimer >= resetTime)
        {
            //Debug.Log("reset timer complete");
            hasShoot = false;
            timer = 0;
            resetA = false;
            resetB = false;
            countTimer = 0;
            myRenderer.enabled = false;
            return;
        }else
        {
            countTimer += Time.deltaTime;
        }
        //Debug.Log("reset timer " + countTimer);
    }
}
