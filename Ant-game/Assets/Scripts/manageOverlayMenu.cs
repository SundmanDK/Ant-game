using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageOverlayMenu : MonoBehaviour {
public GameObject overlayMenu;
public GameObject warningMenu;
public Button resumeButton;
public Button quitButton;
public Button yesButton;
public Button noButton;
    // Start is called before the first frame update
    void Start()
    {
         Button resumeBtn = resumeButton.GetComponent<Button>();
        resumeBtn.onClick.AddListener(toggleWindow);

        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(warningWindow);

        Button yesBtn = yesButton.GetComponent<Button>();
        yesBtn.onClick.AddListener(quitToMenu);
        
        Button noBtn = noButton.GetComponent<Button>();
        noBtn.onClick.AddListener(closeWarningWindow);

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
        } else {
            Time.timeScale = 1;
        }

    

    }


void toggleWindow(){
    overlayMenu.gameObject.SetActive(!overlayMenu.gameObject.activeSelf);
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