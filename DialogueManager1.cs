using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager1 : MonoBehaviour
{
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(string[] dialogue, Interactor interactor, float questIndex){
        sentences.Clear();
        Debug.Log("starting conversation");
        foreach(string sentence in dialogue){
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
    }

    public void EndDialogue(){
        
    }

}
