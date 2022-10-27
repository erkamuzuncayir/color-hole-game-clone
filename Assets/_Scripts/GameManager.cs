using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPlayerFailed = false;
    public static bool IsLevelDone = false;
    public static bool IsZoneDone = false;
    public static int WhichZone, AmountOfCollectables;
    // Start is called before the first frame update
    private void Start()
    {
        var collectables = GameObject.FindGameObjectsWithTag("Collectable");
        AmountOfCollectables = collectables.Length;
        WhichZone = 1;
    }

    public void LoadScene()
    {
        ObjectChecker.CollectedAmountOfCollectables = 0;
        SceneManager.LoadScene("Level 1");
    }
    
}
