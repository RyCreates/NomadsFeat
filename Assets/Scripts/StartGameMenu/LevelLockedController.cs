using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLockedController : MonoBehaviour {

    public Button L1;
    public Button L2;
    public Button L3;
    public Button L4;
    public Button L5;
    public Button L6;
    public Button L7;
    public Button L8;
    public Button L9;
    public Button L10;
    public Button L11;
    public Button L12;
    public Button L13;
    public Button L14;
    public Button L15;
    public Button L16;
    public Button L17;
    public Button L18;
    public Button L19;
    public Button L20;
    public Button L21;
    public Button L22;
    public Button L23;
    public Button L24;
    public Button L25;
    public Button L26;
    public Button L27;
    public Button L28;
    public Button L29;
    public Button L30;
    public Button L31;

    public Image I1;
    public Image I2;
    public Image I3;
    public Image I4;
    public Image I5;
    public Image I6;
    public Image I7;
    public Image I8;
    public Image I9;
    public Image I10;
    public Image I11;
    public Image I12; 
    public Image I13;
    public Image I14;
    public Image I15;
    public Image I16;
    public Image I17;
    public Image I18;
    public Image I19;
    public Image I20;
    public Image I21;
    public Image I22;
    public Image I23;
    public Image I24;
    public Image I25;
    public Image I26;
    public Image I27;
    public Image I28;
    public Image I29;
    public Image I30;
    public Image I31;

    public int levelReached;

    void Start ()
    {
        L1.gameObject.SetActive(true);
        I1.enabled = false;

        L2.gameObject.SetActive(false);
        I2.enabled = true;

        L3.gameObject.SetActive(false);
        I3.enabled = true;

        L4.gameObject.SetActive(false);
        I4.enabled = true;

        L5.gameObject.SetActive(false);
        I5.enabled = true;

        L6.gameObject.SetActive(false);
        I6.enabled = true;

        L7.gameObject.SetActive(false);
        I7.enabled = true;

        L8.gameObject.SetActive(false);
        I8.enabled = true;

        L9.gameObject.SetActive(false);
        I9.enabled = true;

        L10.gameObject.SetActive(false);
        I10.enabled = true;

        L11.gameObject.SetActive(false);
        I11.enabled = true;

        L12.gameObject.SetActive(false);
        I12.enabled = true;

        L13.gameObject.SetActive(false);
        I13.enabled = true;

        L14.gameObject.SetActive(false);
        I14.enabled = true;

        L15.gameObject.SetActive(false);
        I15.enabled = true;

        L16.gameObject.SetActive(false);
        I16.enabled = true;

        L17.gameObject.SetActive(false);
        I17.enabled = true;

        L18.gameObject.SetActive(false);
        I18.enabled = true;

        L19.gameObject.SetActive(false);
        I19.enabled = true;

        L20.gameObject.SetActive(false);
        I20.enabled = true;

        L21.gameObject.SetActive(false);
        I21.enabled = true;

        L22.gameObject.SetActive(false);
        I22.enabled = true;

        L23.gameObject.SetActive(false);
        I23.enabled = true;

        L24.gameObject.SetActive(false);
        I24.enabled = true;

        L25.gameObject.SetActive(false);
        I25.enabled = true;

        L26.gameObject.SetActive(false);
        I26.enabled = true;

        L27.gameObject.SetActive(false);
        I27.enabled = true;

        L28.gameObject.SetActive(false);
        I28.enabled = true;

        L29.gameObject.SetActive(false);
        I29.enabled = true;

        L30.gameObject.SetActive(false);
        I30.enabled = true;

        L31.gameObject.SetActive(false);
        I31.enabled = true;

        levelReached = PlayerPrefs.GetInt("LevelReached");
        if(PlayerStats.isNewGameStarted)
        {
            levelReached = 1;
        }

        if (levelReached>1)
        {
            L2.gameObject.SetActive(true);
            I2.enabled = false;
        }
        if (levelReached > 2)
        {
            L3.gameObject.SetActive(true);
            I3.enabled = false;
        }
        if (levelReached > 3)
        {
            L4.gameObject.SetActive(true);
            I4.enabled = false;
        }
        if (levelReached > 4)
        {
            L5.gameObject.SetActive(true);
            I5.enabled = false;
        }
        if (levelReached > 5)
        {
            L6.gameObject.SetActive(true);
            I6.enabled = false;
        }
        if (levelReached > 6)
        {
            L7.gameObject.SetActive(true);
            I7.enabled = false;
        }
        if (levelReached > 7)
        {
            L8.gameObject.SetActive(true);
            I8.enabled = false;
        }
        if (levelReached > 8)
        {
            L9.gameObject.SetActive(true);
            I9.enabled = false;
        }
        if (levelReached > 9)
        {
            L10.gameObject.SetActive(true);
            I10.enabled = false;
        }
        if (levelReached > 10)
        {
            L11.gameObject.SetActive(true);
            I11.enabled = false;
        }
        if (levelReached > 11)
        {
            L12.gameObject.SetActive(true);
            I12.enabled = false;
        }
        if (levelReached > 12)
        {
            L13.gameObject.SetActive(true);
            I13.enabled = false;
        }
        if (levelReached > 13)
        {
            L14.gameObject.SetActive(true);
            I14.enabled = false;
        }
        if (levelReached > 14)
        {
            L15.gameObject.SetActive(true);
            I15.enabled = false;
        }
        if (levelReached > 15)
        {
            L16.gameObject.SetActive(true);
            I16.enabled = false;
        }
        if (levelReached > 16)
        {
            L17.gameObject.SetActive(true);
            I17.enabled = false;
        }
        if (levelReached > 17)
        {
            L18.gameObject.SetActive(true);
            I18.enabled = false;
        }
        if (levelReached > 18)
        {
            L19.gameObject.SetActive(true);
            I19.enabled = false;
        }
        if (levelReached > 19)
        {
            L20.gameObject.SetActive(true);
            I20.enabled = false;
        }
        if (levelReached > 20)
        {
            L21.gameObject.SetActive(true);
            I21.enabled = false;
        }
        if (levelReached > 21)
        {
            L22.gameObject.SetActive(true);
            I22.enabled = false;
        }
        if (levelReached > 22)
        {
            L23.gameObject.SetActive(true);
            I23.enabled = false;
        }
        if (levelReached > 23)
        {
            L24.gameObject.SetActive(true);
            I24.enabled = false;
        }
        if (levelReached > 24)
        {
            L25.gameObject.SetActive(true);
            I25.enabled = false;
        }
        if (levelReached > 25)
        {
            L26.gameObject.SetActive(true);
            I26.enabled = false;
        }
        if (levelReached > 26)
        {
            L27.gameObject.SetActive(true);
            I27.enabled = false;
        }
        if (levelReached > 27)
        {
            L28.gameObject.SetActive(true);
            I28.enabled = false;
        }
        if (levelReached > 28)
        {
            L29.gameObject.SetActive(true);
            I29.enabled = false;
        }
        if (levelReached > 29)
        {
            L30.gameObject.SetActive(true);
            I30.enabled = false;
        }
        if (levelReached > 30)
        {
            L31.gameObject.SetActive(true);
            I31.enabled = false;
        }
    }
	
}
