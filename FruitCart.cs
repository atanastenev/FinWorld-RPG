using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FruitCart : MonoBehaviour, Interactible
{
    [SerializeField] private string prompt;
    [SerializeField] private GameObject shopsquare;
    [SerializeField] private TextMeshProUGUI shopName;
    [SerializeField] private TextMeshProUGUI item1;
    [SerializeField] private TextMeshProUGUI item2;
    [SerializeField] private TextMeshProUGUI item3;
    [SerializeField] private TextMeshProUGUI item1price;
    [SerializeField] private TextMeshProUGUI item2price;
    [SerializeField] private TextMeshProUGUI item3price;
    [SerializeField] private TextMeshProUGUI message;

    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;
    
    public string InteractionPrompt => prompt;

    public void Start(){
        shopsquare.SetActive(false);
        
        shopName.text = "";
        item1.text = "";
        item2.text = "";
        item3.text = "";
        item1price.text = "";
        item2price.text = "";
        item3price.text = "";
        message.SetText("");

    }
    
    public bool Interact (Interactor interactor){
        shopsquare.SetActive(true);
        shopName.text = "Fruit Stand";
        item1.SetText("J: Apples");
        item2.text = "K: Bananas";
        item3.text = "L: Kiwis";
        item1price.text = "$5";
        item2price.text = "$3";
        item3price.text = "$7";
        message.SetText("Click the buttons corresponding to the item to buy them!\nClick C to close the Shop");

        player = interactor;
        // make text go with button
        // if(interactor.quest1[0]){
            
       
        // } else {

        // }
        return true;
    }

    public string Name(){
        return "FruitCart";
    }
    
    public void DisplayWrongAnswerPrompt(){
        return;
    }

    public void StartDialogue(string[] dialogue){
        // sentences.Clear();
        // foreach(string sentece in dialogue){
        //     sentences.Enqueue(sentece);
        // }
        // commentPrompt.text = sentences.Dequeue();
        // if(Input.GetKey(KeyCode.C)){
        //     DisplayNextSentence();
        // }
    }

    public void DisplayNextSentence(){
        if(player.buy){
            // message text changes
            message.SetText("Thank you for buying an item!\nClick C to close the Shop or purchase something else");
            if(player.fakebalance > 1000){
                message.SetText("Sorry, you don't have sufficient funds.\nClick C to close the Shop and pay off your credit card.");
            }
        }
        else{
            EndDialogue();
        }
        // if(sentences.Count == 0){
        //     return;
        // }
        // commentPrompt.text = sentences.Dequeue();
    }

    public void EndDialogue(){
        shopsquare.SetActive(false);
        // commentBubble.SetActive(false);
        // if(currentquest == 0){
        //     player.quest1[currentindx] = false;
        //     player.quest1[currentindx+1] = true;
        // } else if (currentquest == 1){
        //     player.quest2[currentindx] = false;
        //     player.quest2[currentindx+1] = true;
        // } else if (currentquest == 2){
        //     player.quest3[currentindx] = false;
        //     player.quest3[currentindx+1] = true;
        // } else if (currentquest == 3){
        //     player.quest4[currentindx] = false;
        //     player.quest4[currentindx+1] = true;      
        // } else if (currentquest == 4){
        //     player.quest5[currentindx] = false;
        //     player.quest5[currentindx+1] = true; 
        // } else {
        //     player.quest6[currentindx] = false;
        //     player.quest6[currentindx+1] = true;
        // }
    }
}