using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Advice6 : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private TextMeshProUGUI commentPrompt;
    // [SerializeField] private GameObject picture;
    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;
    private bool update;
    private string[] dialogue1;
    // private string[] dialogue2;
    // private string[] dialogue3;
    // private string[] dialogue4;
    // private string[] dialogue5;

    private string[] fillerdialogue;
    
    public string InteractionPrompt => prompt;

    private int currentquest;
    private int currentindx;

    public void Start(){
        commentBubble.SetActive(false);
        // picture.SetActive(false);
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();
        dialogue1 = new string[2];
        // dialogue2 = new string[7];
        // dialogue3 = new string[7];
        // dialogue4 = new string[7];
        // dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Anna:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Anna:\nIn order to follow the Golden Rule of credit cards, I use apps such as Mint.com to help me connect all of my accounts if they are from different banks/financial institutions.";
        dialogue1[1] = "Anna:\nIn the real world, we advise you to download the app and connect your accounts to see all of your money altogether.";

    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);
        // picture.SetActive(true);   
        player = interactor;
        // make text go with button
        if(interactor.quest4[2]){
            commentBubble.SetActive(true);
            if(player.answers < 7){
                player.answers++;
                Debug.Log(interactor.answers);
                if(player.answers == 7){
                    update = true;
                    currentindx = 2;
                    currentquest = 3;
                    player.answers = 0;
                }
                else{
                    update = false;
                }
            }
            // picture.SetActive(true);
            StartDialogue(dialogue1);        
        } else {
            update = false;
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue); 
        }
        return true;
    }

    public string Name(){
        return "Anna";
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
        // picture.SetActive(false);
        if(update){
            fillerdialogue = new string[2];
            fillerdialogue = dialogue1;
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
}