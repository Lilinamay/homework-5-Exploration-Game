using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image avatarSprite;
    public Image textboxSprite;

    private bool triggered = false;
    public bool dialogueComplete = false;

    private Queue<string> sentences;
    private Queue<string> names; //a list of strings
    private Queue<Sprite> avatars;
    private Queue<Sprite> textboxs;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "player")
        {   
            triggered = true;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "player")
        {
            triggered = false;
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        Debug.Log("End conversation ");// + names.Peek());
        avatarSprite.enabled = false;
        textboxSprite.enabled = false;
        //avatarSprite.gameObject.SetActive(false);
        //textboxSprite.gameObject.SetActive(false);
        nameText.text = "";
        dialogueText.text = "";
        avatarSprite.GetComponent<Image>().sprite = null;
        textboxSprite.GetComponent<Image>().sprite = null;  //clear dialogue stuff after dialogue
        names.Clear();
        sentences.Clear();
        avatars.Clear();
        textboxs.Clear();

        FindObjectOfType<playerMove>().speed = 5;
        FindObjectOfType<playerMove>().jumpHeight = 40;     //unfreeze player

        dialogueComplete = true;
    }

    void Update()
    {
        if (triggered)
        {

            if (Input.GetKeyDown(KeyCode.M))
            {
                FindObjectOfType<playerMove>().speed = 0;    //freeze player during dialogue
                FindObjectOfType<playerMove>().jumpHeight = 0;
                if (sentences.Count == 0)   //if queue empty, end dialogue
                {
                    EndDialogue();
                    return;
                }

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
            }
        }
    }




}