using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Template : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private TextMeshProUGUI commentPrompt;
    [SerializeField] private Button continueButton;
    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;

    private string[] dialogue1;
    private string[] dialogue2;
    private string[] dialogue3;
    private string[] dialogue4;
    private string[] dialogue5;

    private string[] fillerdialogue;
    
    public string InteractionPrompt => prompt;

    private int currentquest;
    private int currentindx;

    public void Start(){
        commentBubble.SetActive(false);
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();
        dialogue1 = new string[6];
        dialogue2 = new string[7];
        dialogue3 = new string[7];
        dialogue4 = new string[7];
        dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Name:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Name:\n";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);

        player = interactor;
        // make text go with button
        if(interactor.quest1[0]){
            commentBubble.SetActive(true);
            currentquest = 0;
            currentindx = 0;
            StartDialogue(dialogue1);        
        } else if (interactor.quest2[3]){
            commentBubble.SetActive(true);
            currentquest = 1;
            currentindx = 3;
            StartDialogue(dialogue2);  
        } else if (interactor.quest3[1]){
            commentBubble.SetActive(true);
            currentquest = 2;
            currentindx = 1;
            StartDialogue(dialogue2);  
        } else {
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue); 
        }
        return true;
    }

    public string Name(){
        return "Template";
    }
    
    public void DisplayWrongAnswerPrompt(){
        return;
    }

    public void StartDialogue(string[] dialogue){
        sentences.Clear();
        foreach(string sentece in dialogue){
            sentences.Enqueue(sentece);
        }
        commentPrompt.text = sentences.Dequeue();
        if(Input.GetKey(KeyCode.C)){
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        commentPrompt.text = sentences.Dequeue();
    }

    public void EndDialogue(){
        commentBubble.SetActive(false);
        if(currentquest == 0){
            player.quest1[currentindx] = false;
            player.quest1[currentindx+1] = true;
        } else if (currentquest == 1){
            player.quest2[currentindx] = false;
            player.quest2[currentindx+1] = true;
        } else if (currentquest == 2){
            player.quest3[currentindx] = false;
            player.quest3[currentindx+1] = true;
        } else if (currentquest == 3){
            player.quest4[currentindx] = false;
            player.quest4[currentindx+1] = true;      
        } else if (currentquest == 4){
            player.quest5[currentindx] = false;
            player.quest5[currentindx+1] = true; 
        } else {
            player.quest6[currentindx] = false;
            player.quest6[currentindx+1] = true;
        }
    }
}