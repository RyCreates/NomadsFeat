using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas ReadMeCanvas;
    public Button ContinueButton;

    public bool MainMenuCanvasIsOpen;
    public bool ReadMeCanvasIsOpen;

    public bool CanPressContinueButton;

    void Start ()
    {
        MainMenuCanvasIsOpen = true;
        ReadMeCanvasIsOpen = false;
        
        CanPressContinueButton = PlayerPrefs.GetInt("CanPressContinue") == 1 ? true : false;

        if(CanPressContinueButton)
        {
            ContinueButton.interactable = true;
        }
        else if (!CanPressContinueButton)
        {
            ContinueButton.interactable = false;
        }
    }
	
	

	void Update ()
    {
        //bools for all canvas
	    if(MainMenuCanvasIsOpen==true)
        {
            MainMenuCanvas.enabled = true;
        }
        else if (MainMenuCanvasIsOpen == false)
        {
            MainMenuCanvas.enabled = false;
        }
        if (ReadMeCanvasIsOpen == true)
        {
            ReadMeCanvas.enabled = true;
        }
        else if (ReadMeCanvasIsOpen == false)
        {
            ReadMeCanvas.enabled = false;
        }
    }

    public void ButtonMainMenuNewGame()
    {
        PlayerStats.isNewGameStarted = true; 
        // priskiriam new game parametrus
        PlayerStats.playerStats_Level = PlayerStats.playerStats_New_Level;
        PlayerStats.playerStats_CurrentXp = PlayerStats.playerStats_New_CurrentXp;
        PlayerStats.playerStats_TotalXp = PlayerStats.playerStats_New_TotalXp;
        PlayerStats.playerStats_CurrentHP = PlayerStats.playerStats_New_TotalHP; // current = total
        PlayerStats.playerStats_TotalHP = PlayerStats.playerStats_New_TotalHP;
        PlayerStats.playerStats_Strength = PlayerStats.playerStats_New_Strength;
        PlayerStats.playerStats_TotalStamina = PlayerStats.playerStats_New_TotalStamina; 
        PlayerStats.playerStats_CurrentStamina = PlayerStats.playerStats_New_TotalStamina; // current = total
        PlayerStats.playerStats_Moves = PlayerStats.playerStats_New_Moves;
        PlayerStats.playerStats_Money = PlayerStats.playerStats_New_Money;

        PlayerStats.playerStats_isForestChamberOpen = PlayerStats.playerStats_New_isForestChamberOpen;
        PlayerStats.playerStats_isGraveyardChamberOpen = PlayerStats.playerStats_New_isGraveyardChamberOpen;
        PlayerStats.playerStats_isCastleChamberOpen = PlayerStats.playerStats_New_isCastleChamberOpen;
        PlayerStats.playerStats_doesHaveBoots = PlayerStats.playerStats_New_doesHaveBoots;
        PlayerStats.playerStats_doesHaveSword = PlayerStats.playerStats_New_doesHaveSword;
        //PlayerPrefs.SetInt("LevelReached", 1);
        SceneManager.LoadScene("StartGameMenu");
    }

    public void ButtonMainMenuLoadGame()
    {
        // priskiriam saved game parametrus
        PlayerStats.playerStats_Level = PlayerPrefs.GetInt("PlayerLevel");
        PlayerStats.playerStats_CurrentXp = PlayerPrefs.GetInt("PlayerCurrentXP");
        PlayerStats.playerStats_TotalXp = PlayerPrefs.GetInt("PlayerTotalXP");
        PlayerStats.playerStats_CurrentHP = PlayerPrefs.GetInt("PlayerTotalHP"); // current = total
        PlayerStats.playerStats_TotalHP = PlayerPrefs.GetInt("PlayerTotalHP");
        PlayerStats.playerStats_Strength = PlayerPrefs.GetInt("PlayerStrength");
        PlayerStats.playerStats_TotalStamina = PlayerPrefs.GetInt("PlayerTotalStamina"); // current = total
        PlayerStats.playerStats_CurrentStamina = PlayerPrefs.GetInt("PlayerTotalStamina");
        PlayerStats.playerStats_Moves = PlayerPrefs.GetInt("PlayerMoves");
        PlayerStats.playerStats_Money = PlayerPrefs.GetInt("PlayerMoney");

        PlayerStats.playerStats_isForestChamberOpen = PlayerPrefs.GetInt("ForestChamberOpen") == 1 ? true : false;
        PlayerStats.playerStats_isGraveyardChamberOpen = PlayerPrefs.GetInt("GraveyardChamberOpen") == 1 ? true : false;
        PlayerStats.playerStats_isCastleChamberOpen = PlayerPrefs.GetInt("CastleChamberOpen") == 1 ? true : false;
        PlayerStats.playerStats_doesHaveBoots = PlayerPrefs.GetInt("DoesHaveBoots") == 1 ? true : false; // + 2 Moves
        PlayerStats.playerStats_doesHaveSword = PlayerPrefs.GetInt("DoesHaveSword") == 1 ? true : false; // + 5 Attack
        
        SceneManager.LoadScene("StartGameMenu");
    }

    public void ButtonMainReadMe()
    {
        MainMenuCanvasIsOpen = false;
        ReadMeCanvasIsOpen = true;
    }

    public void ButtonMainMenuExit()
    {
        Application.Quit();
    }

    public void ButtonReadMeBackToMainMenu()
    {
        MainMenuCanvasIsOpen = true;
        ReadMeCanvasIsOpen = false;
    }
}
