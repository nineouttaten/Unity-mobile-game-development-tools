using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    public float speed = 3.5f;
    private float X;
    private float Y;
    
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private FixedJoystick _joystick;

    private void Start()
    {
        if (!_joystick)
        {
            _joystick = new FixedJoystick();
        }
    }

    void Update() {
        Debug.Log(_joystick.Horizontal);
        Debug.Log(_joystick.Vertical);
        if(Input.GetMouseButton(0) && _joystick.Horizontal == 0 && _joystick.Vertical == 0) {
            _cameraTransform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }
    }
}
