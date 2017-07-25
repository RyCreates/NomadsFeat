using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarsController : MonoBehaviour
{
    //public int totalLevels;

    //public int StarsL1 = 0;
    //public int StarsL2 = 0;
    //public int StarsL3 = 0;
    //public int StarsL4 = 0;
    //public int StarsL5 = 0;
    //public int StarsL6 = 0;
    //public int StarsL7 = 0;
    //public int StarsL8 = 0;
    //public int StarsL9 = 0;
    //public int StarsL10 = 0;
    //public int StarsL11 = 0;
    //public int StarsL12 = 0;
    //public int StarsL13 = 0;
    //public int StarsL14 = 0;
    //public int StarsL15 = 0;
    //public int StarsL16 = 0;
    //public int StarsL17 = 0;
    //public int StarsL18 = 0;
    //public int StarsL19 = 0;
    //public int StarsL20 = 0;
    //public int StarsL21 = 0;
    //public int StarsL22 = 0;
    //public int StarsL23 = 0;
    //public int StarsL24 = 0;
    //public int StarsL25 = 0;
    //public int StarsL26 = 0;
    //public int StarsL27 = 0;
    //public int StarsL28 = 0;
    //public int StarsL29 = 0;
    //public int StarsL30 = 0;
    //public int StarsL31 = 0;

    //public Image L1Star1;
    //public Image L1Star2;
    //public Image L1Star3;
    //public Image L2Star1;
    //public Image L2Star2;
    //public Image L2Star3;
    //public Image L3Star1;
    //public Image L3Star2;
    //public Image L3Star3;
    //public Image L4Star1;
    //public Image L4Star2;
    //public Image L4Star3;
    //public Image L5Star1;
    //public Image L5Star2;
    //public Image L5Star3;
    //public Image L6Star1;
    //public Image L6Star2;
    //public Image L6Star3;
    //public Image L7Star1;
    //public Image L7Star2;
    //public Image L7Star3;
    //public Image L8Star1;
    //public Image L8Star2;
    //public Image L8Star3;
    //public Image L9Star1;
    //public Image L9Star2;
    //public Image L9Star3;
    //public Image L10Star1;
    //public Image L10Star2;
    //public Image L10Star3;
    //public Image L11Star1;
    //public Image L11Star2;
    //public Image L11Star3;
    //public Image L12Star1;
    //public Image L12Star2;
    //public Image L12Star3;
    //public Image L13Star1;
    //public Image L13Star2;
    //public Image L13Star3;
    //public Image L14Star1;
    //public Image L14Star2;
    //public Image L14Star3;
    //public Image L15Star1;
    //public Image L15Star2;
    //public Image L15Star3;
    //public Image L16Star1;
    //public Image L16Star2;
    //public Image L16Star3;
    //public Image L17Star1;
    //public Image L17Star2;
    //public Image L17Star3;
    //public Image L18Star1;
    //public Image L18Star2;
    //public Image L18Star3;
    //public Image L19Star1;
    //public Image L19Star2;
    //public Image L19Star3;
    //public Image L20Star1;
    //public Image L20Star2;
    //public Image L20Star3;
    //public Image L21Star1;
    //public Image L21Star2;
    //public Image L21Star3;
    //public Image L22Star1;
    //public Image L22Star2;
    //public Image L22Star3;
    //public Image L23Star1;
    //public Image L23Star2;
    //public Image L23Star3;
    //public Image L24Star1;
    //public Image L24Star2;
    //public Image L24Star3;
    //public Image L25Star1;
    //public Image L25Star2;
    //public Image L25Star3;
    //public Image L26Star1;
    //public Image L26Star2;
    //public Image L26Star3;
    //public Image L27Star1;
    //public Image L27Star2;
    //public Image L27Star3;
    //public Image L28Star1;
    //public Image L28Star2;
    //public Image L28Star3;
    //public Image L29Star1;
    //public Image L29Star2;
    //public Image L29Star3;
    //public Image L30Star1;
    //public Image L30Star2;
    //public Image L30Star3;
    //public Image L31Star1;
    //public Image L31Star2;
    //public Image L31Star3;

    //void Start ()
    //{
    //    totalLevels = 31;

    //    for(int a = 1; a < totalLevels+1; a++)
    //    {

    //    }

    //    StarsL1 = PlayerPrefs.GetInt("L1Stars");

    //    if(StarsL1==0)
    //    {
    //        L1Star1.enabled = false;
    //        L1Star2.enabled = false;
    //        L1Star3.enabled = false;
    //    }
    //    else if (StarsL1 == 1)
    //    {
    //        L1Star1.enabled = true;
    //        L1Star2.enabled = false;
    //        L1Star3.enabled = false;
    //    }
    //    else if (StarsL1 == 2)
    //    {
    //        L1Star1.enabled = true;
    //        L1Star2.enabled = true;
    //        L1Star3.enabled = false;
    //    }
    //    else if (StarsL1 == 3)
    //    {
    //        L1Star1.enabled = true;
    //        L1Star2.enabled = true;
    //        L1Star3.enabled = true;
    //    }

    //    StarsL2 = PlayerPrefs.GetInt("L2Stars");

    //    if (StarsL2 == 0)
    //    {
    //        L2Star1.enabled = false;
    //        L2Star2.enabled = false;
    //        L2Star3.enabled = false;
    //    }
    //    else if (StarsL2 == 1)
    //    {
    //        L2Star1.enabled = true;
    //        L2Star2.enabled = false;
    //        L2Star3.enabled = false;
    //    }
    //    else if (StarsL2 == 2)
    //    {
    //        L2Star1.enabled = true;
    //        L2Star2.enabled = true;
    //        L2Star3.enabled = false;
    //    }
    //    else if (StarsL2 == 3)
    //    {
    //        L2Star1.enabled = true;
    //        L2Star2.enabled = true;
    //        L2Star3.enabled = true;
    //    }
    //}
            

    

    public int totalLevels = 31;

    public Image[] Stars1;
    public Image[] Stars2;
    public Image[] Stars3;

    public int[] starsL;

    void Start()
    {
        //for (int i = 1; i < totalLevels + 1; i++)
        //{
        //    PlayerPrefs.SetInt("SetStars" + i, starsL[i]);
        //}
        
        if(PlayerStats.isNewGameStarted)
        {
            for (int i = 0; i < totalLevels; i++)
            {
                //starsL[i] = PlayerPrefs.GetInt("SetStars" + i);

                
                    Stars1[i].enabled = false;
                    Stars2[i].enabled = false;
                    Stars3[i].enabled = false;
                
            }
            return;
        }


        for (int i = 0; i < totalLevels; i++)
        {
            starsL[i] = PlayerPrefs.GetInt("SetStars" + i);

            if (starsL[i]==0)
            {
                Stars1[i].enabled = false;
                Stars2[i].enabled = false;
                Stars3[i].enabled = false; 
            }
            if (starsL[i] == 1)
            {
                Stars1[i].enabled = true;
                Stars2[i].enabled = false;
                Stars3[i].enabled = false;
            }
            if (starsL[i] == 2)
            {
                Stars1[i].enabled = true;
                Stars2[i].enabled = true;
                Stars3[i].enabled = false;
            }
            if (starsL[i] == 3)
            {
                Stars1[i].enabled = true;
                Stars2[i].enabled = true;
                Stars3[i].enabled = true;
            }
        }
    }



}
