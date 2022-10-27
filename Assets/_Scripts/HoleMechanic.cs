using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class HoleMechanic : MonoBehaviour
{
    public PolygonCollider2D hole2DCollider;
    public PolygonCollider2D ground2DCollider;
    public MeshCollider generatedMeshCollider;
    public Collider groundOneCollider;
    public Collider groundTwoCollider;
    public Collider crossOverCollider;
    public float initialScale = 0.5f;
    private Mesh _generatedMesh;
    private bool _isGeneratedMeshNotNull;

    private void Start()
    {
        _isGeneratedMeshNotNull = _generatedMesh != null;
        GameObject[] allGOs = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (var go in allGOs)
        {
            if (go.layer == LayerMask.NameToLayer("Obstacles"))
            { 
                Physics.IgnoreCollision(go.GetComponent<Collider>(), generatedMeshCollider,true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(other,groundOneCollider, true);
        Physics.IgnoreCollision(other,groundTwoCollider, true);
        Physics.IgnoreCollision(other,crossOverCollider, true);
        Physics.IgnoreCollision(other,generatedMeshCollider, false);
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(other,groundOneCollider, false);
        Physics.IgnoreCollision(other,groundTwoCollider, false);
        Physics.IgnoreCollision(other,crossOverCollider , false);
        Physics.IgnoreCollision(other,generatedMeshCollider, true);
    }
    private void FixedUpdate()
    {
        if (transform.hasChanged == true)
        {
            transform.hasChanged = false;
            hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
            hole2DCollider.transform.localScale = transform.localScale * initialScale;
            MakeHole2D();
            Make3DMeshCollider();
        }
    }

    public void MakeHole2D()
    {
        Vector2[] pointPositions = hole2DCollider.GetPath(0);
        for (int i = 0; i < pointPositions.Length; i++)
        {
            pointPositions[i] = hole2DCollider.transform.TransformPoint(pointPositions[i]);
        }

        ground2DCollider.pathCount = 2;
        ground2DCollider.SetPath(1, pointPositions);
    }

    void Make3DMeshCollider()
    {
        if(_isGeneratedMeshNotNull) Destroy(_generatedMesh);
        _generatedMesh = ground2DCollider.CreateMesh(true, true);
        generatedMeshCollider.sharedMesh = _generatedMesh;
    }
}
