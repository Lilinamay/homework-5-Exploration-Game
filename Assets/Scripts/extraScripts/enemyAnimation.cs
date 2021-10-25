using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAnimation : MonoBehaviour
{
    public bool hitanimation;
    [SerializeField] private Sprite[] ingurySprites2;
    [SerializeField] private Sprite[] ingurySprites1;
    [SerializeField] private Sprite[] attackedSprites;
    [SerializeField] private Sprite[] IdleSprites;

    [SerializeField] private float animationSpeed = 0.3f;
    [SerializeField] private float animationSpeed2 = 0.2f;
    private float timer;
    private float OneTimer;
    private int currentSpriteIndex = 0;
    SpriteRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitanimation)
        {
            Debug.Log("play hit animation");
            AnimationOneShot(attackedSprites);
        }
        else if (gameObject.GetComponent<enemyBehavior>().enemyHealth == 3)
        {
            EnemyAnimation(IdleSprites);
        }
        else if (gameObject.GetComponent<enemyBehavior>().enemyHealth == 2)
        {
            EnemyAnimation(ingurySprites2);
        }else if (gameObject.GetComponent<enemyBehavior>().enemyHealth == 1)
        {
            EnemyAnimation(ingurySprites1);
        }
    }
    void EnemyAnimation(Sprite[] currentSprite)                                    //animations
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

    void AnimationOneShot(Sprite[] currentSprite)
    {
        OneTimer += Time.deltaTime;
        Debug.Log(OneTimer);
        if (OneTimer <= animationSpeed2)
        {
            //timer = 0;
            //currentSpriteIndex=1;
            myRenderer.sprite = currentSprite[0];
            Debug.Log("first Sprite");
            //currentSpriteIndex %= currentSprite.Length;
        }
        else if (OneTimer > animationSpeed2 && OneTimer <= animationSpeed2 *2)
        {
            //timer = 0;
            //currentSpriteIndex=1;
            Debug.Log("2 Sprite");
            myRenderer.sprite = currentSprite[1];
        }else if (OneTimer > animationSpeed2 * 2)
        {
            hitanimation = false;
            OneTimer = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Circle(Clone)")
        {
            if (!hitanimation)
            {
                hitanimation = true;
                Debug.Log("hitani");
            }
        }
    }
}
