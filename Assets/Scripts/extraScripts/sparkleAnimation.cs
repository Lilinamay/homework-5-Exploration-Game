using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparkleAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] IdleSprites;

    [SerializeField] private float animationSpeed = 0.3f;
    private float timer;
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
        SparkleAnimation(IdleSprites);
    }

    void SparkleAnimation(Sprite[] currentSprite)                                    //animations
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
}
