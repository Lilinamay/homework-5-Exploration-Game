using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndDialogue : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Image avatarSprite;
    [SerializeField] Image textboxSprite;

    [SerializeField] GameObject checkpoint;

    bool enter= false;
    private bool haveTriggered = false;
    private bool triggered = false;
    private bool first = false;
    public bool dialogue2Complete = false;


    [SerializeField] Queue<string> sentences;
    [SerializeField] Queue<string> names; //a list of strings
    [SerializeField] Queue<Sprite> avatars;
    [SerializeField] Queue<Sprite> textboxs;

    //GameObject player;

    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
        avatars = new Queue<Sprite>();
        textboxs = new Queue<Sprite>();
        //avatarSprite.gameObject.SetActive(false);
        //textboxSprite.gameObject.SetActive(false);
        avatarSprite.enabled = false;
        textboxSprite.enabled = false; //disable without dialogue
    }

    private void triggerConversation()
    {
        if (haveTriggered == false && !dialogue2Complete && enter)
        {
            Debug.Log("trigger conversation");
            triggered = true;
            haveTriggered = true;
            sentences.Clear();
            names.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            foreach (string name in dialogue.names)
            {
                names.Enqueue(name);
            }

            foreach (Sprite avatar in dialogue.avatars)
            {
                avatars.Enqueue(avatar);
            }

            foreach (Sprite textbox in dialogue.textboxs)
            {
                textboxs.Enqueue(textbox);
            }

            Debug.Log("Trigger conversation " + names.Peek());

        }
    }



    void InEndDialogue()
    {
        Debug.Log("End conversation ");// + names.Peek());
        avatarSprite.enabled = false;
        textboxSprite.enabled = false;

        nameText.text = "";
        dialogueText.text = "";
        avatarSprite.GetComponent<Image>().sprite = null;
        textboxSprite.GetComponent<Image>().sprite = null;  //clear dialogue stuff after dialogue
        names.Clear();
        sentences.Clear();
        avatars.Clear();
        textboxs.Clear();

        /*FindObjectOfType<playerMove>().speed = 7;
        FindObjectOfType<playerMove>().jumpHeight = FindObjectOfType<playerMove>().jumpheightInput;     //unfreeze player
        FindObjectOfType<playerMove>().canFlip = true;*/
        haveTriggered = false;
        dialogue2Complete = true;
        first = false;
        triggered = false;
        gameObject.GetComponent<megaEnemy>().ball = 0;
        gameObject.GetComponent<megaEnemy>().ballHit = false;
    }


    void Update()
    {

        triggerConversation();
        if (triggered)
        {
            if (first == false)
            {
                /*FindObjectOfType<playerMove>().speed = 0;    //freeze player during dialogue
                FindObjectOfType<playerMove>().jumpHeight = 0;
                FindObjectOfType<playerMove>().canFlip = false;*/

                string name = names.Dequeue();
                string sentence = sentences.Dequeue();
                Sprite avatar = avatars.Dequeue();
                Sprite textbox = textboxs.Dequeue();    //go down list and put into a sprite/string
                avatarSprite.enabled = true;
                textboxSprite.enabled = true;   //show image
                                                //avatarSprite.gameObject.SetActive(true);
                                                //textboxSprite.gameObject.SetActive(true);
                nameText.text = name;
                dialogueText.text = sentence;
                avatarSprite.GetComponent<Image>().sprite = avatar;
                textboxSprite.GetComponent<Image>().sprite = textbox;   //input sprite/string onto placeholders in canvas
                Debug.Log(name);
                Debug.Log(sentence);
                first = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                /*FindObjectOfType<playerMove>().speed = 0;    //freeze player during dialogue
                FindObjectOfType<playerMove>().jumpHeight = 0;*/
                if (sentences.Count == 0)   //if queue empty, end dialogue
                {

                    InEndDialogue();
                    return;
                }

                string name2 = names.Dequeue();
                string sentence2 = sentences.Dequeue();
                Sprite avatar2 = avatars.Dequeue();
                Sprite textbox2 = textboxs.Dequeue();    //go down list and put into a sprite/string
                avatarSprite.enabled = true;
                textboxSprite.enabled = true;   //show image
                //avatarSprite.gameObject.SetActive(true);
                //textboxSprite.gameObject.SetActive(true);
                nameText.text = name2;
                dialogueText.text = sentence2;
                avatarSprite.GetComponent<Image>().sprite = avatar2;
                textboxSprite.GetComponent<Image>().sprite = textbox2;   //input sprite/string onto placeholders in canvas
                Debug.Log(name2);
                Debug.Log(sentence2);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.name == "player")
        {
            if (checkpoint.GetComponent<dialogueTrigger>().dialogueComplete)
            {
                enter = true;
            }
        }
    }
}
