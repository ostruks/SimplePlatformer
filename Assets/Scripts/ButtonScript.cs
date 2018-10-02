using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	public void Click()
    {
        MainCameraScript.Live = 3;
        MainCameraScript.Score = 0;
        SceneManager.LoadScene("MainScene");
    }

    public void ClickExit()
    {
        Application.Quit();
    }
}
