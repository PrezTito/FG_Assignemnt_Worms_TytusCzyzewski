using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class CameraSwitchManager : MonoBehaviour
{
    CinemachineVirtualCamera oneCam;
    CinemachineVirtualCamera twoCam;

     public void Start()
     {
          
     }
     
    public void CameraSwitchOne()
     {
         oneCam.Priority = 10;
         twoCam.Priority = 1;
     }

     public void CameraSwitchTwo()
     {
         oneCam.Priority = 1;
         twoCam.Priority = 10;
     }
          
     
}
