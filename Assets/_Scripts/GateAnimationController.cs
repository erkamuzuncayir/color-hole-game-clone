using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _gate = null;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.WhichZone == 0)
        {
            _gate.Play("Gate Animation");
        }
    }
}