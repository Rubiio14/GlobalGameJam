using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI Canvas")]
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject pause;
    public EventSystem eventSystem;
    public Button play;
    public Button settingsSelected;
    public Button resume;
    public bool paused;
    public bool settingsMenu;
    public bool mainMenuUI;

    private void Awake()
    {
        paused = false;
        settingsMenu = false;
    }

    private void Update()
    {

    }

    public void InputPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (paused == false && SceneManager.GetSceneByBuildIndex(1).isLoaded && settingsMenu == false)
            {
                PauseLVL();
            }
        }
    }

    public void InputBack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (settingsMenu == true)
            {
                DesactivateSettingsUI();
            }
        }
    }

    //Load the level scene when player press the play button
    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
        eventSystem.SetSelectedGameObject(resume.gameObject);
    }

    //Load the main menu scene when player press the main menu button in the pause pop up
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
        eventSystem.SetSelectedGameObject(play.gameObject);
    }

    //Active the UI settings
    public void ActivateSettingsUI()
    {
        if (mainMenu != null)
        {
            settingsMenu = true;
            mainMenu.SetActive(false);
            settings.SetActive(true);
            eventSystem.SetSelectedGameObject(settingsSelected.gameObject);
        }

        if (pause != null)
        {
            settingsMenu = true;
            pause.SetActive(false);
            settings.SetActive(true);
            eventSystem.SetSelectedGameObject(settingsSelected.gameObject);
        }
    }

    //Desactivate the UI settings
    public void DesactivateSettingsUI()
    {
        settingsMenu = false;
        settings.SetActive(false);
        //Main menu settings
        if (SceneManager.GetSceneByBuildIndex(0).isLoaded && settings != null)
        {
            mainMenu.SetActive(true);
            eventSystem.SetSelectedGameObject(play.gameObject);
        }

        //Pause menu settings
        if (SceneManager.GetSceneByBuildIndex(1).isLoaded && settings != null)
        {
            pause.SetActive(true);
            eventSystem.SetSelectedGameObject(resume.gameObject);
        }
    }

    //Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Open pause menu
    public void PauseLVL()
    {
        paused = true;
        pause.SetActive(true);
        eventSystem.SetSelectedGameObject(resume.gameObject);
    }

    //Close pause menu
    public void ResumeLVL()
    {
        paused = false;
        pause.SetActive(false);
    }
}
