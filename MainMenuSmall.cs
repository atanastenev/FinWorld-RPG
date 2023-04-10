using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuSmall : MonoBehaviour
{
    [SerializeField] private Interactor player;
    [SerializeField] private TextMeshProUGUI questGuide;

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Start(){
        questGuide.text = "Welcome to FinWorld! To get started on your financial literacy journey, find and talk to Banker Jess to the nearest Bank behind the neighborhood.";
    }

    public void Update(){
        
        if(player.quest1[1]){
            questGuide.text = "Congratulations! You learned about the basics of credit but there is still more to learn. Go to a nearby house where the local financial literacy expert can help teach you more.";
        } else if (player.quest1[2]){
            questGuide.text = "Go around your beginning neighborhood and explore some friends and family to talk to and help them learn about financial literacy. Help out 3 people!";
        } else if (player.quest2[1]){
            questGuide.text = "Quest 2: Amazing! You were able to help out three friends and hopefully many more. Let’s now continue by helping you get your first credit card. Go back to Expert Erika.";
        } else if (player.quest2[2]){
            questGuide.text = "As you explore the street to talk to some credit card experts before going to Banker Jess and apply to receive your credit card.";
        } else if (player.quest2[3]){
            questGuide.text = "As you explore the street to talk to some credit card experts before going to Banker Jess and apply to receive your credit card.";
        }else if (player.quest2[4]){
            questGuide.text = "Go to Expert Erika for more advice on the importance and advantages of credit cards.";
        } else if (player.quest3[1]){
            questGuide.text = "Quest 3: Go purchase 4-5 items from shops. Make sure to not exceed your credit limit! Once you purchased enough, go back to Banker Jess or another nearby Banker to help with paying off your credit card.";
        }
        else if (player.quest3[2]){
            questGuide.text = "Go to Expert Erika to help with understanding everything about paying off your credit card.";
        }
        else if (player.quest3[3]){
            questGuide.text = "Go to the bank near the small windmill and sandbox park in order to have the banker help you pay off your card.";
        }
        else if (player.quest4[1]){
            questGuide.text = "Go to Expert Erika to learn long-term credit card usage.";
        }
        else if (player.quest4[2]){
            questGuide.text = "Get advice from at least 5 people in the neighborhood and shops near the big lighthouse. You will find many people are willing to give good advice about prolonged credit use.";
        }else if (player.quest4[3]){
            questGuide.text = "Go back to Expert Erika for some final words on credit and how to further your financial literacy journey.";
        } else if (player.quest5[1]){
            questGuide.text = "Quest 5: Go to the town hall and talk to an investing expert.";
        } else if (player.quest5[2]){
            questGuide.text = "Talk to 6 People with IA in their name to gain more investment advice.";
        } else if (player.quest5[3]){
            questGuide.text = "Go back and talk to Expert Greg for some final words on investing.";
        } else if (player.quest6[1]){
            questGuide.text = "Quest 6: Cross the railroad tracks to learn about our last advanced financial literacy topic from Banker Violet.";
        } else if (player.quest6[2]){
            questGuide.text = "Find Expert Erika on this side of the tracks to give you more insight into taxes.";
        } else if (player.quest6[3]){
            questGuide.text = "Explore the 5 experienced tax payers to gain their knowledge.";
        } else if (player.quest6[4]){
            questGuide.text = "Go back to Expert Erika for some final words of advice!";
        } else if (player.done[0]){
            questGuide.text = "Congratulations! You have completed all of the quests of FinWorld. There is so much more to explore on financial literacy so go out in the real wolrd and learn more. In the meantime you can always talk to people here on the advice they have given you.";
        }
    }
}
