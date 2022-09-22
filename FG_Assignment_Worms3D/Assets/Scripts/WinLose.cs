using System;
using UnityEngine;


public class WinLose : MonoBehaviour
{
    private bool hasGameEnded;
    public UI ui;
    

    public void Lose1()
    {
        if (!hasGameEnded)
        {
            Debug.Log("Player 1 Lost!");
            ui.EndGame1();
            hasGameEnded = true;
        }
    }
    public void Lose2()
    {
        if (!hasGameEnded)
        {
            Debug.Log("Player 2 Lost!");
            ui.EndGame2();
            hasGameEnded = true;
        }
    }
}
