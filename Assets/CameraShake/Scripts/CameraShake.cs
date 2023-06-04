using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform _camTransform;
    public float _shakeDuration, _shakeRange;
    Vector3 _startPos;

    void Start()
    {
        if (Camera.main != null)
        {
            _camTransform = Camera.main.transform;
            _startPos = _camTransform.position;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < _shakeDuration)
        {
            // Random.insideUnitSphere returns a random point inside a sphere with radius 1 (Read Only).
            _camTransform.position = _startPos + Random.insideUnitSphere * _shakeRange;
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        _camTransform.position = _startPos;
    }


}
