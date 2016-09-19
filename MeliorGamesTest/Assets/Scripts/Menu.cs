using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public Button ButtonForEasyGame;
	public Button ButtonForUnfairGame;
	public Button Settings;

	void Start () {
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		ButtonForEasyGame = ButtonForEasyGame.GetComponent<Button> ();
		ButtonForUnfairGame = ButtonForUnfairGame.GetComponent<Button> ();
	}

	public void StartEasyLevel() {
        ApplicationModel.SIZE = 3;
        ApplicationModel.SPRITE = "numbers";
        Application.LoadLevel ("test");
	}

    public void StartHardLevel() {
        ApplicationModel.SIZE = 4;
        ApplicationModel.SPRITE = "letters";
        Application.LoadLevel("test");
    }

    public void ExitGame () {
		Application.Quit ();
	}

}