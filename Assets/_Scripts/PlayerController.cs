using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _xAxis, _yAxis;
    private Vector3 _touchPosition;
    private Vector3 _touchDirection;
    private Touch _touch;
    [SerializeField] private float mouseMoveSpeed = 15f;
    [SerializeField] private float touchSpeed = 0.010f;
    private static bool _inputType;

    // Start is called before the first frame update
    void Start()
    {
        MouseMoveHole();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_inputType)
        {
            TouchMoveHole();
        }
        else
        {
            MouseMoveHole();
        }
    }

    void TouchMoveHole()
    {
        if (Input.touchCount > 0 && !GameManager.IsZoneDone)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                /*
                 Similar and usable another approach:
                 
                _touchPosition.x = _touch.deltaPosition.x;
                _touchPosition.z = _touch.deltaPosition.y;
                _touchDirection = Vector3.Lerp(transform.position, transform.position + _touchPosition, _moveSpeed * Time.deltaTime);
                transform.position = _touchDirection;
                
                if (_touch.phase == TouchPhase.Ended)
                {
                    transform.position = transform.position;
                }
                */
                var position = transform.position;
                _touchDirection = new Vector3(position.x + _touch.deltaPosition.x * touchSpeed,
                    position.y, position.z + _touch.deltaPosition.y * touchSpeed);
                position = _touchDirection;
                if (GameManager.WhichZone == 1 && position.x > -3.24 && position.x < 3.26 && position.z > -6.24 &&
                    position.z < 6.26)
                {
                    transform.position = position;
                }
                else if (GameManager.WhichZone == 2 && position.x > -3.24 && position.x < 3.26 && position.z > 21.74 &&
                         position.z < 34.26)
                {
                    transform.position = position;
                }
            }
        }
    }

    void MouseMoveHole()
    {
        if (!GameManager.IsZoneDone)
        {
            _xAxis = Input.GetAxis("Mouse X");
            _yAxis = Input.GetAxis("Mouse Y");
            var direction = new Vector3(_xAxis, 0f, _yAxis);
            var holePosition = transform.position;
            holePosition = Vector3.Lerp(holePosition, holePosition + direction, mouseMoveSpeed * Time.deltaTime);
            if (GameManager.WhichZone == 1 && holePosition.x > -3.24 && holePosition.x < 3.26 &&
                holePosition.z > -6.24 &&
                holePosition.z < 6.26)
            {
                transform.position = holePosition;
            }
            else if (GameManager.WhichZone == 2 && holePosition.x > -3.24 && holePosition.x < 3.26 &&
                     holePosition.z > 21.74 &&
                     holePosition.z < 34.26)
            {
                transform.position = holePosition;
            }
        }
    }

    public void ChangeInputSystem()
    {
        _inputType = !_inputType;
    }
}