using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour {

    Text text;
    void Start() //логика Form.Load();
    {
        text = GetComponent<Text>();
        text.text += MainCameraScript.Score.ToString();
    }
}
