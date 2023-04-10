using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Harry : MonoBehaviour, Interactible
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

        question1 = new string[3];
        question1[0] = "Harry S.:\nI was always confused about the difference between credit and debit cards.";
        question1[1] = "Harry S.:\nWhich one of them accesses your bank account funds directly?\nA: Credit \nB: Debit";
        question1[2] = "Harry S.:\nYou are so correct! Debit cards access your direct funds from your checking bank account.";
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Harry S.:\n Hello! A credit card balance is the amount owed on the account, including the charges, interest, and fees owed.";
    }

    public string Name(){
        return "Harry S.";
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
            update=false;
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
        commentPrompt.text = "Sorry, I don't think that's quite right. Which one of them accesses your bank account funds directly?\nA: Credit \nB: Debit";
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
