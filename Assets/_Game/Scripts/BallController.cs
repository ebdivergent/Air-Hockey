using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocalPositionAdapter
{
    Vector3 LocalPosition { get; set; }
}
public class BallController : MonoBehaviour, ILocalPositionAdapter
{
    private BallLogic _ballLogic;
    private BallSimulation _ballSimulation;

    public Vector3 LocalPosition
    {
        get { return transform.localPosition; }
        set { transform.localPosition = value; }
    }

   void Awake()
    {
        _ballLogic = new BallLogic();
        _ballSimulation = new BallSimulation(this);
        _ballLogic.OnDestroy += DestroyBall;
    }
    
    void FixedUpdate()
    {
        _ballSimulation.MoveBall(Time.fixedDeltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        _ballLogic.Hit(collision.collider);
        _ballLogic.DestroyGameObject(collision.collider);
    }

    void DestroyBall(GoalType goalType)
    {
        switch(goalType)
        {
            case GoalType.Player1:
                Debug.Log("Player1");
                break;
            case GoalType.Player2:
                Debug.Log("Player2");
                break;
        }
        Destroy(gameObject);
    }
}
