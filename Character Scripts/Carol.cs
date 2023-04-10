using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Carol : MonoBehaviour, Interactible
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
        advice[0] = "Carol:\nSo amazing that you want to know more about credit cards. Personally, I started my credit journey as an authorized user.";
        advice[1] = "Carol:\nIf you have a parent or other family member with good credit who’s willing to make you an authorized user on his or her account, doing so can help you develop your credit history.";
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Carol:\nHello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
    }

    public string Name(){
        return "Carol";
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
            update=false;
            commentBubble.SetActive(true);
            StartDialogue(advice);
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
            fillerdialogue = new string[2];
            fillerdialogue = advice;
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