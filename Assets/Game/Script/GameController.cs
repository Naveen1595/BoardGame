using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]GameObject player1, player2,Dice;
    [SerializeField]Transform WinTransform;
    [SerializeField] GameObject gOver,gStatus;
    DiceController diceController;
    PlayerController player1Controller;
    PlayerController player2Controller;
    Text playerWinStatus,gameStatus;

    int winStatus;
    bool gameOver = false;
    int playerMove = 0;
    int DiceNo =0;
    int playerNo;

    void Start()
    {
        diceController = Dice.GetComponent<DiceController>();
        player1Controller = player1.GetComponent<PlayerController>();
        player2Controller = player2.GetComponent<PlayerController>();
        diceController.OnRoll += Move;
        playerWinStatus = gOver.GetComponentInChildren<Text>();
        gameStatus = gStatus.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        int winStatus = checkWhoWins();
        if (winStatus > 0)
        {
            gameOver = true;
            gOver.SetActive(true);
            playerWinStatus.text = "Player " + winStatus + " Wins!";
        }
    }
    int checkWhoWins()
    {

        if (player1.transform.position == WinTransform.position)
            return 1;
        else if (player2.transform.position == WinTransform.position)
            return 2;
        else
            return 0;

    }

    void Move()
    {
        int playerPos;
        playerNo = choosePlayer();
        DiceNo = diceController.GetDiceNo();
        for (int j = 0; j < DiceNo; j++)
        {
            int winStatus = checkWhoWins();
            if (winStatus > 0)
            {
                gameOver = true;
                gOver.SetActive(true);
                playerWinStatus.text = "Congratulations!   Player " + winStatus + " Wins!";
            }
            if (playerNo == 1 && gameOver == false)
            {
                gameStatus.text = "Player-1 Move "+ DiceNo + " Steps";
                player1.transform.position = player1Controller.GetWayPoint().position;
            }
            else if(playerNo == -1 && gameOver == false)
            {
                gameStatus.text = "Player-2 Move " + DiceNo + " Steps";
                player2.transform.position = player2Controller.GetWayPoint().position;
            }
        }
        if (playerNo == 1 && gameOver == false)
        {
            playerPos = player1Controller.GetPoint();
            if ((playerPos % 5 == 0) && (playerPos % 10 == 0))
            {
                gameStatus.text = "Penalty!!!! Player-1 Move 3 Step Back";
                StartCoroutine(backMove(1));
            }
            else if(playerPos % 5 == 0)
            {
                gameStatus.text = "Player-1 Gains Extra Chance";
                chekk();
            }
        }
        else if (playerNo == -1 && gameOver == false)
        {
            playerPos = player2Controller.GetPoint();
            if ((playerPos % 5 == 0) && (playerPos % 10 == 0))
            {
                gameStatus.text = "Penalty!!!! Player-2 Move 3 Step Back";
                StartCoroutine(backMove(2));
            }
            else if (playerPos % 5 == 0)
            {
                gameStatus.text = "Player-2 Gains Extra Chance";
                chekk();
            }
        }

    }

    IEnumerator backMove(int playerNo)
    {
        if(playerNo == 1)
        {
            yield return new WaitForSeconds(1f);
            ChekkBack(1);
        }
        else if(playerNo == 2)
        {
            yield return new WaitForSeconds(1f);
            ChekkBack(2);
        }
            
        
    }
    void chekk()
    {
        choosePlayer();
    }

    void ChekkBack(int playerNo)
    {
        if(playerNo == 1)
        {
            for(int i=0;i<3;i++)
            {
                player1.transform.position = player1Controller.GetWayPointBack().position;
            }
            
        }
        else if(playerNo == 2)
        {
            for(int i=0;i<3;i++)
            {
                player2.transform.position = player2Controller.GetWayPointBack().position;
            }
        }
            
    }

    int choosePlayer()
    {
        if (playerMove == 0)
        {
            playerMove = 1;
        }
        else
        {
            playerMove *= -1;
        }
        return playerMove;
    }

}
