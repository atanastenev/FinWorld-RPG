using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UncleJohnny : MonoBehaviour, Interactible
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

    private string[] question1;
    private string[] fillerdialogue;

    public string InteractionPrompt => prompt;
    
    // Start is called before the first frame update
    void Start()
    {
        commentBubble.SetActive(false);
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();

        question1 = new string[2];
        question1[0] = "Uncle Johnny:\nWhat type of credit card allows you to only access a certain amount that you initially deposited and cannot spend beyond that limit?\nA: Student Credit Card\n B: Secured Credit Card";
        question1[1] = "Uncle Johnny:\nYou are so correct! A secured credit card only let's you access a credit limit based on an initial deposit.";
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Uncle Johnny:\n Hello! A credit card balance is the amount owed on the account, including the charges, interest, and fees owed.";
    }

    public string Name(){
        return "Uncle Johnny";
    }

    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);
        player = interactor;

        if(player.quest1[2]){
            if(player.answers < 3){
                player.answers++;
                if(player.answers == 3){
                    update = true;
                    currentindx = 0;
                    currentquest = 1;
                    player.answers = 0;
                }
                else{
                    update = false;
                }
            }
            StartDialogue(question1);
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
        commentPrompt.text = "Sorry, I don't think that's quite right. What type of credit card allows you to only access a certain amount that you initially deposited and cannot spend beyond that limit?\nA: Student Credit Card\n B: Secured Credit Card";
    }

    public void EndDialogue(){
        commentBubble.SetActive(false);
        if(update){
            fillerdialogue = new string[2];
            fillerdialogue = question1;
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