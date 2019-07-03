using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject smallButton;
    public GameObject bigButton;
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        smallButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            CreateGame(11, 11, 2);
        });

        bigButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            CreateGame(21, 21, 4);
        });
    }

    void CreateGame(int height, int width, int numberOfEnemies)
    {
        PlayerPrefs.SetInt("height", height);
        PlayerPrefs.SetInt("width", width);
        PlayerPrefs.SetInt("numberOfEnemies", numberOfEnemies);
        SceneManager.LoadScene(nextScene);
    }
}
