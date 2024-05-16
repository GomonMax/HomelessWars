using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ResizeCameraToObjectFit : MonoBehaviour
{
    [SerializeField] private float _initialSize;
    [SerializeField] private float _targetAspect = 1.77777f;
    [SerializeField] private Camera _camera;

    private void Start()
    {
        _camera.orthographicSize = _initialSize * (_targetAspect / _camera.aspect);
    }
}
