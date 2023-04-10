using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Banker : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private GameObject picture;
    [SerializeField] private TextMeshProUGUI commentPrompt;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject balanceBar;
    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;
    private bool update;

    private string[] dialogue1;
    private string[] dialogue2;
    private string[] dialogue3;
    // private string[] dialogue4;
    // private string[] dialogue5;

    private string[] fillerdialogue;
    
    public string InteractionPrompt => prompt;

    private int currentquest;
    private int currentindx;

    public void Start(){
        commentBubble.SetActive(false);
        picture.SetActive(false);
        balanceBar.SetActive(false);
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();
        dialogue1 = new string[6];
        dialogue2 = new string[7];
        dialogue3 = new string[3];
        // dialogue4 = new string[7];
        // dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Banker Jess:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Banker Jess:\nHello there, I am Banker Jess. In FinWorld you will learn about many different financial literacy topics such as credit, investment, and introduction to taxes. Let’s dive in with learning about credit cards first.";
        dialogue1[1] = "Banker Jess:\nA debit card uses funds that you have from your bank account. A credit card uses a credit line that can be paid back later, which gives you more time to pay. ";
        dialogue1[2] = "Banker Jess:\nA customer's credit line depends on their creditworthiness, and they can decide how and when to spend the line of credit and are usually billed on a monthly cycle.";
        dialogue1[3] = "Banker Jess:\nA debit card is issued by a bank to their customers to access funds without having to write a paper check or make a cash withdrawal. When you use a debit card, the money is automatically taken out of your checking account.";
        dialogue1[4] = "Banker Jess:\nWhen you use a credit card, you pay the bill later. You can't use your debit card if your bank account is empty, but you can use a credit card as long as you don't exceed your credit limit.";
        dialogue1[5] = "Banker Jess:\nBesides, credit cards can help you build up your credit or hurt it. If you want to apply for a credit card today, please come by late, but we encourage you to explore these credit card basics.";

        dialogue2[0] = "Banker Jess:\nHi again! We’re so glad that you’ll be applying for your first ever credit card and it's our FinCredit Account.";
        dialogue2[1] = "Banker Jess:\nWith any bank, it is always good to also have a regular bank account set up as that will give you more opportunities and promotions for better credit card offers in the future. That being said, let us submit your application and get you on your way.";
        dialogue2[2] = "Banker Jess:\nApplying & Submitting…";
        dialogue2[3] = "Banker Jess:\nAPPROVED!";
        dialogue2[4] = "Banker Jess:\nCongratulations, you can receive your FinCredit Card. Your credit limit for it is $1,000. If you would like to use it, you can explore local shops or stands and spend some money with it.";
        dialogue2[5] = "Banker Jess:\nHopefully, your parents or job has given you some income to pay off the credit card though.";
        dialogue2[6] = "Banker Jess:\nYou might be wondering now, why not just use a debit card? I would suggest visiting Expert Erika for more information on that.";

        dialogue3[0] = "Banker Jess:\nWow it’s been a full month already of receiving your credit card, how exciting! Next, let’s teach you how to pay off this card.";
        dialogue3[1] = "Banker Jess:\nYou can pay your credit card at any point either through an online portal or through going to the bank and having the bank tellers help you out.";
        dialogue3[2] = "Banker Jess:\nIn FinWorld, we value human interaction so you will need to visit bank tellers to pay off your card. To get more information on how paying off your credit card works, go to Expert Erika for more information.";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);

        player = interactor;
        // make text go with button
        if(interactor.quest1[0]){
            commentBubble.SetActive(true);
            picture.SetActive(true);
            currentquest = 0;
            currentindx = 0;
            update=true;
            StartDialogue(dialogue1);        
        } else if (interactor.quest2[3]){
            commentBubble.SetActive(true);
            currentquest = 1;
            currentindx = 3;
            update=true;
            balanceBar.SetActive(true);
            StartDialogue(dialogue2);  
        } else if (interactor.quest3[1]){
            commentBubble.SetActive(true);
            currentquest = 2;
            currentindx = 1;
            update= true;
            StartDialogue(dialogue3);  
        } else {
            update = false;
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue); 
        }
        return true;
    }

    public string Name(){
        return "Banker Jess";
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
        picture.SetActive(false);
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
