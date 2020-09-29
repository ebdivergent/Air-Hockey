using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallSimulation
{
    private ILocalPositionAdapter _localPositionAdapter;

    public BallSimulation(ILocalPositionAdapter localPositionAdapter)
    {
        _localPositionAdapter = localPositionAdapter;
    }

    public void MoveBall(float deltaTime)
    {
        var velocity = GameController.Instance.MovementData.VelocityForBall;
        _localPositionAdapter.LocalPosition += velocity * deltaTime;
    }
}
