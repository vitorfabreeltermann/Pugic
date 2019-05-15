using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour {

    public Transform next;

    private static readonly LevelSetter LS = new LevelSetter();

    // Use this for initialization
    void Start () {
        if (PlayerPrefs.GetInt("this_level") == 40)
			next.position = new Vector3(999, 999, -999);
	}

    public void Next()
    {
        LS.SetLevel(PlayerPrefs.GetInt("this_level") + 1);
    }
}
