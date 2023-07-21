using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent onGameOver;


    public void GameOver()
    {
        onGameOver.Invoke();
    }
}
