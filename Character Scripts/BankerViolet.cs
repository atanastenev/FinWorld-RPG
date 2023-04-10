using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BankerViolet : MonoBehaviour, Interactible
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
        fillerdialogue[0] = "Banker Violet:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Banker Violet:\n So great to meet you! We are happy that you have learned so much about financial literacy. Now time to learn a little bit about one of the most grueling topics in financial literacy - TAXES!";
        dialogue1[1] = "Banker Violet:\nHowever, don’t fret. We hope by completing this last quest, you will be more comfortable with how taxes work, how to file them, how to actually “do” your taxes, how to prepare, and much more into the nitty gritty of the process.";
        dialogue1[2] = "Banker Violet:\nLet me start off by explaining the very basics. The government collects taxes because of the citizen privileges you enjoy for living in the country.";
        dialogue1[3] = "Banker Violet:\nTax revenue is a huge source of revenue for the government that is used for public projects such as infrastructure, schools, mailing, sanitation, and much more.";
        dialogue1[4] = "Banker Violet:\nYou have probably heard of a sales tax that gets added to each purchase you make, but there are also income taxes that citizens need to pay.";
        dialogue1[5] = "Banker Violet:\nMany aspects of your life can impact your taxes that you owe including but not limited to your income, home, marital status, loans, retirement accounts, and major purchases.";
        dialogue1[6] = "Banker Violet:\nTo learn about how to file the taxes, find Expert Erika on this side of the tracks.";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);

        player = interactor;
        // make text go with button
        if(interactor.quest6[1]){
            commentBubble.SetActive(true);
            currentquest = 5;
            currentindx = 1;
            update = true;
            StartDialogue(dialogue1);        
        } else {
            update=false;
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue); 
        }
        return true;
    }

    public string Name(){
        return "Violet";
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
            fillerdialogue = new string[7];
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