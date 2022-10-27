using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoToNextZone : MonoBehaviour
{
    public GameObject mainCamera;
    private SphereCollider _holeCollider;
    public Vector3 offset;
    private bool _goNextZone;
    private bool _cameraMove;
    private readonly float _speed = 10;
    private List<GameObject> _crossoverCollectableList = new List<GameObject>();

    private void Start()
    {
        _holeCollider = gameObject.GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherGameObject = other.gameObject;
        if (otherGameObject.CompareTag("CrossoverCollectable"))
        {
            other.isTrigger = true;
            other.attachedRigidbody.AddForce(Vector3.down * 30,ForceMode.Impulse);
            _crossoverCollectableList.Add(otherGameObject);
        }
    }

    private void Update()
    {
        if (GameManager.IsZoneDone)
        {
            GameManager.WhichZone = 0;
            _holeCollider.radius = 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * 3);
            if (transform.position.x > -0.1 && transform.position.x < 0.1 &&
                transform.position.z > -0.1 && transform.position.z < 0.1)
            {
                transform.position = Vector3.zero;
                _cameraMove = true;
                _goNextZone = true;
            }
        }

        if (transform.position.z >= 23)
        {
            GameManager.WhichZone = 2;
            _cameraMove = false;
            _goNextZone = false;
            foreach (var c in _crossoverCollectableList)
            {
                c.SetActive(false);
            }
        }

        if (_goNextZone)
        {
            GameManager.IsZoneDone = false;
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(0, 0, 23), Time.deltaTime * _speed);
        }
    }

    private void LateUpdate()
    {
        if (_cameraMove)
        {
            mainCamera.transform.position = transform.position + offset;
        }
    }
}