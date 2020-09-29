using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSimulation
{
    private MovementData _playerData;
    private Camera _mainCamera;

    public PlayerSimulation(MovementData playerData)
    {
        _playerData = playerData;
        _mainCamera = Camera.main;
    }

    public Vector3 GetWorldPositionFromMousePosition(Vector3 mousePos, Vector3 playerPos, Vector3 PlanePosition)
    {
        mousePos.z = playerPos.z;

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = _mainCamera.ScreenPointToRay(mousePos);

        float enter = 0;
        if(plane.Raycast(ray, out enter))
            return ray.GetPoint(enter);
        else
            return Vector3.zero; //Camera.main.ScreenToWorldPoint(mousePos);
    }

}
