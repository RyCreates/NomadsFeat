using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    //---------------------------------------------------------------------------------------


    
    public static bool isNewGameStarted;
    public static int playerStats_Level;
    public static int playerStats_CurrentXp;  // xp gained in this level
    public static int playerStats_TotalXp;    // xp gained in all levels
    public static int playerStats_CurrentHP;
    public static int playerStats_TotalHP;
    public static int playerStats_Strength;
    public static int playerStats_TotalStamina;
    public static int playerStats_CurrentStamina; 
    public static int playerStats_Moves;
    public static int playerStats_Money;

    public static int playerStats_intIsForestChamberOpen;
    public static int playerStats_intIsGraveyardChamberOpen;
    public static int playerStats_intIsCastleChamberOpen;
    public static int playerStats_intDoesHaveBoots; // + 2 Moves
    public static int playerStats_intDoesHaveSword; // + 5 Attack 
    
    public static bool playerStats_isForestChamberOpen;
    public static bool playerStats_isGraveyardChamberOpen; 
    public static bool playerStats_isCastleChamberOpen;
    public static bool playerStats_doesHaveBoots; // + 2 Moves
    public static bool playerStats_doesHaveSword; // + 5 Attack

    //---------------------------------------------------------------------------------------

        //nereikalingi

    //public static int playerStats_Continue_Level;
    //public static int playerStats_Continue_CurrentXp;  // xp gained in this level
    //public static int playerStats_Continue_TotalXp;    // xp gained in all levels
    //public static int playerStats_Continue_CurrentHP;
    //public static int playerStats_Continue_TotalHP;
    //public static int playerStats_Continue_Strength;
    //public static int playerStats_Continue_TotalStamina;
    //public static int playerStats_Continue_CurrentStamina;
    //public static int playerStats_Continue_Moves;
    //public static int playerStats_Continue_Money;

    //public static int playerStats_Continue_intIsForestChamberOpen;
    //public static int playerStats_Continue_intIsGraveyardChamberOpen;
    //public static int playerStats_Continue_intIsCastleChamberOpen;
    //public static int playerStats_Continue_intDoesHaveBoots; // + 2 Moves
    //public static int playerStats_Continue_intDoesHaveSword; // + 5 Attack 

    //public static bool playerStats_Continue_isForestChamberOpen;
    //public static bool playerStats_Continue_isGraveyardChamberOpen;
    //public static bool playerStats_Continue_isCastleChamberOpen;
    //public static bool playerStats_Continue_doesHaveBoots; // + 2 Moves
    //public static bool playerStats_Continue_doesHaveSword; // + 5 Attack

    //---------------------------------------------------------------------------------------

    public static int playerStats_New_Level = 1;
    public static int playerStats_New_CurrentXp = 0;  // xp gained in this level
    public static int playerStats_New_TotalXp = 0;    // xp gained in all levels
    public static int playerStats_New_CurrentHP = 100;
    public static int playerStats_New_TotalHP = 100;
    public static int playerStats_New_Strength = 0;
    public static int playerStats_New_TotalStamina = 70;
    public static int playerStats_New_CurrentStamina = 70;
    public static int playerStats_New_Moves = 2; // imposible su 1
    public static int playerStats_New_Money = 10;

    public static int playerStats_New_intIsForestChamberOpen = 0;                  // 0 = false , 1 = true
    public static int playerStats_New_intIsGraveyardChamberOpen = 0;
    public static int playerStats_New_intIsCastleChamberOpen = 0;
    public static int playerStats_New_intDoesHaveBoots = 0; // + 2 Moves
    public static int playerStats_New_intDoesHaveSword = 0; // + 5 Attack  

    public static bool playerStats_New_isForestChamberOpen = true;
    public static bool playerStats_New_isGraveyardChamberOpen = false; 
    public static bool playerStats_New_isCastleChamberOpen = false;
    public static bool playerStats_New_doesHaveBoots = false; // + 2 Moves
    public static bool playerStats_New_doesHaveSword = false; // + 5 Attack
    


    void Start ()
    {

    }
}
