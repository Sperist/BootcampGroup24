using UnityEngine;

public class TicTacToeManager : MonoBehaviour
{
    public GameObject[] cells; // Hücrelerin referanslarý
    private string currentPlayer = "X";
    private string[] board = new string[9];

    void Start()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            int index = i;
            cells[i].GetComponent<Cell>().Setup(index, OnCellClicked);
        }
    }

    void OnCellClicked(int cellIndex)
    {
        if (board[cellIndex] == null)
        {
            board[cellIndex] = currentPlayer;
            cells[cellIndex].GetComponent<Cell>().SetPlayer(currentPlayer);

            if (CheckWin(currentPlayer))
            {
                Debug.Log(currentPlayer + " Kazandý!");
                // Oyunu bitir
                return;
            }

            if (IsBoardFull())
            {
                Debug.Log("Berabere!");
                // Oyunu bitir
                return;
            }

            currentPlayer = currentPlayer == "X" ? "O" : "X";

            if (currentPlayer == "O")
            {
                AITurn();
            }
        }
    }

    void AITurn()
    {
        int bestMove = GetBestMove();
        OnCellClicked(bestMove);
    }

    int GetBestMove()
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == null)
            {
                return i;
            }
        }
        return -1;
    }

    bool CheckWin(string player)
    {
        int[,] winConditions = new int[,]
        {
            {0, 1, 2}, {3, 4, 5}, {6, 7, 8},
            {0, 3, 6}, {1, 4, 7}, {2, 5, 8},
            {0, 4, 8}, {2, 4, 6}
        };

        for (int i = 0; i < winConditions.GetLength(0); i++)
        {
            if (board[winConditions[i, 0]] == player &&
                board[winConditions[i, 1]] == player &&
                board[winConditions[i, 2]] == player)
            {
                return true;
            }
        }
        return false;
    }

    bool IsBoardFull()
    {
        foreach (var cell in board)
        {
            if (cell == null)
            {
                return false;
            }
        }
        return true;
    }
}
