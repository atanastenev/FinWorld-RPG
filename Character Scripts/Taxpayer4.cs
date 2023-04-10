using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Taxpayer4 : MonoBehaviour, Interactible
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
        dialogue1 = new string[5];
        // dialogue2 = new string[7];
        // dialogue3 = new string[7];
        // dialogue4 = new string[7];
        // dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Michael:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Michael:\nHi there! I'm Taxpayer Michael. You might be wondering about what some of the tax terms that we have been using mean.";
        dialogue1[1] = "Michael:\nA deduction is payments or expenses that can lower how you have to pay in taxes or taxable income.";
        dialogue1[2] = "Michael:\nTax credits are money that they give back to you after filing your taxes. You might not receive any credits depending on your financial situation in accordance with tax laws, but if you do you can receive it as direct capital.";
        dialogue1[3] = "Michael:\n Some common deductions and tax credits include:\nChild tax credit\nChild and dependent care tax credit\nEducation credits\nAdoption credits";
        dialogue1[4] = "Michael:\nEarned income tax credit\nAdoption credits\nStudent loan interest deduction\nCharitable donations deductions\nRetirement plan dedication \n& so many more.";
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
        return "Taxpayer4";
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
            fillerdialogue = new string[5];
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