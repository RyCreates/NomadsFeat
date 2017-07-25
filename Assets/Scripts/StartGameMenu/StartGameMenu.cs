using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameMenu : MonoBehaviour
{

    public Canvas CharacterCanvas;
    public Canvas GameCanvas;

    public Button GraveyardButton;
    public Button CastleButton;

    public Text YourMoneyText;
    public Text LevelText;
    public Text HPText;
    public Text StrengthText;
    public Text StaminaText;
    public Text SpeedText;

    public Image playerIdle;
    public Image playerWithSword;
    public Image playerWithBoots;
    public Image playerWithBootsAndSword;

    public bool CharacterCanvasIsOpen;
    public bool GameCanvasIsOpen;

    void Start()
    {
        GameCanvasIsOpen = true;
        CharacterCanvasIsOpen = false;

        YourMoney();
        Level();
        HP();
        Strength();
        Stamina();
        Speed();

        if (!PlayerStats.playerStats_doesHaveBoots && !PlayerStats.playerStats_doesHaveSword)
        {
            CharacterImageIdle();
        }
        else if (!PlayerStats.playerStats_doesHaveBoots && PlayerStats.playerStats_doesHaveSword)
        {
            CharacterImageWithSword();
        }
        else if (PlayerStats.playerStats_doesHaveBoots && !PlayerStats.playerStats_doesHaveSword)
        {
            CharacterImageWithBoots();
        }
        else if (PlayerStats.playerStats_doesHaveBoots && PlayerStats.playerStats_doesHaveSword)
        {
            CharacterImageWithBootsAndSword(); 
        }

        //if(PlayerStats.playerStats_isGraveyardChamberOpen)
        //{
        //    GraveyardButton.interactable = true;
        //}
        //else if (!PlayerStats.playerStats_isGraveyardChamberOpen)
        //{
        //    GraveyardButton.interactable = false;
        //}
        //if (PlayerStats.playerStats_isCastleChamberOpen)
        //{
        //    CastleButton.interactable = true;
        //}
        //else if (!PlayerStats.playerStats_isCastleChamberOpen)
        //{
        //    CastleButton.interactable = false;
        //}
    }

    void Update()
    {
        if(GameCanvasIsOpen==true)
        {
            GameCanvas.enabled = true;
        }
        else if (GameCanvasIsOpen == false)
        {
            GameCanvas.enabled = false;
        }
        if (CharacterCanvasIsOpen == true)
        {
            CharacterCanvas.enabled = true;
        }
        else if (CharacterCanvasIsOpen == false)
        {
            CharacterCanvas.enabled = false;
        }
    }



    public void ButtonStartGameCharacter()
    {
        CharacterCanvasIsOpen = true;
        GameCanvasIsOpen = false;
    }

    public void ButtonStartGameBackToMainMenu()
    {
        PlayerStats.isNewGameStarted = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonStartGameForest1()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 1); 
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest2()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 2);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest3()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 3);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest4()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 4);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest5()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 5);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest6()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 6);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest7()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 7);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest8()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 8);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest9()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 9);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameForest10()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 10);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard1()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 11);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard2()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 12);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard3() 
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 13);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard4()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 14);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard5()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 15);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard6()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 16);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard7()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 17);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard8()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 18);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard9()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 19);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameGraveyard10()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 20);
        SceneManager.LoadScene("1");
    }    
    public void ButtonStartGameCastle1()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 21);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle2()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 22);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle3()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 23);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle4()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 24);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle5()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 25);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle6()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 26);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle7()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 27);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle8()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 28);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle9()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 29);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameCastle10()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 30);
        SceneManager.LoadScene("1");
    }
    public void ButtonStartGameBoss()
    {
        // need to add smth
        PlayerPrefs.SetInt("GameState", 31);
        SceneManager.LoadScene("1");
    }


    public void ButtonCharacterBack() 
    {
        CharacterCanvasIsOpen = false;
        GameCanvasIsOpen = true;
    }

    public void ButtonCharacterBuy1HP()
    {
        if(PlayerStats.playerStats_Money>=10)
        {
            PlayerStats.playerStats_TotalHP++;
            PlayerStats.playerStats_CurrentHP++;
            PlayerStats.playerStats_Money -= 10;
            YourMoney();
            HP();
        }
    }

    public void ButtonCharacterBuy1Strength()
    {
        if (PlayerStats.playerStats_Money >= 50)
        {
            PlayerStats.playerStats_Strength++;
            PlayerStats.playerStats_Money -= 50;
            YourMoney();
            Strength();
        }
    }

    public void ButtonCharacterBuy1Stamina()
    {
        if (PlayerStats.playerStats_Money >= 5)
        {
            PlayerStats.playerStats_TotalStamina++;
            PlayerStats.playerStats_CurrentStamina++;
            PlayerStats.playerStats_Money -= 5;
            YourMoney();
            Stamina();
        }
    }

    public void ButtonCharacterBuy1Speed()
    {
        if (PlayerStats.playerStats_Money >= 500)
        {
            PlayerStats.playerStats_Moves++;
            PlayerStats.playerStats_Money -= 500;
            YourMoney();
            Speed();
        }
    }


    void YourMoney()
    {
        YourMoneyText.text = "Your Money: " + PlayerStats.playerStats_Money;
    }

    void Level()
    {
        LevelText.text = "Level: " + PlayerStats.playerStats_Level;
    }

    void HP()
    {
        HPText.text = "HP: " + PlayerStats.playerStats_TotalHP;
    }

    void Strength()
    {
        StrengthText.text = "Strength: " + PlayerStats.playerStats_Strength;
    }

    void Stamina()
    {
        StaminaText.text = "Stamina: " + PlayerStats.playerStats_TotalStamina;
    }

    void Speed()
    {
        SpeedText.text = "Speed: " + PlayerStats.playerStats_Moves;
    }

    void CharacterImageIdle()
    {
        playerIdle.enabled = true;
        playerWithBoots.enabled = false;
        playerWithBootsAndSword.enabled = false;
        playerWithSword.enabled = false;
    }

    void CharacterImageWithSword()
    {
        playerIdle.enabled = false;
        playerWithBoots.enabled = false;
        playerWithBootsAndSword.enabled = false;
        playerWithSword.enabled = true;
    }

    void CharacterImageWithBoots()
    {
        playerIdle.enabled = false;
        playerWithBoots.enabled = true; 
        playerWithBootsAndSword.enabled = false;
        playerWithSword.enabled = false;
    }

    void CharacterImageWithBootsAndSword()
    {
        playerIdle.enabled = false;
        playerWithBoots.enabled = false;
        playerWithBootsAndSword.enabled = true;
        playerWithSword.enabled = false;
    }
}
