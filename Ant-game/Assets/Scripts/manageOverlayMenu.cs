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
public GameObject options;
public GameObject ui;
public GameObject changeSpritePheromone;
public GameObject changeCameralock;
//public GameObject[] pheromones;

public TMPro.TextMeshProUGUI textScore;
public GameObject Nest;
private Color scoreColor;
public Button resumeButton;
public Button quitButton;
public Button yesButton;
public Button noButton;
    
public Button optionsButtonRed;
public Button optionsButtonBlue;
public Button optionsCamaraLock;

    public bool toogleButttonRed;
    public bool toggleButtonBlue;
    public bool toogleButtonCamaraLock;

    

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

        Button optionsBtnRed = optionsButtonRed.GetComponent<Button>();
        optionsBtnRed.onClick.AddListener(showRed);

        Button optionsBtnBlue = optionsButtonBlue.GetComponent<Button>();
        optionsBtnBlue.onClick.AddListener(showBlue);

        Button optionsBtnCamara = optionsCamaraLock.GetComponent<Button>();
        optionsBtnCamara.onClick.AddListener(lockCamara);



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

    public void GameOverfunction()
    {
        Debug.Log("GameOverfunction called");
        ui.gameObject.SetActive(false);
       

    }

    void toggleWindow(){
       
        overlayMenu.gameObject.SetActive(!overlayMenu.gameObject.activeSelf);
        scoreMenu.gameObject.SetActive(!scoreMenu.gameObject.activeSelf);
        options.gameObject.SetActive(!options.gameObject.activeSelf);
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


    void showRed()
    {
         if (toogleButttonRed)
         {
            toogleButttonRed = !toogleButttonRed;
             optionsButtonRed.GetComponent<ButtonSpriteChanger>().ButtonOnVisual();
             changeSpritePheromone.GetComponent<typePheromone>().Visable();

         }
         else
         {
            toogleButttonRed = !toogleButttonRed;
             optionsButtonRed.GetComponent<ButtonSpriteChanger>().ButtonOffVisual();
             changeSpritePheromone.GetComponent<typePheromone>().Invisable();

         }
 
    }
        void showBlue()
        {
            
      
        if (toggleButtonBlue) {
            toggleButtonBlue = !toggleButtonBlue;
            optionsButtonBlue.GetComponent<ButtonSpriteChanger>().ButtonOnVisual();
            changeSpritePheromone.GetComponent<typePheromone>().Visable();

    
            

        }
        else
        {
            toggleButtonBlue = !toggleButtonBlue;
            optionsButtonBlue.GetComponent<ButtonSpriteChanger>().ButtonOffVisual();
            changeSpritePheromone.GetComponent<typePheromone>().Invisable();

        }
    }
void lockCamara()
    {
        if (toogleButtonCamaraLock)
        {
            toogleButtonCamaraLock = !toogleButtonCamaraLock;
            optionsCamaraLock.GetComponent<ButtonSpriteChanger>().ButtonOnVisual();
            changeCameralock.GetComponent<CameraController>().lookToggleCamera();


        }
        else
        {
            toogleButtonCamaraLock = !toogleButtonCamaraLock;
            optionsCamaraLock.GetComponent<ButtonSpriteChanger>().ButtonOffVisual();
            changeCameralock.GetComponent<CameraController>().lookToggleCamera();

        }

    }
}