using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {

    public void Play(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("game_type").Equals("custom") ? "Custom" : "Campanha");
    }
}
