using UnityEngine;
using System.Collections;

public class CellController : MonoBehaviour
{
    public int ID; 
    private int size = ApplicationModel.SIZE;

    void ReplaceBlocks(int x, int y, int XX, int YY)
    {
        GameController.numbers[x, y].transform.position = GameController.position[XX, YY];
        GameController.numbers[XX, YY] = GameController.numbers[x, y];
        GameController.numbers[x, y] = null;
    }

    void OnMouseDown()
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (GameController.numbers[x, y])
                {
                    if (GameController.numbers[x, y].GetComponent<CellController>().ID == ID)
                    {
                        if (x > 0 && GameController.numbers[x - 1, y] == null)
                        {
                            ReplaceBlocks(x, y, x - 1, y);
                            return;
                        }
                        else if (x < size - 1 && GameController.numbers[x + 1, y] == null)
                        {
                            ReplaceBlocks(x, y, x + 1, y);
                            return;
                        }
                    }
                }
                if (GameController.numbers[x, y])
                {
                    if (GameController.numbers[x, y].GetComponent<CellController>().ID == ID)
                    {
                        if (y > 0 && GameController.numbers[x, y - 1] == null)
                        {
                            ReplaceBlocks(x, y, x, y - 1);
                            return;
                        }
                        else if (y < size - 1 && GameController.numbers[x, y + 1] == null)
                        {
                            ReplaceBlocks(x, y, x, y + 1);
                            return;
                        }
                    }
                }
            }
        }
    }
}