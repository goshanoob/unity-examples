using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    private Camera _camera;
    private const float _timeForDestroy = 5f;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 raysPoint = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(raysPoint);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                StartCoroutine(SphereController(hitInfo.point));
            }
        }
    }
    private IEnumerator SphereController(Vector3 spherePosition)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = spherePosition;
        yield return new WaitForSeconds(_timeForDestroy);
        Destroy(sphere);
    }
    private void OnGUI()
    {
        // Размер прицела.
        float size = 22; 
        // Положение прицела на экране.
        float positionX = _camera.pixelWidth / 2 - size / 4, 
              positionY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(positionX, positionY, size, size), "O");
    }
}
