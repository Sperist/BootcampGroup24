using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle2GameController : MonoBehaviour
{

    public int whoseTurn;  //0=x and 1=o
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playerIcons;  // 0=x icon and 1=o icons
    public Button[] tictactoeSpaces;
    public int[] markedSpaces;

    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoseTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for(int i =0; i <tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].interactable= true;
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;
        }
        for(int i =0;i<markedSpaces.Length; i++)
        {
            markedSpaces[i] = -1;
        }
    }

    void Update()
    {
        
    }

    public void TicTacToeButton(int WhichNumber)
    {
        tictactoeSpaces[WhichNumber].image.sprite = playerIcons[whoseTurn];
        tictactoeSpaces[WhichNumber ].interactable = false;

        markedSpaces[WhichNumber] = whoseTurn;
        turnCount++;

        if (whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
    }
}