using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantForceModifier : MonoBehaviour
{
    private ConstantForce _constantForce;

    // Start is called before the first frame update
    void Start()
    {
        _constantForce = GetComponent<ConstantForce>();
    }


    // Update is called once per frame
    void Update()
    {
        _constantForce.force = ObjectChecker.CollectedAmountOfCollectables < 5 ? Vector3.zero : new Vector3(0, -100, 0);
    }
}