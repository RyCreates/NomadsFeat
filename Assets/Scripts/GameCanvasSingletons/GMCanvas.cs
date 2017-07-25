using UnityEngine;
using System.Collections;

public class GMCanvas : MonoBehaviour {


    public static GMCanvas gmc;

    void Awake()
    {
        if (gmc == null)
        {
            gmc = this;
        }
        else if (gmc != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
