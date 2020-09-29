using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 Velocity;
    void FixedUpdate()
    {
        transform.localPosition = transform.localPosition + Velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Wall")
        {
            Velocity = new Vector3(Velocity.x, -Velocity.y, Velocity.z);
        }

        if(collider.gameObject.tag == "MainGoal" || collider.gameObject.tag == "GoalEnemy")
        {
            Destroy(gameObject);
        }

        if(collider.gameObject.tag == "Player1" || collider.gameObject.tag == "Player2")
        {
            Velocity = new Vector3(-Velocity.x, Velocity.y, Velocity.z);
        }
    }
}
