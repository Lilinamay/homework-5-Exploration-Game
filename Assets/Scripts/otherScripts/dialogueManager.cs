using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Queue<string> sentences; //a list of strings
    public bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            foreach (string sentence in FindObjectOfType<dialogueTrigger>().dialogue.sentences)
            {
                /*FindObjectOfType<dialogueManager>().*/sentences.Enqueue(sentence);
            }
            //FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
           

            //Debug.Log(sentences.Peek());
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (sentences.Count == 0)
                {
                    EndDialogue();
                    return;
                }

                string sentence = sentences.Dequeue();
                dialogueText.text = sentence;
                Debug.Log(sentence);
            }
        }
        
    }



    void EndDialogue()
    {
        Debug.Log("end of sentence");
       // FindObjectOfType<playerMove>().speed = 5;
        //FindObjectOfType<playerMove>().jumpHeight = 40;
    }


}
