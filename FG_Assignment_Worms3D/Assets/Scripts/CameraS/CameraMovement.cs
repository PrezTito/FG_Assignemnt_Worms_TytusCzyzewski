using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.TerrainTools;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class CameraMovement : MonoBehaviour
{
   
    public Transform player1;
    public Transform player2;
    [SerializeField] private PlayerTurn playerTurn;


   

    public void Update()
    
    {   bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (IsPlayerTurn)
        {
            transform.position = player1.transform.position;
            transform.rotation = player1.transform.rotation;
        }
        else
        {
            transform.position = player2.transform.position;
            transform.rotation = player2.transform.rotation;
        }
    }
}