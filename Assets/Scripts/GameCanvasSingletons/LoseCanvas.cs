using UnityEngine;
using System.Collections;

public class LoseCanvas : MonoBehaviour {

    public static LoseCanvas lc;

    void Awake()
    {
        if (lc == null)
        {
            lc = this;
        }
        else if (lc != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
