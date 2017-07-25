using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BaseBoard : MonoBehaviour
{
    public class Count
    {
       public int min;
       public int max;

       public Count(int minimum, int maximum)
       {
           min = minimum;
           max = maximum;
       }
    }


    private List<Vector3> gridList = new List<Vector3>();

    protected int mapHeight = 8;
    protected int mapWidth = 9;

    [SerializeField]
    private GameObject exitPrefab;
    [SerializeField]
    private GameObject[] floorPrefs;
    [SerializeField]
    protected GameObject[] innerWallPrefs;
    [SerializeField]
    private GameObject[] outerWallPrefs;
    [SerializeField]
    protected GameObject[] enemyPrefs;
    [SerializeField]
    protected GameObject[] staminaPrefs;
    [SerializeField]
    protected GameObject[] moneyPrefs;
    [SerializeField]
    protected GameObject[] foodPrefs;

    public Transform board;

	protected virtual void Start ()
    {
        board = new GameObject("Board").transform;
        InstantiateMap();
    }
	
    protected virtual void InstantiateMap() 
    {
        CreateGrid();
        CreateFloorAndWalls();
        
    }

	void CreateGrid()
    {
        for(int x =1; x<mapWidth-1;x++)
        {
            for(int y=1; y<mapHeight-1;y++)
            {
                Vector3 gridTile = new Vector3(x, y, 0);
                gridList.Add(gridTile);
            }
        }
    }

	void CreateFloorAndWalls()
    {
        for(int x = -1; x < mapWidth+1; x++ )
        {
            for(int y = -1; y<mapHeight+1; y++)
            {
                if (x == -1 || x == mapWidth || y == -1 || y == mapHeight)
                {
                    int outerWallIndex = Random.Range(0, outerWallPrefs.Length);
                    GameObject g = (GameObject)Instantiate(outerWallPrefs[outerWallIndex], new Vector3(x, y, 0), Quaternion.identity);
                    g.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    g.transform.SetParent(board);
                }
                else 
                {
                    int floorIndex = Random.Range(0, floorPrefs.Length);
                    GameObject g = (GameObject)Instantiate(floorPrefs[floorIndex], new Vector3(x, y, 0), Quaternion.identity);
                    g.GetComponent<SpriteRenderer>().sortingOrder = 0;
                    g.transform.SetParent(board);
                }                
            }
        }
        if(GM.instance.chamber==151)
        {
            return;
        }

        //instantiate exit prefab
        GameObject gg = (GameObject)Instantiate(exitPrefab, new Vector3(mapWidth - 1, mapHeight - 1, 0), Quaternion.identity);
        gg.GetComponent<SpriteRenderer>().sortingOrder = 1;
        gg.transform.SetParent(board);
    }

    Vector3 RandomPosition()
    {
        int randomPosIndex = Random.Range(0, gridList.Count);
        Vector3 position = gridList[randomPosIndex];
        gridList.RemoveAt(randomPosIndex);
        return position;
    }

    protected void CreateStuff(GameObject[] g, int min, int max)
    {
        int numberOfGameObjects = Random.Range(min, max);
        for(int a =0; a< numberOfGameObjects;a++)
        {
            int gIndex = Random.Range(0, g.Length);
            GameObject go = (GameObject)Instantiate(g[gIndex], RandomPosition(), Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sortingOrder = 1;
            go.transform.SetParent(board);
        }
    }
    

}
