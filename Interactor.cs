using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 2f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractionPromptUI interactionPromptUI;
    [SerializeField] private GameObject firstQuestPanel;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject balanceBar;
    [SerializeField] private TextMeshProUGUI balanceTxt;

    private readonly Collider[] colliders = new Collider[3];
    public int answers;

    [SerializeField] private int numFound;

    private Interactible interactible;

    public bool[] quest1;
    public bool[] quest2;
    public bool[] quest3;
    public bool[] quest4;
    public bool[] quest5;
    public bool[] quest6;
    public bool[] done;
    public int balance;
    public int fakebalance;
    public int money;
    public bool buy;

    private void Start(){
        firstQuestPanel.SetActive(true);
        balanceBar.SetActive(false);
        questPanel.SetActive(false);
        quest1 = new bool[5];
        quest2 = new bool[5];
        quest3 = new bool[5];
        quest4 = new bool[5];
        quest5 = new bool[5];
        quest6 = new bool[5];
        done = new bool[1];
        for (int i = 0; i < quest1.Length; i++) { 
            quest1[i] = false; 
            quest2[i] = false; 
            quest3[i] = false; 
            quest4[i] = false; 
            quest5[i] = false; 
            quest6[i] = false;
            }
        done[0] = false;
        quest1[0] = true;
        answers = 0;
        money = 2000;
        balance = 0;
        fakebalance = 0;
        buy = false;
    }
    
    private void Update(){
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
        
        if(Input.GetKeyDown(KeyCode.X)){
            firstQuestPanel.SetActive(false);
            questPanel.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.M)){
            SceneManager.LoadSceneAsync("StartMenu");
        }
        if(quest2[3]){
            balanceBar.SetActive(true);
        }
        balanceTxt.text = "Balance: $" + balance.ToString() + "\nCredit Limit: $1,000";
        Debug.Log(balanceTxt.text);
        
        if(numFound >0){
            interactible = colliders[0].GetComponent<Interactible>();

            if (interactible != null){
                if(!interactionPromptUI.IsDisplayed) interactionPromptUI.SetUp(interactible.InteractionPrompt);
                if (Input.GetKeyDown(KeyCode.E)){
                    interactible.Interact(this);
                }
                if(Input.GetKeyDown(KeyCode.C)){
                    buy = false;
                    interactible.DisplayNextSentence();
                }
                if(String.Equals(interactible.Name(), "Harry S.")){
                    if(Input.GetKeyDown(KeyCode.A)){
                        interactible.DisplayWrongAnswerPrompt();
                    }
                    else if(Input.GetKeyDown(KeyCode.B)){
                        interactible.DisplayNextSentence();
                    }
                }
                if(String.Equals(interactible.Name(), "FruitCart")){
                    if(Input.GetKeyDown(KeyCode.J)){
                        buy = true;
                        if((balance+=5) < 1000){
                            balance+=5;
                            fakebalance = balance+5;
                        }
                        interactible.DisplayNextSentence();
                    }
                    else if(Input.GetKeyDown(KeyCode.K)){
                        buy = true;
                        if((balance+=3) < 1000){
                            balance+=3;
                            fakebalance = balance+5;
                        }
                        interactible.DisplayNextSentence();
                    }
                    else if(Input.GetKeyDown(KeyCode.L)){
                        buy = true;
                        if((balance+=3) < 1000){
                            balance+=3;
                        }else{
                            fakebalance = balance+3;
                        }
                        interactible.DisplayNextSentence();
                    } else if(Input.GetKeyDown(KeyCode.C)){
                        buy = false;
                        interactible.DisplayNextSentence();
                    }

                }
                if(String.Equals(interactible.Name(), "Mikala")){
                    if(Input.GetKeyDown(KeyCode.A)){
                        interactible.DisplayWrongAnswerPrompt();
                    }
                    else if(Input.GetKeyDown(KeyCode.B)){
                        interactible.DisplayNextSentence();
                    }
                }
                if(String.Equals(interactible.Name(), "Uncle Johnny")){
                    if(Input.GetKeyDown(KeyCode.A)){
                        interactible.DisplayWrongAnswerPrompt();
                    }
                    else if(Input.GetKeyDown(KeyCode.B)){
                        interactible.DisplayNextSentence();
                    }
                }
            }
        }
        else {
            if (interactible != null) interactible = null;
            if (interactionPromptUI.IsDisplayed) interactionPromptUI.Close();
        }
    }

    private void onDrawGizmos(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }

}
