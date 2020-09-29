using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType
{
    Player1,
    Player2,
}
public class BallLogic : MonoBehaviour
{
    public Action<GoalType> OnDestroy;
    public void Hit(Collider collider)
    {
        var velocity = GameController.Instance.MovementData.VelocityForBall;

        if (collider.tag == "Wall")
        {
            velocity = new Vector3(velocity.x, -velocity.y, velocity.z);
        }
        if (collider.tag == "Player1" || collider.tag == "Player2")
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
    }

    public void DestroyGameObject(Collider collider)
    {
        if (collider.tag == "MainGoal")
        {
            OnDestroy?.Invoke(GoalType.Player1);
        }
        else if (collider.tag == "GoalEnemy")
        {
            OnDestroy?.Invoke(GoalType.Player2);
        }
    }
}
