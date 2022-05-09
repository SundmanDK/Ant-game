using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class manageOverlayMenu : MonoBehaviour {
public GameObject overlayMenu;
public GameObject scoreMenu;
public GameObject warningMenu;
public TMPro.TextMeshProUGUI textScore;
public GameObject Nest;
private Color scoreColor;
public Button resumeButton;
public Button quitButton;
public Button yesButton;
public Button noButton;
    // Start is called before the first frame update
    void Start()
    {
        Color scoreColor = new Color(255f,255f, 0);
        textScore.color = scoreColor;
        Button resumeBtn = resumeButton.GetComponent<Button>();
        resumeBtn.onClick.AddListener(toggleWindow);

        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(warningWindow);

        Button yesBtn = yesButton.GetComponent<Button>();
        yesBtn.onClick.AddListener(quitToMenu);
        
        Button noBtn = noButton.GetComponent<Button>();
        noBtn.onClick.AddListener(closeWarningWindow);

     //   textScore = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
        warningMenu.gameObject.SetActive(false);
           toggleWindow();
        }

        if (overlayMenu.gameObject.activeSelf){
                       Time.timeScale = 0f;
            
            textScore.text = Nest.GetComponent<NestStorage>().score.ToString();

        } else {
            Time.timeScale = 1;
        }

    

    }


void toggleWindow(){
    overlayMenu.gameObject.SetActive(!overlayMenu.gameObject.activeSelf);
        scoreMenu.gameObject.SetActive(!scoreMenu.gameObject.activeSelf);
}


void warningWindow(){
    warningMenu.gameObject.SetActive(!warningMenu.gameObject.activeSelf);
     
}

    void quitToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

void closeWarningWindow(){
        warningMenu.gameObject.SetActive(false);

}
}