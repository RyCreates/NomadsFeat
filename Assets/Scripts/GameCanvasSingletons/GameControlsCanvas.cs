using UnityEngine;
using System.Collections;

public class GameControlsCanvas : MonoBehaviour
{
    public static GameControlsCanvas gcc;

    void Awake()
    {
        if(gcc==null)
        {
            gcc = this;
        }
        else if(gcc != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
	
}
