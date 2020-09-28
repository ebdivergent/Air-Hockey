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
    public static GameController Instance;

    private GameState _currentGameState;
    public GameState CurrentGameState => _currentGameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
