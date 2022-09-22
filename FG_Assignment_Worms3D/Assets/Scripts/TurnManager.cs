using UnityEngine;
using Cinemachine;
public class TurnManager : MonoBehaviour
{
    private static TurnManager instance;
    [SerializeField] private PlayerTurn PlayerOne;
    [SerializeField] private PlayerTurn PlayerTwo;
    [SerializeField] private float timeBetweenTurns;

    [SerializeField] CinemachineVirtualCamera oneCam;
    [SerializeField] CinemachineVirtualCamera twoCam;
   

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            PlayerOne.SetPlayerTurn(1);
            PlayerTwo.SetPlayerTurn(2);
        }
    }

    private void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay >= timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    
    public static TurnManager GetInstance()
    {
        return instance;
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
            SwitchCam();

        }
        
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
            SwitchCam();

        }
    }

    private void SwitchCam()
    {
        if (currentPlayerIndex == 1)
        {
            oneCam.Priority = 10;
            twoCam.Priority = 1;
        }
        else if (currentPlayerIndex == 2)
        {
            oneCam.Priority = 1;
            twoCam.Priority = 10;
        }
    }
   
}
