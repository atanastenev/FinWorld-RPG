using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Expert : MonoBehaviour, Interactible
{
    // [SerializeField] private float typingSpeed = 0.2f;
    [SerializeField] private string prompt;
    [SerializeField] private GameObject commentBubble;
    [SerializeField] private TextMeshProUGUI commentPrompt;
    [SerializeField] private Button continueButton;
    [SerializeField] private GameObject picture;
    private Queue<string> sentences;
    private DialogueManager1 manager;
    private Interactor player;
    private bool update;

    private string[] dialogue1;
    private string[] dialogue2;
    private string[] dialogue3;
    private string[] dialogue4;
    private string[] dialogue5;
    private string[] dialogue6;
    private string[] dialogue7;
    private string[] dialogue8;
    private string[] fillerdialogue;
    
    public string InteractionPrompt => prompt;

    private int currentquest;
    private int currentindx;

    public void Start(){
        commentBubble.SetActive(false);
        picture.SetActive(false);
        currentindx = 0;
        currentquest = 0;
        sentences = new Queue<string>();
        dialogue1 = new string[20];
        dialogue2 = new string[5];
        dialogue3 = new string[18];
        dialogue4 = new string[9];
        dialogue5 = new string[9];
        dialogue6 = new string[6];
        dialogue7 = new string[8];
        dialogue8 = new string[10];
        fillerdialogue = new string[1];
        fillerdialogue[0] = "Expert Erika:\n Hello! We're so excited that you are expanding your financial literacy journey. Complete the current task at hand before coming back to talk and learn more.";
        // dialogue 1 filler
        dialogue1[0] = "Expert Erika:\nHi player! I am Erika, the town financial literacy expert and I am excited to help you learn so much more about financial literacy.";
        dialogue1[1] = "Expert Erika:\nFirst, let’s learn what a credit line is. A credit card does not just have unlimited balance for one to spend.Credit cards usually come with a set credit line,";
        dialogue1[2] = "Expert Erika:\n(say $500, $2,500, or $25,000) based on the cardholder's income. Credit cards allow consumers to carry a balance from month to month, on which they must pay interest.";
        dialogue1[3] = "Expert Erika:\nIn general, a credit card issuer will raise your credit limit as you spend more and make regular payments. A credit card can be used for many different financial needs including:";
        dialogue1[4] = "Expert Erika:\nDaily Transactions (groceries, gas, travel, etc.)\nAccumulating Cashback (more on this later)\nBoosting your Credit Score (great for future financial decisions)";
        dialogue1[5] = "Expert Erika:\nGetting more trust with your bank and getting pre-approved for better credit cards (ranking of different cards coming later)";
        dialogue1[6] = "Expert Erika:\nFinally, here a couple of different types of credit cards you should know about as a beginner of credit:";
        dialogue1[7] = "Expert Erika:\nSecured Credit Cards: Most credit cards are unsecured, meaning you don't have to put down any collateral. With secured credit cards, on the other hand,";
        dialogue1[8] = "Expert Erika:\nSecured Credit Cards: you're required to put down a cash deposit in order to secure a small line of credit, usually for a similar amount. For example, you might sign up for a secured credit card";
        dialogue1[9] = "Expert Erika:\nSecured Credit Cards: and put down a $500 initial deposit in order to receive a $500 line of credit. The one-time deposit (and therefore credit limit) can be as low as $49.";
        dialogue1[10] = "Expert Erika:\nSecured Credit Cards: While putting down collateral may not seem ideal, secured credit cards are the easiest type of credit card to get approved for,";
        dialogue1[11] = "Expert Erika:\nSecured Credit Cards: so they are often helpful when you need to build credit from scratch or want to repair your credit after a financial hurdle.";
        dialogue1[12] = "Expert Erika:\nStudent Credit Cards: These credit cards are for young people who don't necessarily have a credit history.";
        dialogue1[13] = "Expert Erika:\nStudent Credit Cards: These credit cards have lesser requirements leading to more people getting approved for them in order to start on their credit journey,";
        dialogue1[14] = "Expert Erika:\nStudent Credit Cards:accumulate a credit score and become eligible to get better credit cards later on";
        dialogue1[15] = "Expert Erika:\nCash Back Credit Cards: Cash back credit cards make it easy for you to earn cash back or statement credits on your spending,";
        dialogue1[16] = "Expert Erika:\nCash Back Credit Cards: although how rewards are doled out varies from card to card.";
        dialogue1[17] = "Expert Erika:\nCash Back Credit Cards: Some options in this niche offer a flat rate of rewards while others offer bonus points in certain categories like dining or travel.";
        dialogue1[18] = "Expert Erika:\nCash Back Credit Cards: Some even offer bonus rewards in categories that change each quarter, as well as a flat rate of rewards on all non-bonus purchases.";
        dialogue1[19] = "Expert Erika:\nNow that you know the basics, go around town to help friends and family learn about credit themselves!";
        //dialogue 2 filler
        dialogue2[0] = "Expert Erika:\nGreat job in helping out your friends and family with their credit card questions. Maybe you will become a better expert than me one day! Let’s get you your first credit card. ";
        dialogue2[1] = "Expert Erika:\nSome real world examples of credit cards for beginners that you can check out include Discover It, Bank of America Student Credit Card, and Chase Freedom.";
        dialogue2[2] = "Expert Erika:\nBut here in FinWorld, we hope you will apple and receive our beginner friendly FinCredit Card. In order to receive a credit card you need to fill out an application.";
        dialogue2[3] = "Expert Erika:\nThese applications should not be intimidating or hard, they only ask for personal information, employment, and income. The applications can be filled out online or in a bank (I know, very old school).";
        dialogue2[4] = "Expert Erika:\nFor our sake, let’s apply the old school way. Before going to receive your new card, I encourage you to ask around some other experienced credit card users on their application tips as well.";
        // dialogue 3 filler
        dialogue3[0] = "Expert Erika:\nCongratulations on obtaining your first credit card. You might be wondering what was the point of you going through that process and even using a credit card.";
        dialogue3[1] = "Expert Erika:\nA wonderful advantage of credit, aside from being able to use funds that you can pay off later, are the wonderful sign-in bonuses and also reward points, grace periods, and building credit. ";
        dialogue3[2] = "Expert Erika:\nLet me walk you through each one of these advantages so you can be convinced that credit is the way to go.";
        dialogue3[3] = "Expert Erika:\nWhen applying and getting approved for certain credit cards, they have one-time sign-up bonuses. These bonuses can include and are not limited to:";
        dialogue3[4] = "Expert Erika:\n - Actual cash (from $150 to $1000) for spending a certain amount with you credit cards the first couple of months of owning it\n - Credit cards reward points\n - Travel points/miles";
        dialogue3[5] = "Expert Erika:\nAnother amazing bonus to credit cards is cash back. back in the form of cash back. After a certain time this cash back can be redeemed as actual cash, store credit, etc.";
        dialogue3[6] = "Expert Erika:\nFor every transaction you make, a certain percentage, usually 1%, 2%, or 3% of the transaction amount will be rebated or given back to you in credit card reward points.";
        dialogue3[7] = "Expert Erika:\nThere are also rewards points: Many reward credit cards provide bonus points for certain categories of spending like restaurants, groceries or gasoline.";
        dialogue3[8] = "Expert Erika:\nWhen certain earnings thresholds are reached, points can be redeemed for travel, gift cards from retailers and restaurants, or for merchandise items through the credit card company's online rewards portal.";
        dialogue3[9] = "Expert Erika:\nAdditionally, certain banks that have credit cards that are affiliated with airlines and one can earn many travel points to redeem free flights or get discounted prices on flights once they redeem the Airline miles/points.";
        dialogue3[10] = "Expert Erika:\nWhen you make a debit card purchase, your money is gone right away. When you make a credit card purchase, your money remains in your checking account until you pay your credit card bill.";
        dialogue3[11] = "Expert Erika:\nHanging on to your funds for this extra time can be helpful in two ways.";
        dialogue3[12] = "Expert Erika:\nFirst, the time value of money, however infinitesimal, will save you money. Delaying eventual payment makes your purchase a tiny bit cheaper than it would be otherwise.";
        dialogue3[13] = "Expert Erika:\nSecond, when you consistently pay with a credit card you don't have to watch your bank account balance as closely.";
        dialogue3[14] = "Expert Erika:\nIf you have no credit or are trying to improve your credit score, using a credit card responsibly will help because credit card companies will report your payment activity to the credit bureaus.";
        dialogue3[15] = "Expert Erika:\nHowever, debit card use doesn't appear anywhere on your credit report, so it can't help you build or improve your credit.";
        dialogue3[16] = "Expert Erika:\nEven if you need to deposit some funds to get a secured credit card, this can help you build your credit history and eventually qualify for unsecured cards or larger loans for future purchases such as cards and real estate.";
        dialogue3[17] = "Expert Erika:\nThat is the end of my lesson 2 on the advantages of credit cards. Looks like your parents let you have a small amount of cash to be able to use your credit card. Go around some shops to purchase some items and get some use of your credit card.";
        // dialogue 4 filler
        dialogue4[0] = "Expert Erika:\nHi once again! Hope you were able to explore using your credit card better. Now that you’re ready to pay it off, let me describe some details about credit card payments and vocabulary as well.";
        dialogue4[1] = "Expert Erika:\nOnce you reach a month of your use and activation of the credit card, you receive what is called a statement balance.";
        dialogue4[2] = "Expert Erika:\nIt is a monthly breakdown of your transactions and contains the amount you owe back to the bank for that month. You usually have a due date associated with this statement balance, called a grace period.";
        dialogue4[3] = "Expert Erika:\nMy best advice is that you pay off the statement balance in full or as soon as possible in order to avoid any interest rate fees. ";
        dialogue4[4] = "Expert Erika:\nOnce the due date comes and you have not paid a certain amount of the statement balance, an interest rate is applied to your amount and you will need to pay a lot more than you originally owe.";
        dialogue4[5] = "Expert Erika:\nThese fees are usually mentioned as APR - the cost of credit expressed as a yearly interest rate. A penalty APR is the APR charged on new transactions if you trigger the penalty terms in your credit card contract.";
        dialogue4[6] = "Expert Erika:\nYour credit card issuer may consider you in default if you pay late, go over your credit limit, or if your check is returned. Penalty rates usually are higher than your standard or introductory rates.";
        dialogue4[7] = "Expert Erika:\nIf you become more than 60 days late, the penalty APR may be applied to your existing balance.";
        dialogue4[8] = "Expert Erika:\nThat being said, go to a new nearby bank, maybe the one near the sandbox park and near the windmill to ask the banker there to help you out with paying off your card.";
        // dialogue 5 filler
        dialogue5[0] = "Expert Erika:\nWe hope you have gained a lot of valuable knowledge about credit and credit cards. However, here are some helpful tips to help you have a successful credit experience overall.";
        dialogue5[1] = "Expert Erika:\nThe first and most important rule in credit, what we like to call, THE GOLDEN RULE OF CREDIT CARDS, is to never spend more than you actually have.";
        dialogue5[2] = "Expert Erika:\nWhen you're a credit card owner, you need to be disciplined in not spending over your credit limit and paying off your credit card, either throughout the monthly timeframe between statements or after monthly statements come out.";
        dialogue5[3] = "Expert Erika:\nThe GOLDEN RULE of Credit Cards is never spend more than your credit limit and NEVER SPEND MORE THAN YOU HAVE (in your immediate funds from banks).  A great addition to the GOLDEN RULE is ideally to pay off all of your credit card fees as soon as possible.";
        dialogue5[4] = "Expert Erika:\nDon't necessarily just pay off your minimum fee and move on to spending, make sure to apply the GOLDEN RULE. <b>Never spend more that you cannot  pay off right away.</b>";
        dialogue5[5] = "Expert Erika:\nTo me that is the best thing to remember about credit and it takes great discipline to achieve.";
        dialogue5[6] = "Expert Erika:\nNow, let’s dive deeper into credit scores. A credit score is a number generated from the results of your credit report between 300 to 850.";
        dialogue5[7] = "Expert Erika:\nRather than me lecturing excessively on credit score and good practices to keep it high, I want to send you on an adventure to talk to other experienced credit card holders that can give you good tips on how to keep a good credit score.";
        dialogue5[8] = "Expert Erika:\nKeep in mind that when you are a beginner your credit score starts off at an average rate (between 580-670) but with good credit practices it will increase.";
        // dialogue 6 filler
        dialogue6[0] = "Expert Erika:\nCongratulations! You have learned so much about credit and now are ready to move forward with your financial literacy journey by exploring more advanced topics of investing and taxes.";
        dialogue6[1] = "Expert Erika:\nRemember that the advice people around town will always be there to repeat their advice if you need that information once more. To get started on investing, let me give a spiel on money and compound value.";
        dialogue6[2] = "Expert Erika:\nWhen your money sits in a checking or savings account, they don’t grow and stay stagnant, however, there is a way to put your money to work and have it grow or shrink with time.";
        dialogue6[3] = "Expert Erika:\nThis is investing! We often think of investing as this fast-way to get rich, but in this module we hope to explain that investing is not supposed to be a fast-way approach to earn wealth.";
        dialogue6[4] = "Expert Erika:\nInstead, it's a financial undertaking in hopes of generating positive returns if done patiently and smartly, but with high risk. ";
        dialogue6[5] = "Expert Erika:\nRather than me lecturing, we will let you explore other experts in the city to help you learn about finance. Go to the city hall in the middle back of the town to talk to another expert there.";
        // dialogue 7 filler
        dialogue7[0] = "Expert Erika:\nHi again! Looks like I can transport places pretty easily in this world. I also do know a couple of things about taxes that I can help you understand better. Let’s start with how to file them.";
        dialogue7[1] = "Expert Erika:\nWe fill our tax forms that we send those files to the federal government and the state in which we live.";
        dialogue7[2] = "Expert Erika:\nAlso, there might exist local or city taxes that might need to be filed depending on your residence.";
        dialogue7[3] = "Expert Erika:\nAnother important note to understand is that you can file your taxes completely by yourself and for free with certain programs such as TurboTax, but often it is easier to have an experienced filer";
        dialogue7[4] = "Expert Erika:\nor even tax expert help you with the process the first couple of times in order to gain expertise on the best methods to file taxes, especially if you hold many assets and have tricky references such as loans, or debt, or large important purchases. ";
        dialogue7[5] = "Expert Erika:\nWith new software that exists out there, you can file everything online and don’t need to calculate the hard math, instead you fill out certain sections of the tax forms and the software sends it over for review for you.";
        dialogue7[6] = "Expert Erika:\nTax returns generally need to be filed and postmarked and sent around April 15th, but most people prepare their documents and such at the beginning of the year and recommend completing the process in March.";
        dialogue7[7] = "Expert Erika:\nInstead of me lecturing about how to prepare for filing your taxes, go around the neighborhood here with the houses and talk to the experienced taxpayers about their experience and advice with filing and completing your taxes.";
        // dialogue 8 filler
        dialogue8[0] = "Expert Erika:\nAmazing! I hope you gained valuable information from the taxpayers in our town. Please never be afraid to ask for more information or go back and have the taxpayers recall these tips and important steps in filing your taxes.";
        dialogue8[1] = "Expert Erika:\nOne last lecture before a summary. In taxes, there is a process called auditing which the IRS decides to review your taxes more in depth and have you under investigation to confirm that your filing is correct and fair.";
        dialogue8[2] = "Expert Erika:\nGenerally:\nHigher income individual get audited more frequently\nLarger deductions might cause more auditing\n& individuals with bigger increases or decreases in theri income or expenses are more likely to get audited.";
        dialogue8[3] = "Expert Erika:\nThis is nothing scary if you have all of your information organized and send all of the paperwork that the IRS wants you to send them in order to confirm all of your information.";
        dialogue8[4] = "Expert Erika:\nUsually, correcting the error and paying a small fine would be all that goes into auditing. To summarize everything about taxes in three short points:";
        dialogue8[5] = "Expert Erika:\n1. Prepare, organize, and collect all of your paperwork related to taxes from employers, business endeavors, and financial institutions (investing, house ownership, banks). ";
        dialogue8[6] = "Expert Erika:\n2. Decide if you want to fill them out by yourself with an online software or have an advisor to help you with filing them for a service fee.";
        dialogue8[7] = "Expert Erika:\n3. Fill out your Form 1040 and submit and you will be done.";
        dialogue8[8] = "Expert Erika:\nYou have learned so much about taxes, investing, and credit cards now. We have enjoyed helping you learn and you can now explore the town and always get advice from any of the citizens of FinWorld.";
        dialogue8[9] = "Expert Erika:\nCongratulations once again and we hope you become even more interested in your financial literacy journey!";
    }

    public string Name(){
        return "Expert Erika";
    }
    
    public bool Interact (Interactor interactor){
        commentBubble.SetActive(true);
        player = interactor;
        if(interactor.quest1[1]){
            commentBubble.SetActive(true);
            currentquest = 0;
            currentindx = 1;
            update = true;
            StartDialogue(dialogue1);        
        } else if (interactor.quest2[1]){
            commentBubble.SetActive(true);
            currentquest = 1;
            currentindx = 1;
            update = true;
            StartDialogue(dialogue2);
        } else if (interactor.quest2[4]){
            commentBubble.SetActive(true);
            currentquest = 2;
            currentindx = 0;
            update = true;
            StartDialogue(dialogue3);
        } else if (interactor.quest3[2]){
            commentBubble.SetActive(true);
            currentquest = 2;
            currentindx = 2;
            update = true;
            picture.SetActive(true);
            StartDialogue(dialogue4);
        } else if (interactor.quest4[1]){
            commentBubble.SetActive(true);
            currentquest = 3;
            currentindx = 1;
            update = true;
            StartDialogue(dialogue5);
        } else if (interactor.quest4[3]){
            commentBubble.SetActive(true);
            currentquest = 4;
            currentindx = 0;
            update = true;
            StartDialogue(dialogue6);
        } else if (interactor.quest6[2]){
            commentBubble.SetActive(true);
            currentquest = 5;
            currentindx = 2;
            update = true;
            StartDialogue(dialogue7);
        } else if (interactor.quest6[4]){
            commentBubble.SetActive(true);
            currentquest = 6;
            currentindx = 0;
            update = true;
            StartDialogue(dialogue8);
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
        // Debug.Log(commentPrompt.text);
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        commentPrompt.text = sentences.Dequeue();
        // Debug.Log(commentPrompt.text);
    }

    public void DisplayWrongAnswerPrompt(){
        return;
    }

    public void EndDialogue(){
        commentBubble.SetActive(false);
        picture.SetActive(false);
        if (update){
            if(currentquest == 0){
                player.quest1[currentindx] = false;
                player.quest1[currentindx+1] = true;
            } else if (currentquest == 1){
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
                if(currentindx == 0 ){
                    player.quest4[3] = false;
                }
                player.quest5[currentindx] = false;
                player.quest5[currentindx+1] = true; 
            } else if (currentquest == 6) {
                player.done[0] = true;
            } else {
                player.quest6[currentindx] = false;
                player.quest6[currentindx+1] = true;
            }
        }
    }
}