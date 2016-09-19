using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    Text text;
    
    void Start () {

        text = GetComponent<Text>();
    }
	
	void Update () {

        text.text = " Size = " + ApplicationModel.SIZE + "\n Sprite = " + ApplicationModel.SPRITE;

    }
}
