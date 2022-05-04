using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class startMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        Button startBtn = startButton.GetComponent<Button>();
        startBtn.onClick.AddListener(startMethodClick);

        Button endBtn = exitButton.GetComponent<Button>();
        endBtn.onClick.AddListener(endMethodClick);


    }


    void startMethodClick()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("´Starting game ...");
    }
    void endMethodClick()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }
}