using UnityEngine;
using System.Collections;

public class PauseGameCanvas : MonoBehaviour
{

    public static PauseGameCanvas pgc;

    void Awake()
    {
        if (pgc == null)
        {
            pgc = this;
        }
        else if (pgc != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
