using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour
{
    public static GM instance;

    public enum GameState
    {
        Forest1, 
        Forest2,
        Forest3,
        Forest4,
        Forest5,
        Forest6,
        Forest7,
        Forest8,
        Forest9,
        Forest10,
        Graveyard1,
        Graveyard2,
        Graveyard3,
        Graveyard4,
        Graveyard5,
        Graveyard6,
        Graveyard7,
        Graveyard8,
        Graveyard9,
        Graveyard10,
        Castle1,
        Castle2,
        Castle3,
        Castle4,
        Castle5,
        Castle6,
        Castle7,
        Castle8,
        Castle9,
        Castle10,
        Boss
    }

    public GameState gameState;

    [SerializeField]
    private GameObject ForestGameBoardPrefab;
    [SerializeField]
    private GameObject GraveyardGameBoardPrefab;
    [SerializeField]
    private GameObject CastleGameBoardPrefab;
    [SerializeField]
    private GameObject BossBoardPrefab;

    public Canvas PauseCanvas;
    public Canvas GMCanvas;
    public Canvas WinCanvas;
    public Canvas LoseCanvas;
    //public Canvas TouchCanvas;
    public Image TouchImage;

    //public Image HPBarImage;
    //public Image StaminaBarImage;
    //public Image XPBarImage;
    public Image NarateL1;
    public Image NarateL1_1;
    public Image NarateL51;

    public BarsStats healthBarStat;
    public BarsStats staminaBarStat;
    public BarsStats xpBarStat;

    public bool TouchCanvasIsOpen;
    public bool PauseCanvasIsOpen;
    public bool isGamePaused;
    public bool playersTurn;
    public bool enemiesAreMoving;
    
    public bool doesHaveSword;
    public bool doesHaveBoots;
    public bool isGraveyardChamberOpen;
    public bool isCastleChamberOpen;
    public int canPressContinueInt;

    public float changeTurnDelay = 0.1f;
    public int howManyEnemiesAreInThisMap;
    public int howManyEnemiesEndedTurn;

    public int chamber;
    public int chamberToWin;
    public int treasures; // cia reikia sukurti inventoriu
    public GameObject inventory; // cia reikia sukurti inventoriu

    public Text chamberText;
    public Text chamberToWinMap;
    public Text playerLevelText;
    public Text playerXPText;
    public Text playerHPText;
    public Text playerStrengthText;
    public Text playerMoneyText;
    public Text playerStaminaText;
    public Text playerMovesLeftText;
    public Text playerOrEnemiesTurnText;

    public int playerLevel = 1;
    public int playerXPNeededToNextLvl = 100;
    public int playerCurrentXP = 0;
    public int playerTotalXP = 0; 
    public int playerTotalHP = 100;
    public int playerCurrentHP = 100; 
    public int playerCurrentStamina = 70;  // food, need 1 for ability to move 1 time
    public int playerTotalStamina = 70;
    public int playerStrength = 0;  // attack strength
    public int playerMoney = 0;
    public int playerMovesLeft;
    public int playerMovesTotal;
    public int movesUsedInThisLevelForCountingStars;

    public List<Enemy> enemiesList = new List<Enemy>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        playersTurn = true;

        // gameState
        int gst = PlayerPrefs.GetInt("GameState");
        if (gst == 1 || gst == 0)
        {
            gameState = GameState.Forest1;  
        }
        else if (gst == 2)
        {
            gameState = GameState.Forest2;
        }
        else if (gst == 3)
        {
            gameState = GameState.Forest3;
        }
        if (gst == 4)
        {
            gameState = GameState.Forest4;
        }
        else if (gst == 5)
        {
            gameState = GameState.Forest5;
        }
        else if (gst == 6)
        {
            gameState = GameState.Forest6;
        }
        if (gst == 7)
        {
            gameState = GameState.Forest7;
        }
        else if (gst == 8)
        {
            gameState = GameState.Forest8;
        }
        else if (gst == 9)
        {
            gameState = GameState.Forest9;
        }
        else if (gst == 10)
        {
            gameState = GameState.Forest10;
        }
        else if (gst == 11)
        {
            gameState = GameState.Graveyard1;
        }
        else if (gst == 12)
        {
            gameState = GameState.Graveyard2;
        }
        else if (gst == 13)
        {
            gameState = GameState.Graveyard3;
        }
        else if (gst == 14)
        {
            gameState = GameState.Graveyard4;
        }
        else if (gst == 15)
        {
            gameState = GameState.Graveyard5;
        }
        else if (gst == 16)
        {
            gameState = GameState.Graveyard6;
        }
        else if (gst == 17)
        {
            gameState = GameState.Graveyard7;
        }
        else if (gst == 18)
        {
            gameState = GameState.Graveyard8;
        }
        else if (gst == 19)
        {
            gameState = GameState.Graveyard9;
        }
        else if (gst == 20)
        {
            gameState = GameState.Graveyard10;
        }
        else if (gst == 21)
        {
            gameState = GameState.Castle1;
        }
        else if (gst == 22)
        {
            gameState = GameState.Castle2;
        }
        else if (gst == 23)
        {
            gameState = GameState.Castle3;
        }
        else if (gst == 24)
        {
            gameState = GameState.Castle4;
        }
        else if (gst == 25)
        {
            gameState = GameState.Castle5;
        }
        else if (gst == 26)
        {
            gameState = GameState.Castle6;
        }
        else if (gst == 27)
        {
            gameState = GameState.Castle7;
        }
        else if (gst == 28)
        {
            gameState = GameState.Castle8;
        }
        else if (gst == 29)
        {
            gameState = GameState.Castle9;
        }
        else if (gst == 30)
        {
            gameState = GameState.Castle10;
        }
        else if (gst == 31)
        {
            gameState = GameState.Boss;
        }

        AwakeSwitch();
        GMCanvas.enabled = true;
        GM.instance.playersTurn = true;
        GM.instance.playerMovesLeft = GM.instance.playerMovesTotal;
        GM.instance.UpdateMovesLeftText();
        WinCanvas.enabled = false;
        LoseCanvas.enabled = false;

        if (healthBarStat != null)
        {
            healthBarStat.currentValue1 = GM.instance.playerCurrentHP;
            healthBarStat.maxValue1 = GM.instance.playerTotalHP;
            healthBarStat.UpdateValue();            
        }
        if (xpBarStat != null)
        {
            xpBarStat.currentValue1 = GM.instance.playerCurrentXP;
            xpBarStat.maxValue1 = GM.instance.playerXPNeededToNextLvl;
            xpBarStat.UpdateValue();
        }
        if (staminaBarStat != null)
        {
            staminaBarStat.currentValue1 = GM.instance.playerCurrentStamina;
            staminaBarStat.maxValue1 = GM.instance.playerTotalStamina;
            staminaBarStat.UpdateValue();
        }
    }
     
	void Start ()
    {
        // priskiriam visus player stats
        isGraveyardChamberOpen = PlayerStats.playerStats_isGraveyardChamberOpen;
        isCastleChamberOpen = PlayerStats.playerStats_isCastleChamberOpen;

        playerLevel = PlayerStats.playerStats_Level;
        playerXPNeededToNextLvl = 8888;
        playerCurrentXP = PlayerStats.playerStats_CurrentXp;
        playerTotalXP = PlayerStats.playerStats_TotalXp;
        playerTotalHP = PlayerStats.playerStats_TotalHP;
        playerCurrentHP = PlayerStats.playerStats_TotalHP; 
        playerCurrentStamina = PlayerStats.playerStats_TotalStamina;  // food, need 1 for ability to move 1 time
        playerTotalStamina = PlayerStats.playerStats_TotalStamina;
        playerStrength = PlayerStats.playerStats_Strength;  // attack strength
        playerMoney = PlayerStats.playerStats_Money;
        playerMovesTotal = PlayerStats.playerStats_Moves;
        playerMovesLeft = PlayerStats.playerStats_Moves;
        doesHaveSword = PlayerStats.playerStats_doesHaveSword;
        doesHaveBoots = PlayerStats.playerStats_doesHaveBoots;

        StartSwitch();
        PauseCanvasIsOpen = false;
        TouchCanvasIsOpen = false;
        isGamePaused = false;
        howManyEnemiesEndedTurn = 0;
        UpdateChamberText();
        UpdateTreasuresText();
        UpdateInventoryText();
        UpdatePlayerLevelText();
        UpdatePlayerXP(0);
        UpdatePlayerHPText();
        UpdateStrengthText();
        UpdatePlayerMoneyText();
        UpdatePlayerStaminaText();
        UpdateMovesLeftText();

        NarateL1.gameObject.SetActive(false);
        NarateL1_1.gameObject.SetActive(false);
        NarateL51.gameObject.SetActive(false);

        if (PlayerStats.isNewGameStarted && chamber==1)
        {
            NarateL1.gameObject.SetActive(true);
        }
        if (!GM.instance.doesHaveBoots && chamber == 51)
        {
            NarateL51.gameObject.SetActive(true);
        }

    }
	
	void AwakeSwitch()
    {
        switch (gameState)
        {
            case GameState.Forest1:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest2:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest3:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest4:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest5:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest6:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest7:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest8:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest9:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Forest10:
                Instantiate(ForestGameBoardPrefab);
                break;
            case GameState.Graveyard1:                
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard2:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard3:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard4:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard5:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard6:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard7:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard8:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard9:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Graveyard10:
                Camera.main.transform.position += new Vector3(-0.9f, 0.6f, 0);
                Camera.main.orthographicSize += 0.5f;
                Instantiate(GraveyardGameBoardPrefab);
                break;
            case GameState.Castle1:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0); 
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle2:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle3:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle4:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle5:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle6:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle7:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle8:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle9:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Castle10:
                Camera.main.transform.position += new Vector3(0.5f, 1, 0);
                Camera.main.orthographicSize += 1f;
                Instantiate(CastleGameBoardPrefab);
                break;
            case GameState.Boss:
                Camera.main.transform.position += new Vector3(-3f, 0.1f, 0);
                //Camera.main.orthographicSize -= 0.5f;
                Instantiate(BossBoardPrefab);
                break;
            default:
                break;
        }
    }

    void StartSwitch()
    {
        switch (gameState)
        {
            case GameState.Forest1:
                chamber = 1;
                chamberToWin = 5;
                break;
            case GameState.Forest2:
                chamber = 6;
                chamberToWin = 10;
                break;
            case GameState.Forest3:
                chamber = 11;
                chamberToWin = 15;
                break;
            case GameState.Forest4:
                chamber = 16;
                chamberToWin = 20;
                break;
            case GameState.Forest5:
                chamber = 21;
                chamberToWin = 25;
                break;
            case GameState.Forest6:
                chamber = 26;
                chamberToWin = 30;
                break;
            case GameState.Forest7:
                chamber = 31;
                chamberToWin = 35;
                break;
            case GameState.Forest8:
                chamber = 36;
                chamberToWin = 40;
                break;
            case GameState.Forest9:
                chamber = 41;
                chamberToWin = 45;
                break;
            case GameState.Forest10:
                chamber = 46;
                chamberToWin = 50;
                break;
            case GameState.Graveyard1:
                chamber = 51;
                chamberToWin = 55;
                break;
            case GameState.Graveyard2:
                chamber = 56;
                chamberToWin = 60;
                break;
            case GameState.Graveyard3:
                chamber = 61;
                chamberToWin = 65;
                break;
            case GameState.Graveyard4:
                chamber = 66;
                chamberToWin = 70;
                break;
            case GameState.Graveyard5:
                chamber = 71;
                chamberToWin = 75;
                break;
            case GameState.Graveyard6:
                chamber = 76;
                chamberToWin = 80;
                break;
            case GameState.Graveyard7:
                chamber = 81;
                chamberToWin = 85;
                break;
            case GameState.Graveyard8:
                chamber = 86;
                chamberToWin = 90;
                break;
            case GameState.Graveyard9:
                chamber = 91;
                chamberToWin = 95;
                break;
            case GameState.Graveyard10:
                chamber = 96;
                chamberToWin = 100;
                break;
            case GameState.Castle1:
                chamber = 101;
                chamberToWin = 105;
                break;
            case GameState.Castle2:
                chamber = 106;
                chamberToWin = 110;
                break;
            case GameState.Castle3:
                chamber = 111;
                chamberToWin = 115;
                break;
            case GameState.Castle4:
                chamber = 116;
                chamberToWin = 120;
                break;
            case GameState.Castle5:
                chamber = 121;
                chamberToWin = 125;
                break;
            case GameState.Castle6:
                chamber = 126;
                chamberToWin = 130;
                break;
            case GameState.Castle7:
                chamber = 131;
                chamberToWin = 135;
                break;
            case GameState.Castle8:
                chamber = 136;
                chamberToWin = 140;
                break;
            case GameState.Castle9:
                chamber = 141;
                chamberToWin = 145;
                break;
            case GameState.Castle10:
                chamber = 146;
                chamberToWin = 150;
                break;
            case GameState.Boss:
                chamber = 151;
                chamberToWin = 151;
                break;
            default:
                Debug.Log("nnieko");
                break;
        }
    }

    void Update()
    {
        UpdateWhosMoveText(); // jei nera labai brangus skaiciavimu atzvilgiu

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvasIsOpen = true;
        }
        if (PauseCanvasIsOpen == true)
        {
            PauseCanvas.enabled = true;
        }
        else if (PauseCanvasIsOpen == false)
        {
            PauseCanvas.enabled = false;
        }
        if (TouchCanvasIsOpen == true)
        {
            //TouchCanvas.enabled = true;
            TouchImage.enabled = true;
        }
        else if (TouchCanvasIsOpen == false)
        {
            //TouchCanvas.enabled = false; 
            TouchImage.enabled = false;
        }

        if (enemiesList.Count>0 && !playersTurn && !enemiesAreMoving)
        {
            
            howManyEnemiesAreInThisMap = enemiesList.Count;
            for (int i=0; i<enemiesList.Count;i++)
            {
                StartCoroutine(MoveEnemies());
            }
            if(howManyEnemiesAreInThisMap==howManyEnemiesEndedTurn)
            {
                playersTurn = true;
                for (int i = 0; i < enemiesList.Count; i++)
                {
                    enemiesList[i].movesLeftThisTurn = enemiesList[i].howMuchTimesCanEnemyMove;
                }
                howManyEnemiesEndedTurn = 0;

                UpdateMovesLeft(playerMovesTotal); // vel prasideda player eile
            }
        }
	}

    IEnumerator MoveEnemies()
    {
        enemiesAreMoving = true;
        yield return new WaitForSeconds(changeTurnDelay);

        if (enemiesList.Count == 0)
        {
            yield return new WaitForSeconds(0f);
        }
        for (int i = 0; i < enemiesList.Count; i++)
        {
            enemiesList[i].EnemyMove();
            yield return new WaitForSeconds(enemiesList[i].timeBetweenMoves);
        }
        enemiesAreMoving = false;
    }

    public void UpdateChamber(int chamb)
    {
        chamb += chamb;
        UpdateChamberText();
    }

    void UpdateChamberText()
    {
        chamberText.text = "Chamber: " + chamber +"/" + chamberToWin;
    }

    public void UpdateTreasures(int treas)
    {
        treasures += treas;
        UpdateTreasuresText();
    }

    void UpdateTreasuresText()
    {

    }

    public void UpdateInventory()
    {
        UpdateInventoryText();
    }

    void UpdateInventoryText()
    {

    }

    public void UpdatePlayerLevel(int lvl)
    {
        playerLevel += lvl;
        UpdatePlayerLevelText();
    }

    void UpdatePlayerLevelText()
    {
        playerLevelText.text = "" + playerLevel;
    }

    public void UpdatePlayerXP(int xpp)
    {
        // gauna xp
        playerCurrentXP += xpp;

        //xp table
        if (playerLevel==1)
        {
            playerXPNeededToNextLvl = 100;
            if(playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 100;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 5; // + 5 stamina
                playerTotalStamina += 5;
                UpdatePlayerStamina(0);
            }
        }
        else if (playerLevel == 2)
        {
            playerXPNeededToNextLvl = 100;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 100;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 5; // + 5 stamina
                playerTotalStamina += 5;
                UpdatePlayerStamina(0);
            }
        }
        else if (playerLevel == 3)
        {
            playerXPNeededToNextLvl = 100;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 200;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 5; // + 5 stamina
                playerTotalStamina += 5;
                UpdatePlayerStamina(0);
            }
        }
        else if (playerLevel == 4)
        {
            playerXPNeededToNextLvl = 200;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 500;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 5; // + 5 stamina
                playerTotalStamina += 5;
                UpdatePlayerStamina(0);
            }
        }
        else if (playerLevel == 5)
        {
            playerXPNeededToNextLvl = 500;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 1500;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 5; // + 5 stamina
                playerTotalStamina += 5;
                UpdatePlayerStamina(0);
                playerStrength += 1; // + 1 strength
                UpdateStrenght(0);
            }
        }
        else if (playerLevel == 6)
        {
            playerXPNeededToNextLvl = 1500;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 3500;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 5; // + 5 stamina
                playerTotalStamina += 5;
                UpdatePlayerStamina(0);
            }
        }
        else if (playerLevel == 7)
        {
            playerXPNeededToNextLvl = 3500;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 9000;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 10; // + 10 stamina
                playerTotalStamina += 10;
                UpdatePlayerStamina(0);
                playerStrength += 1; // + 1 strength
                UpdateStrenght(0);
            }
        }
        else if (playerLevel == 8)
        {
            playerXPNeededToNextLvl = 9000;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 20000;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 10; // + 10 stamina
                playerTotalStamina += 10;
                UpdatePlayerStamina(0);
                playerStrength += 1; // + 1 strength
                UpdateStrenght(0);
            }
        }
        else if (playerLevel == 9)
        {
            playerXPNeededToNextLvl = 20000;
            if (playerCurrentXP >= playerXPNeededToNextLvl)
            {
                playerCurrentXP -= playerXPNeededToNextLvl;
                playerXPNeededToNextLvl = 20000;
                UpdatePlayerLevel(1);

                playerCurrentHP += 10; // + 10 HP
                playerTotalHP += 10;
                UpdatePlayerHP(0);
                playerCurrentStamina += 10; // + 10 stamina
                playerTotalStamina += 10;
                UpdatePlayerStamina(0);
                playerStrength += 1; // + 1 strength
                UpdateStrenght(0);
                playerMovesTotal += 1;
                playerMovesLeft += 1;
                UpdateMovesLeftText();
            }
        }
        else if (playerLevel == 10) // neprisimenu ka daro sitas , turi likti 10 lvl ir nebuti 11 // ar tikrai prideda atributu ??
        {
            playerXPNeededToNextLvl = 20000;
            playerCurrentXP = 20000;

            playerCurrentHP += 10; // + 10 HP
            playerTotalHP += 10;
            UpdatePlayerHP(0);
            playerCurrentStamina += 10; // + 10 stamina
            playerTotalStamina += 10;
            UpdatePlayerStamina(0);
        }

        UpdatePlayerXPText();
        GMUpdateHPBar();
        GMUpdateStaminaBar();
        GMUpdateXPBar();
    }

    void UpdatePlayerXPText()
    {
        playerXPText.text = "" + playerCurrentXP + "/" + playerXPNeededToNextLvl;
    }

    public void UpdatePlayerHP(int hp)
    {
        playerCurrentHP += hp;
        UpdatePlayerHPText();
    }

    public void UpdatePlayerHPText()
    {
        playerHPText.text = "" + playerCurrentHP + "/" + playerTotalHP; ;
    }

    public void UpdateStrenght(int str)
    {
        playerStrength += str;
        UpdateStrengthText();
    }

    void UpdateStrengthText()
    {
        playerStrengthText.text = "" + playerStrength;
    }

    public void UpdatePlayerMoney(int money)
    {
        playerMoney += money;
        UpdatePlayerMoneyText();
    }

    void UpdatePlayerMoneyText()
    {
        playerMoneyText.text = "" + playerMoney;
    }

    public void UpdatePlayerStamina(int stam)
    {
        playerCurrentStamina += stam;
        UpdatePlayerStaminaText();
    }
    
    void UpdatePlayerStaminaText()
    {
        playerStaminaText.text = "" + playerCurrentStamina + "/" + playerTotalStamina;
    }

    public void UpdateMovesLeft(int moves)
    {
        playerMovesLeft = moves;
        UpdateMovesLeftText();
    }

    public void UpdateMovesLeftText()
    {
        playerMovesLeftText.text = "" + playerMovesLeft + "/" + playerMovesTotal;
    }

    public void UpdateWhosMoveText()
    {
        if(playersTurn)
        {
            playerOrEnemiesTurnText.text = "Your Turn";
        }
        else if(!playersTurn)
        {
            playerOrEnemiesTurnText.text = "Enemies are moving";
        }
    }

    public void ButtonPauseGameCanvasResume()
    {
        PauseCanvasIsOpen = false;
    }

    public void ButtonPauseGameCanvasEndGame()
    {
        Destroy(LoseCanvas.gameObject);
        Destroy(WinCanvas.gameObject);
        Destroy(GMCanvas.gameObject);
        Destroy(PauseCanvas.gameObject);
        //Destroy(TouchCanvas.gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene("StartGameMenu");
    }    

    public void ButtonPauseGameCanvasExit()
    {
        Application.Quit();
    }

    public void WinThisMap()
    {
        WinCanvas.enabled = true;
        GMCanvas.enabled = false;

        if(PlayerStats.isNewGameStarted==true)
        {
            PlayerPrefs.SetInt("LevelReached", 2);
            PlayerStats.isNewGameStarted = false;

            // nunulinam visas zvaigzdes nuo antro levelio, pirma paliekam
            for(int i=1;i<31;i++) // 31 - totalLevels
            {
                PlayerPrefs.SetInt("SetStars" + i, 0);
            }

        }

        if (gameState == GameState.Forest1)
        {
            CountStars(0);
            if (PlayerPrefs.GetInt("LevelReached")<2)
            {
                PlayerPrefs.SetInt("LevelReached", 2);
            }
        }
        if (gameState == GameState.Forest2)
        {
            CountStars(1);
            if (PlayerPrefs.GetInt("LevelReached") < 3)
            {
                PlayerPrefs.SetInt("LevelReached", 3);
            }
        }
        if (gameState == GameState.Forest3)
        {
            CountStars(2);
            if (PlayerPrefs.GetInt("LevelReached") < 4)
            {
                PlayerPrefs.SetInt("LevelReached", 4);
            }
        }
        if (gameState == GameState.Forest4)
        {
            CountStars(3);
            if (PlayerPrefs.GetInt("LevelReached") < 5)
            {
                PlayerPrefs.SetInt("LevelReached", 5);
            }
        }
        if (gameState == GameState.Forest5)
        {
            CountStars(4);
            if (PlayerPrefs.GetInt("LevelReached") < 6)
            {
                PlayerPrefs.SetInt("LevelReached", 6);
            }
        }
        if (gameState == GameState.Forest6)
        {
            CountStars(5);
            if (PlayerPrefs.GetInt("LevelReached") < 7)
            {
                PlayerPrefs.SetInt("LevelReached", 7);
            }
        }
        if (gameState == GameState.Forest7)
        {
            CountStars(6);
            if (PlayerPrefs.GetInt("LevelReached") < 8)
            {
                PlayerPrefs.SetInt("LevelReached", 8);
            }
        }
        if (gameState == GameState.Forest8)
        {
            CountStars(7);
            if (PlayerPrefs.GetInt("LevelReached") < 9)
            {
                PlayerPrefs.SetInt("LevelReached", 9);
            }
        }
        if (gameState == GameState.Forest9)
        {
            CountStars(8);
            if (PlayerPrefs.GetInt("LevelReached") < 10)
            {
                PlayerPrefs.SetInt("LevelReached", 10);
            }
        }
        if (gameState == GameState.Forest10)
        {
            CountStars(9);
            if (PlayerPrefs.GetInt("LevelReached") < 11)
            {
                PlayerPrefs.SetInt("LevelReached", 11);
            }
        }
        if (gameState == GameState.Graveyard1)
        {
            CountStars(10);
            if (PlayerPrefs.GetInt("LevelReached") < 12)
            {
                PlayerPrefs.SetInt("LevelReached", 12);
            }
        }
        if (gameState == GameState.Graveyard2)
        {
            CountStars(11);
            if (PlayerPrefs.GetInt("LevelReached") < 13)
            {
                PlayerPrefs.SetInt("LevelReached", 13);
            }
        }
        if (gameState == GameState.Graveyard3)
        {
            CountStars(12);
            if (PlayerPrefs.GetInt("LevelReached") < 14)
            {
                PlayerPrefs.SetInt("LevelReached", 14);
            }
        }
        if (gameState == GameState.Graveyard4)
        {
            CountStars(13);
            if (PlayerPrefs.GetInt("LevelReached") < 15)
            {
                PlayerPrefs.SetInt("LevelReached", 15);
            }
        }
        if (gameState == GameState.Graveyard5)
        {
            CountStars(14);
            if (PlayerPrefs.GetInt("LevelReached") < 16)
            {
                PlayerPrefs.SetInt("LevelReached", 16);
            }
        }
        if (gameState == GameState.Graveyard6)
        {
            CountStars(15);
            if (PlayerPrefs.GetInt("LevelReached") < 17)
            {
                PlayerPrefs.SetInt("LevelReached", 17);
            }
        }
        if (gameState == GameState.Graveyard7)
        {
            CountStars(16);
            if (PlayerPrefs.GetInt("LevelReached") < 18)
            {
                PlayerPrefs.SetInt("LevelReached", 18);
            }
        }
        if (gameState == GameState.Graveyard8)
        {
            CountStars(17);
            if (PlayerPrefs.GetInt("LevelReached") < 19)
            {
                PlayerPrefs.SetInt("LevelReached", 19);
            }
        }
        if (gameState == GameState.Graveyard9)
        {
            CountStars(18);
            if (PlayerPrefs.GetInt("LevelReached") < 20)
            {
                PlayerPrefs.SetInt("LevelReached", 20);
            }
        }
        if (gameState == GameState.Graveyard10)
        {
            CountStars(19);
            if (PlayerPrefs.GetInt("LevelReached") < 21)
            {
                PlayerPrefs.SetInt("LevelReached", 21);
            }
        }
        if (gameState == GameState.Castle1)
        {
            CountStars(20);
            if (PlayerPrefs.GetInt("LevelReached") < 22)
            {
                PlayerPrefs.SetInt("LevelReached", 22);
            }
        }
        if (gameState == GameState.Castle2)
        {
            CountStars(21);
            if (PlayerPrefs.GetInt("LevelReached") < 23)
            {
                PlayerPrefs.SetInt("LevelReached", 23);
            }
        }
        if (gameState == GameState.Castle3)
        {
            CountStars(22);
            if (PlayerPrefs.GetInt("LevelReached") < 24)
            {
                PlayerPrefs.SetInt("LevelReached", 24);
            }
        }
        if (gameState == GameState.Castle4)
        {
            CountStars(23);
            if (PlayerPrefs.GetInt("LevelReached") < 25)
            {
                PlayerPrefs.SetInt("LevelReached", 25);
            }
        }
        if (gameState == GameState.Castle5)
        {
            CountStars(24);
            if (PlayerPrefs.GetInt("LevelReached") < 26)
            {
                PlayerPrefs.SetInt("LevelReached", 26);
            }
        }
        if (gameState == GameState.Castle6)
        {
            CountStars(25);
            if (PlayerPrefs.GetInt("LevelReached") < 27)
            {
                PlayerPrefs.SetInt("LevelReached", 27);
            }
        }
        if (gameState == GameState.Castle7)
        {
            CountStars(26);
            if (PlayerPrefs.GetInt("LevelReached") < 28)
            {
                PlayerPrefs.SetInt("LevelReached", 28);
            }
        }
        if (gameState == GameState.Castle8)
        {
            CountStars(27);
            if (PlayerPrefs.GetInt("LevelReached") < 29)
            {
                PlayerPrefs.SetInt("LevelReached", 29);
            }
        }
        if (gameState == GameState.Castle9)
        {
            CountStars(28);
            if (PlayerPrefs.GetInt("LevelReached") < 30)
            {
                PlayerPrefs.SetInt("LevelReached", 30);
            }
        }
        if (gameState == GameState.Castle10)
        {
            CountStars(29);
            if (PlayerPrefs.GetInt("LevelReached") < 31)
            {
                PlayerPrefs.SetInt("LevelReached", 31);
            }
        }
        if (gameState == GameState.Boss)
        {
            CountStars(30);

        }

        int swordBool = doesHaveSword==true ? 1: 0;
        int bootsBool = doesHaveBoots==true ? 1: 0;
        int graveyardChamberBool = isGraveyardChamberOpen==true?1:0;
        int castleChamberBool=isCastleChamberOpen==true? 1:0;
        
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
        PlayerPrefs.SetInt("PlayerCurrentXP", playerCurrentXP);
        PlayerPrefs.SetInt("PlayerTotalXP", playerTotalXP);
        PlayerPrefs.SetInt("PlayerCurrentHP", playerCurrentHP);
        PlayerPrefs.SetInt("PlayerTotalHP", playerTotalHP);
        PlayerPrefs.SetInt("PlayerStrength", playerStrength);
        PlayerPrefs.SetInt("PlayerCurrentStamina", playerCurrentStamina);
        PlayerPrefs.SetInt("PlayerTotalStamina", playerTotalStamina);
        PlayerPrefs.SetInt("PlayerMoves", playerMovesTotal);
        PlayerPrefs.SetInt("PlayerMoney", playerMoney);
        
        PlayerPrefs.SetInt("ForestChamberOpen", 1);
        PlayerPrefs.SetInt("GraveyardChamberOpen", graveyardChamberBool);
        PlayerPrefs.SetInt("CastleChamberOpen", castleChamberBool);
        PlayerPrefs.SetInt("DoesHaveBoots", bootsBool);
        PlayerPrefs.SetInt("DoesHaveSword", swordBool);
        canPressContinueInt = 1;
        PlayerPrefs.SetInt("CanPressContinue", canPressContinueInt);

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

        
        StartCoroutine(BackToStartMenu());
    }

    public void LoseThisMap()
    {
        LoseCanvas.enabled = true;
        GMCanvas.enabled = false;
        StartCoroutine(BackToStartMenu()); 
    }

    IEnumerator BackToStartMenu()
    {
        yield return new WaitForSeconds(0.5f);
        
        Destroy(LoseCanvas.gameObject);
        Destroy(WinCanvas.gameObject);
        Destroy(PauseCanvas.gameObject);
        Destroy(GMCanvas.gameObject);
        //Destroy(TouchCanvas.gameObject);
        Destroy(this.gameObject);
        SceneManager.LoadScene("StartGameMenu");
    }

    public void SkipMoveButton()
    {
        GameObject pl = GameObject.FindGameObjectWithTag("Player");
        if (pl != null)
        {
            if (pl.GetComponent<Player>() == null)
            {
                return;
            }
        }
        else if(pl==null)
        {
            return;
        }

        if (GM.instance.playersTurn)
        {
            // atimam stamina su kiekvienu bandymu eiti !!!!!!
            if (GM.instance.playerCurrentStamina > 0)
            {
                GM.instance.playerCurrentStamina--;
                GM.instance.UpdatePlayerStamina(0);
            }
            else if (GM.instance.playerCurrentStamina <= 0)
            {
                GM.instance.playerCurrentHP--;
                GM.instance.UpdatePlayerHP(0);
                if(GM.instance.playerCurrentHP<=0)
                {
                    if (GM.instance.playerCurrentHP <= 0)
                    {
                        GM.instance.playerCurrentHP = 0; // uzkomentuota tik testinimui
                        GM.instance.LoseThisMap();
                    }
                }
            }


            pl.GetComponent<Player>().movesLeftThisTurn--;
            if (pl.GetComponent<Player>().movesLeftThisTurn > 0)
            {
                GM.instance.playerMovesLeft = pl.GetComponent<Player>().movesLeftThisTurn;
                GM.instance.UpdateMovesLeft(pl.GetComponent<Player>().movesLeftThisTurn);
            }

            if (GM.instance.enemiesList.Count <= 0)
            {
                GM.instance.playersTurn = true;
                if (pl.GetComponent<Player>().movesLeftThisTurn == 0)
                {
                    pl.GetComponent<Player>().movesLeftThisTurn = GM.instance.playerMovesTotal;
                    GM.instance.UpdateMovesLeft(pl.GetComponent<Player>().movesLeftThisTurn);
                }
            }

            else if (pl.GetComponent<Player>().movesLeftThisTurn <= 0)
            {
                GM.instance.playerMovesLeft = pl.GetComponent<Player>().movesLeftThisTurn;
                GM.instance.UpdateMovesLeft(pl.GetComponent<Player>().movesLeftThisTurn);
                GM.instance.playersTurn = false;
                pl.GetComponent<Player>().movesLeftThisTurn = GM.instance.playerMovesTotal;
            }
        }
        GMUpdateStaminaBar();
    }

    public void KillBoss()
    {
        StartCoroutine(KilledBoss());
    }

    public IEnumerator KilledBoss()
    {
        yield return new WaitForSeconds(1.1f);
        GM.instance.enemiesList.Clear();
        GM.instance.WinThisMap();
    }

    public void CountStars(int levvel)
    {
        if (movesUsedInThisLevelForCountingStars < 120)
        {
            PlayerPrefs.SetInt("SetStars" + levvel, 3);
        }
        else if (movesUsedInThisLevelForCountingStars < 140)
        {
            if (PlayerPrefs.GetInt("SetStars" + levvel) > 2)
            {
                return;
            }
            PlayerPrefs.SetInt("SetStars" + levvel, 2);
        }
        else
        {
            if (PlayerPrefs.GetInt("SetStars" + levvel) > 1)
            {
                return;
            }
            PlayerPrefs.SetInt("SetStars" + levvel, 1);
        }
    }

    public void GMUpdateHPBar()
    {
        if (healthBarStat != null)
        {
            healthBarStat.currentValue1 = GM.instance.playerCurrentHP;
            healthBarStat.maxValue1 = GM.instance.playerTotalHP;
            healthBarStat.UpdateValue();
        }        
    }

    public void GMUpdateStaminaBar()
    {
        if (staminaBarStat != null)
        {
            staminaBarStat.currentValue1 = GM.instance.playerCurrentStamina;
            staminaBarStat.maxValue1 = GM.instance.playerTotalStamina;
            staminaBarStat.UpdateValue();
        }
    }

    public void GMUpdateXPBar()
    {
        if (xpBarStat != null)
        {
            xpBarStat.currentValue1 = GM.instance.playerCurrentXP;
            xpBarStat.maxValue1 = GM.instance.playerXPNeededToNextLvl;
            xpBarStat.UpdateValue();
        }
    }

    public void Narrate1OkButton()
    {
        NarateL1.gameObject.SetActive(false);
        NarateL1_1.gameObject.SetActive(true);
    }

    public void Narrate1_1OkButton()
    {
        NarateL1_1.gameObject.SetActive(false);
    }

    public void Narrate51OkButton() 
    {
        NarateL51.gameObject.SetActive(false);
    }


}
