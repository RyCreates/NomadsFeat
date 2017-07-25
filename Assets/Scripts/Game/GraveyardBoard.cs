using UnityEngine;
using System.Collections;

public class GraveyardBoard : BaseBoard {

    [SerializeField]
    protected GameObject[] bootsPref;

    public int mapLevel; 

    Count foodNumber = new Count(0, 1);
    Count enemyNumber = new Count(2, 4);
    Count staminaNumber = new Count(1, 3);
    Count moneyNumber = new Count(0, 2);
    Count innerWallsNumber = new Count(4, 7);


    protected override void Start()
    {
        mapLevel = GM.instance.chamber;
        mapHeight = 8;
        mapWidth = 10;
        base.Start();

        if (GM.instance.chamber == 55 && !GM.instance.doesHaveBoots)
        {
            CreateStuff(bootsPref, 1, 1);
        }
    }

    protected override void InstantiateMap()
    {
        base.InstantiateMap();
        CreateStuff(foodPrefs, foodNumber.min, foodNumber.max);
        int enemyCount = (int)Mathf.Log(mapLevel, 2f);
        CreateStuff(enemyPrefs, enemyCount, enemyCount);
        CreateStuff(staminaPrefs, staminaNumber.min, staminaNumber.max);
        CreateStuff(moneyPrefs, moneyNumber.min, moneyNumber.max);
        CreateStuff(innerWallPrefs, innerWallsNumber.min, innerWallsNumber.max);
    }
}
