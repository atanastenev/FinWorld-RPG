using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Taxpayer2 : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private TextMeshProUGUI commentPrompt;

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
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();
        dialogue1 = new string[6];
        // dialogue2 = new string[7];
        // dialogue3 = new string[7];
        // dialogue4 = new string[7];
        // dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Andy:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Andy:\nHi there! I'm Taxpayer Andy. I love collecting and organizing all of the paperwork I need in order to file my taxes. I know I’m a nerd for it, but it makes the process so much more efficient. Here are some common documents that might concern you:";
        dialogue1[1] = "Andy:\nW-2 Statements: these are reports of the income you received from your employer with any federal or state taxes withheld from you.";
        dialogue1[2] = "Andy:\n1099-DIV: Reports with dividends and other distributions from investments.";
        dialogue1[3] = "Andy:\n1099-G:these are reports from unemployment compensation, tax refunds, taxable grants, agricultural payments, and other nitty gritty capital gains.";
        dialogue1[4] = "Andy:\n1099-T:a report of the financial aid you might have received from your college or educational institutions for attending the school.";
        dialogue1[5] = "Andy:\nUsually, employers and financial entities would give you these forms by the end of January, so make sure you collect these forms in order to organize yourself.";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);

        player = interactor;
        // make text go with button
        if(interactor.quest6[3]){
            commentBubble.SetActive(true);
            if(player.answers < 5){
                player.answers++;
                if(player.answers == 5){
                    update = true;
                    currentindx = 3;
                    currentquest = 5;
                    player.answers = 0;
                }
                else{
                    update = false;
                }
            }
            StartDialogue(dialogue1);        
        } else {
            update = false;
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue); 
        }
        return true;
    }

    public string Name(){
        return "Taxpayer2";
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
        fillerdialogue = dialogue1;
        if(update){
            fillerdialogue = new string[6];
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