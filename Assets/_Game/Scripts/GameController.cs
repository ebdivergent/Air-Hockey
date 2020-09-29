using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MainMenu,
    GamePlay,
    Lose,
    Win,
    Advertising,
    EndAdvertising
}

public class GameController : MonoBehaviour
{
    [SerializeField] MovementData _movementData;
   
    private GameState _currentGameState;
    public GameState CurrentGameState => _currentGameState;
    public MovementData MovementData => _movementData;
    public static GameController Instance { get; private set; }


    void Awake()
    {
        if(Instance != null)
        {
            DestroyImmediate(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
