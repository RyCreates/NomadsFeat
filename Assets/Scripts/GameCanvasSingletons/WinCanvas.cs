using UnityEngine;
using System.Collections;

public class WinCanvas : MonoBehaviour {

    public static WinCanvas wc;

    void Awake()
    {
        if (wc == null)
        {
            wc = this;
        }
        else if (wc != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
