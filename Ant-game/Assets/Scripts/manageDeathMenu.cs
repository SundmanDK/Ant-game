using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class manageDeathMenu : MonoBehaviour
{

    public GameObject scoreMenu;
    public GameObject overlayMenu;
    public TMPro.TextMeshProUGUI textScore;
    public GameObject Nest;
    public Button quitButton;

 




    // Start is called before the first frame update
    void Start()
    {




        //gameObject.overlayMenu.GetComponent<manageOverlayMenu>().GameOverfunction();
        Debug.Log("This is Gameover in DEATH :");

        textScore.text = Nest.GetComponent<NestStorage>().score.ToString();
        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(QuitToMenu);
    }

    void QuitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



    void Update()
    {
        Time.timeScale = 0f;
    }

}
