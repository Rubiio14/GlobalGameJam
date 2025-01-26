using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Canvas")]
    public GameObject mainMenu;
    public GameObject settings;
    public GameObject pause;
    public bool paused;
    public bool settingsMenu;

    private void Awake()
    {
        paused = false;
        settingsMenu = false;
    }

    public void InputPause(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (paused == false && SceneManager.GetSceneByBuildIndex(1) != null && settingsMenu == false)
            {
                PauseLVL();
            }
        }
    }

    public void InputBack(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            if (settingsMenu == true && SceneManager.GetSceneByBuildIndex(1) != null)
            {
                DesactivateSettingsUI();
            }
        }
    }

    //Load the level scene when player press the play button
    public void LoadLevelScene()
    {
        SceneManager.LoadScene(1);
    }

    //Load the main menu scene when player press the main menu button in the pause pop up
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    //Active the UI settings
    public void ActivateSettingsUI()
    {
        if (mainMenu != null)
        {
            settingsMenu = true;
            mainMenu.SetActive(false);
            settings.SetActive(true);
        }

        if (pause != null)
        {
            settingsMenu = true;
            pause.SetActive(false);
            settings.SetActive(true);
        }
    }

    //Desactivate the UI settings
    public void DesactivateSettingsUI()
    {
        //Main menu settings
        if (SceneManager.GetSceneByBuildIndex(0) != null && settings != null)
        {
            settingsMenu = false;
            settings.SetActive(false);
            mainMenu.SetActive(true);
        }
        //Pause menu settings
        if (SceneManager.GetSceneByBuildIndex(1) != null && settings != null)
        {
            settingsMenu = false;
            settings.SetActive(false);
            pause.SetActive(true);
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
    }

    //Close pause menu
    public void ResumeLVL()
    {
        paused = false;
        pause.SetActive(false);
    }
}
