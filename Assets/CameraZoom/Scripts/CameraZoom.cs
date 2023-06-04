using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera _camera;
    
    public int _zoomSpeed2D;
    public int _minZoom2D, _maxZoom2D;
    
    public int _zoomSpeed3D;
    public int _minZoom3D, _maxZoom3D;

    private void Awake()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // 2D Camera
        if (_camera.orthographic)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {   // zoom in
                _camera.orthographicSize -= _zoomSpeed2D * Time.deltaTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {   // zoom out 
                _camera.orthographicSize += _zoomSpeed2D * Time.deltaTime;
            }
            _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minZoom2D, _maxZoom2D);
        }
        // 3D Camera
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {   // zoom in
                _camera.fieldOfView -= _zoomSpeed3D * Time.deltaTime;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {   // zoom out 
                _camera.fieldOfView += _zoomSpeed3D * Time.deltaTime;
            }
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _minZoom3D, _maxZoom3D);
        }
    }
}
