using UnityEngine;
using System.Collections;

public class CastleBoard : BaseBoard {

    

    public int mapLevel;

    Count foodNumber = new Count(1, 2);
    Count enemyNumber = new Count(2, 4);
    Count staminaNumber = new Count(1, 3);
    Count moneyNumber = new Count(1, 2);
    Count innerWallsNumber = new Count(4, 6);


    protected override void Start()
    {
        mapLevel = GM.instance.chamber;
        mapHeight = 9;
        mapWidth = 12;
        base.Start();

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
