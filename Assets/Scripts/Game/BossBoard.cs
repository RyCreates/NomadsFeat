using UnityEngine;
using System.Collections.Generic;

public class BossBoard : BaseBoard
{

    public int mapLevel;
    
    Count enemyNumber = new Count(2, 2);

    public GameObject bossPref;


    protected override void Start()
    {
        mapLevel = GM.instance.chamber;
        mapHeight = 7;
        mapWidth = 7;
        base.Start();
        CreateBoss();
    }

    protected override void InstantiateMap()
    {
        base.InstantiateMap();
    }

    void CreateBoss()
    {
        GameObject ex = GameObject.FindGameObjectWithTag("Exit");
        if(ex==null)
        {

        }
        else if(ex!=null)
        {
            Destroy(ex.gameObject);
        }

        GameObject enem1 = (GameObject)Instantiate(enemyPrefs[0], new Vector2(4, 1), Quaternion.identity);
        GameObject enem2 = (GameObject)Instantiate(enemyPrefs[0], new Vector2(1, 4), Quaternion.identity); 
        GameObject Boss = (GameObject)Instantiate(bossPref, new Vector2(mapHeight-1, mapWidth-1), Quaternion.Euler(0,180,0));
    }
}
