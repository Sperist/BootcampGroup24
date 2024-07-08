using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text cellText;
    private int cellIndex;
    private System.Action<int> onCellClicked;

    public void Setup(int index, System.Action<int> onCellClicked)
    {
        cellIndex = index;
        this.onCellClicked = onCellClicked;
    }

    public void OnClick()
    {
        if (cellText.text == "")
        {
            onCellClicked(cellIndex);
        }
    }

    public void SetPlayer(string player)
    {
        cellText.text = player;
    }
}
