using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Kai : MonoBehaviour, Interactible
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
        dialogue1 = new string[7];
        // dialogue2 = new string[7];
        // dialogue3 = new string[7];
        // dialogue4 = new string[7];
        // dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Banker Kai:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Banker Kai:\nHi there! So happy you’re using FinCard and gaining valuable credit experience. I see that you have spent some amount this past month on some good items in our town.";
        dialogue1[1] = "Banker Kai:\nGiven that your bank account has $2,000, you will be able to pay off your card in full, which is always a great practice.";
        dialogue1[2] = "Banker Kai:\nIt is also better to wait until your statement has been released so that the credit bureau has seen credit activity to help you with your credit score. More on that later!";
        dialogue1[3] = "Banker Kai:\nNow, let me process your checking account money to your credit card fund.";
        dialogue1[4] = "Banker Kai:\nDONE! You have paid off your card and can spend up the credit limit once again.";
        dialogue1[5] = "Banker Kai:\nHowever, we do recommend that you usually spend less than 30% of your credit limit in order to receive and work towards a higher credit score.";
        dialogue1[6] = "Banker Kai:\nSpeaking of credit score, let’s wrap up your beginning credit education by going to Expert Erika and learning about more long-term credit card use techniques.";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);

        player = interactor;
        // make text go with button
        if(interactor.quest3[3]){
            commentBubble.SetActive(true);
            currentquest = 3;
            currentindx = 0;
            update=true;
            StartDialogue(dialogue1);
            player.balance = 0;        
        } else {
            update=false;
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
        if(update){
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
                if(currentindx == 0 ){
                    player.quest3[3] = false;
                }
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