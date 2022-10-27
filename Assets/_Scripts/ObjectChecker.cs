using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectChecker : MonoBehaviour
{
    public static int CollectedAmountOfCollectables;
    private void OnCollisionEnter(Collision collision)
    {
        var collidedObject = collision.gameObject;
        var collidedObjectTag = collidedObject.tag;
        switch (collidedObjectTag)
        {
            case "Collectable":
                CollectedAmountOfCollectables++;
                if (CollectedAmountOfCollectables == 36)
                {
                    GameManager.IsZoneDone = true;
                }
                if (GameManager.AmountOfCollectables == CollectedAmountOfCollectables)
                {
                    GameManager.IsLevelDone = true;
                }
                Destroy(collidedObject);
                break;
            case "Obstacle":
                GameManager.IsPlayerFailed = true;
                break;
        }
        
    }
}