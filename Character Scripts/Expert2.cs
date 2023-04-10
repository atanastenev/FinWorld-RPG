using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Expert2 : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private TextMeshProUGUI commentPrompt;

    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;

    private string[] dialogue1;
    private string[] dialogue2;
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
        dialogue1 = new string[8];
        dialogue2 = new string[8];
        // dialogue3 = new string[7];
        // dialogue4 = new string[7];
        // dialogue5 = new string[7];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Expert Greg:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        dialogue1[0] = "Expert Greg:\nNice to meet you and so excited that you came to me to learn more about investing.";
        dialogue1[1] = "Expert Greg:\nTo get right into it, investing is putting money or capital towards projects or activities that are expected to generate a positive return over time, but sometimes can also be negative if the project fails.";
        dialogue1[2] = "Expert Greg:\nIn investment, risk and return work hand-in-hand with each other. Whenever there is potential for a high return on investment, there is usually a high risk to that investment, and vice versa - low risk with a lower rate of return.";
        dialogue1[3] = "Expert Greg:\nIn order to start investing, know that investors usually take two approaches to investing: do-it-yourself approach and employing a professional money manager to manage those investments.";
        dialogue1[4] = "Expert Greg:\nThere are pros and cons to each approach. With a do-it-yourself approach you are in control of your capital (money) completely and can invest in any way you want but you have to do a lot of research into each type of investment and always take a risk with such a situation.";
        dialogue1[5] = "Expert Greg:\nA professional money manager would most likely have a lot of knowledge and experience with different types of investments and have better strategy to get the best return of investment ";
        dialogue1[6] = "Expert Greg:\nbut you might need to pay for their service or they may ask for a percentage of your capital.";
        dialogue1[7] = "Expert Greg:\nIn order to learn more about investing and the types of investments you can make, go down the main plaza on the two streets that lead to the town hall.";
        
        dialogue2[0] = "Expert Greg:\nAmazing! Thank you for learning about the beginning of investing. Some great channels to watch on what are the best beginning investments are Graham Stephen, NerdWallet, or Investopedia if you want to learn more.";
        dialogue2[1] = "Expert Greg:\nFinally, I wanted to discuss active versus passive investing and growth versus value investing. Active investing is constantly trading and managing your investments by buying and selling in order to “best the index”.";
        dialogue2[2] = "Expert Greg:\nPassive investing represents a more leave and let grow approach where you buy an index fund and let your investment mature naturally.";
        dialogue2[3] = "Expert Greg:\nUsually people find passive investing more manageable and less time consuming than active investing which requires more time and research to actually successfully gain capital.";
        dialogue2[4] = "Expert Greg:\nGrowth investing in vests in high-growth companies which will have a higher price rather than earring ratio.";
        dialogue2[5] = "Expert Greg:\nValue investing focuses on higher dividend yields that other investors might not favor, they are longer term essentially.";
        dialogue2[6] = "Expert Greg:\nCongratulations! This was your crash course on investing and we hope you gained valuable insight and information into the topic.";
        dialogue2[7] = "Expert Greg:\nNow, to get you started on your next adventure, cross the tracks and find a local banker there to learn more.";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);

        player = interactor;
        // make text go with button
        if(interactor.quest5[1]){
            commentBubble.SetActive(true);
            currentquest = 4;
            currentindx = 1;
            StartDialogue(dialogue1);        
        } else if(interactor.quest5[3]){
            commentBubble.SetActive(true);
            currentquest = 5;
            currentindx = 0;
            StartDialogue(dialogue2);        
        } else {
            commentBubble.SetActive(true);
            StartDialogue(fillerdialogue); 
        }
        return true;
    }

    public string Name(){
        return "Expert Greg";
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
            if(currentindx == 0 ){
                player.quest5[3] = false;
            }
            player.quest6[currentindx] = false;
            player.quest6[currentindx+1] = true;
        }
    }
}