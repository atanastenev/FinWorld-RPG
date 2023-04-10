using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Garcia : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private TextMeshProUGUI commentPrompt;
    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;

    private int currentquest;
    private int currentindx;
    private bool update;

    private string[] advice;
    private string[] fillerdialogue;

    public string InteractionPrompt => prompt;
    
    // Start is called before the first frame update
    void Start()
    {
        commentBubble.SetActive(false);
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();

        advice = new string[2];
        advice[0] = "Garcia:\nHi there, I first applied for a credit card as a college student with no job and put in a very small income that was unrealistic.";
        advice[1] = "Garcia:\nBefore applying, make sure to get a job and have a decent income, even if it’s around $5K, before applying. After all, you need to earn before spending it.";
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Garcia:\n Hello! An annual fee is a yearly fee that may be charged for having a credit card. Some card issuers assess the fee in monthly installments. Some cards do not have an annual fee.";
    }

    public string Name(){
        return "Garcia";
    }

    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);
        player = interactor;

        if(player.quest2[2]){
            if(player.answers < 2){
                player.answers++;
                if(player.answers == 2){
                    update = true;
                    currentindx = 2;
                    currentquest = 1;
                    player.answers = 0;
                }
                else{
                    update = false;
                }
            }
            StartDialogue(advice);
        } else {
            update = false;
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue);
        }

        return true;

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

    public void DisplayWrongAnswerPrompt(){
        commentPrompt.text = "Sorry, I don't think that's quite right.\nA: A credit line is a phone number you can call to learn about credit cards \n B: A credit line is a set amount that the cardholder can spend up to every month, usually based on their income.";
    }

    public void EndDialogue(){
        commentBubble.SetActive(false);
        if(update){
            if(currentquest == 0){
                player.quest1[currentindx] = false;
                player.quest1[currentindx+1] = true;
            } else if (currentquest == 1){
                if(currentindx == 0 ){
                    player.quest1[2] = false;
                }
                player.quest2[currentindx] = false;
                player.quest2[currentindx+1] = true;
            } else if (currentquest == 2){
                if(currentindx == 0 ){
                    player.quest2[4] = false;
                }
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