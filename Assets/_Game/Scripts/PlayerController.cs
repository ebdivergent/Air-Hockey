using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] MovementData _movementData;
    [SerializeField] Rigidbody _characterRb;

    private PlayerSimulation _playerSimulation;

    void Start()
    {
        _playerSimulation = new PlayerSimulation(_movementData);
    }

    void OnMouseDrag()
    {
        Vector3 velocity = _playerSimulation.GetWorldPositionFromMousePosition(Input.mousePosition, gameObject.transform.position, Vector3.zero) - transform.position;
        velocity = velocity * Time.deltaTime * _movementData.MovementSpeed;
        _characterRb.velocity = velocity;
    }

}
