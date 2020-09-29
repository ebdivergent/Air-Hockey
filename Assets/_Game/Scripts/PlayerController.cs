using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] MovementData _playerData;
    [SerializeField] Rigidbody _characterRb;

    private PlayerSimulation _playerSimulation;

    void Start()
    {
        _playerSimulation = new PlayerSimulation(_playerData);
    }

    void OnMouseDrag()
    {
        Vector3 velocity = _playerSimulation.GetWorldPositionFromMousePosition(Input.mousePosition, gameObject.transform.position, Vector3.zero) - transform.position;
        velocity = velocity * Time.deltaTime * _playerData.MovementSpeed;
        _characterRb.velocity = velocity;
    }

}
