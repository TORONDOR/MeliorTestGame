using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    public GameObject[] _cells; 

    public float startPosX = -5f;
    public float startPosY = 3f;

    private float outX = 2f;
    private float outY = 2f;

    private Sprite[] sprites;
    private Object prefab;
    public static GameObject[,] numbers;
    public static Vector3[,] position;
    private GameObject[] positionRandom;
    private int size = ApplicationModel.SIZE;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites/" + ApplicationModel.SPRITE);
        prefab = Resources.Load("Prefabs/number");

        _cells = new GameObject[size * size];
        positionRandom = new GameObject[_cells.Length];

        float posXreset = startPosX;
        position = new Vector3[size,size];
        for (int y = 0; y < size; y++)
        {
            startPosY -= outY;
            for (int x = 0; x < size; x++)
            {
                startPosX += outX;
                position[x, y] = new Vector3(startPosX, startPosY, 0);
            }
            startPosX = posXreset;
        }

        StartNewGame();
    }

    public void StartNewGame()
    {
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                _cells[y * size + x] = Instantiate(prefab, position[x, y], Quaternion.identity) as GameObject;
                _cells[y * size + x].gameObject.GetComponent<CellController>().ID = y * size + x;
                _cells[y * size + x].gameObject.GetComponent<SpriteRenderer>().sprite = sprites[y * size + x];
            }
        }
        RandomTable();
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                Destroy(_cells[y * size + x]);
            }
        }
        Debug.Log("New Game");
    }

    void Load()
    {
        numbers = new GameObject[size, size];
        int i = 0, j = 0;
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                numbers[x, y] = Instantiate(_cells[j], position[x, y], Quaternion.identity) as GameObject;
                numbers[x, y].name = "ID-" + i;
                numbers[x, y].transform.parent = transform;
                i++;
            }
        }
    }

    void CreateTable()
    {
        if (transform.childCount > 0)
        {
            for (int j = 0; j < transform.childCount; j++)
            {
                Destroy(transform.GetChild(j).gameObject);
            }
        }
        int i = 0;
        numbers = new GameObject[size, size];
        GameObject clone = new GameObject();
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                if (numbers[x, y] == null)
                {
                    numbers[x, y] = Instantiate(positionRandom[i], position[x, y], Quaternion.identity) as GameObject;
                    numbers[x, y].name = "ID-" + i;
                    numbers[x, y].transform.parent = transform;
                    i++;
                }
                if (positionRandom[i - 1].gameObject.GetComponent<CellController>().ID == size * size - 1)
                {
                    Destroy(numbers[x, y]);
                    numbers[x, y] = clone;
                }
            }
        }
        Destroy(clone);
        for (int q = 0; q < _cells.Length; q++)
        {
            Destroy(positionRandom[q]);
        }
    }

    void RandomTable()
    {
        int[] tmp = new int[_cells.Length];
        for (int i = 0; i < _cells.Length; i++)
        {
            tmp[i] = 1;
        }
        int c = 0;
        while (c < _cells.Length)
        {
            int r = Random.Range(0, _cells.Length);
            if (tmp[r] == 1)
            {
                positionRandom[c] = Instantiate(_cells[r], new Vector3(0, 10, 0), Quaternion.identity) as GameObject;
                tmp[r] = 0;
                c++;
            }
        }
        CreateTable();
    }

    public void GoBack()
    {
        Application.LoadLevel("Menu");
    }
}