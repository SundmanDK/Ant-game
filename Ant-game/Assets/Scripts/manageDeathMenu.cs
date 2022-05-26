using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manageDeathMenu : MonoBehaviour{
    public TMPro.TextMeshProUGUI textScore;
    public GameObject Nest;
    public Button quitButton;

    void Start(){
        Nest = GameObject.Find("Nest");
        textScore.text = Nest.GetComponent<NestStorage>().score.ToString();
        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(QuitToMenu);
    }

    void QuitToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Update(){
        Time.timeScale = 0f;
    }
}
