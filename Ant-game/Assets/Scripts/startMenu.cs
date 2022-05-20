using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class startMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public Button tutorialButton;

    public Button nextButton;
    public Button cancelButton;
    public Button backButton;

    private int page;

    public GameObject startUpMenu;
    public GameObject tutorialMenu;

    public TextMeshProUGUI tutorialText;

    void Start()
    {
        page = 1;
        updateText();

        startUpMenu = GameObject.Find("upstartMenuPanel");

        tutorialMenu = GameObject.Find("tutorialMenuPanel");

        Button startBtn = startButton.GetComponent<Button>();
        startBtn.onClick.AddListener(startClick);

        Button endBtn = exitButton.GetComponent<Button>();
        endBtn.onClick.AddListener(endClick);

        Button tutorialBtn = tutorialButton.GetComponent<Button>();
        tutorialBtn.onClick.AddListener(tutorialClick);

        Button nextBtn = nextButton.GetComponent<Button>();
        nextBtn.onClick.AddListener(nextClick);

        Button cancelBtn = cancelButton.GetComponent<Button>();
        cancelBtn.onClick.AddListener(cancelClick);

        Button backBtn = backButton.GetComponent<Button>();
        backBtn.onClick.AddListener(backClick);

        tutorialMenu.SetActive(false);

    }


    void startClick()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("´Starting game ...");
    }
    void endClick()
    {
        Debug.Log("Goodbye");
        Application.Quit();
    }

    void tutorialClick()
    {
        Debug.Log("tutorial starting");
    
        startUpMenu.SetActive(false);
        tutorialMenu.SetActive(true);
       
    }

    void cancelClick()
    {
        startUpMenu.SetActive(true);
        tutorialMenu.SetActive(false);
    }

    void nextClick()
    {
            page = page + 1;
        Debug.Log(page);
        updateText();
        if (page == 9) { page = 8; }

    }

    void backClick()
    {
            page = page -1;
        Debug.Log(page);
        updateText();
        if (page == 0) { page = 1; }


    }

    void updateText()
    {
        if (page == 1) { tutorialText.text = "Ant colony is a game about you together with your workers collect resources and defeat bosses."; }
        if (page == 2) { tutorialText.text = "Left click to move your character. Food sources are scattered around the environment. Move your ant into the nutritious cucumbers to pick up a piece. Now return the food to your ant colony."; }
        if (page == 3) { tutorialText.text = "Food collected can be spent on a variety of upgrades and services for you and your colony! Use it wisely. It is crucial for your survival that you expand your population with worker ants."; }
        if (page == 4) { tutorialText.text = "These smaller ants collect food automatically and use pheromones to communicate and establish trails between your colony and nearby food sources"; }
        if (page == 5) { tutorialText.text = "Ants release different pheromones depending whether they are holding food or not. Worker ants use the pheromones to determine the best direction for a nearby food source."; }
        if (page == 6) { tutorialText.text = "But be wary! The environment is also packed with dangers. critters,insects and other larger animals can either be an ants prey or predator."; }
        if (page == 7) { tutorialText.text = "Collide your character into an enemy to exchange attacks, but be careful, not all enemies are equally strong!"; }
        if (page == 8) { tutorialText.text = "Use collected food to grow your strength to increase the magnitude of your attacks and armor to mitigate heavier attacks. additionally you increase health, heal up lost health and increase speed."; }
        if (page == 9) { tutorialText.text = "collect large amounts of food and increase your power to face off the boss. You win the game by slaying all enemies. Defeating a boss will grant you a special ability which is inherited some of the bosses abilities"; } 
    
    }
}