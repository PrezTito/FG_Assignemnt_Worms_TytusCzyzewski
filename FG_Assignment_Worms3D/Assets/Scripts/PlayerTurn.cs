using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private int playerIndex;

    public void SetPlayerTurn(int index)
    {
        playerIndex = index;
    }

    public bool IsPlayerTurn()
    {
        return TurnManager.GetInstance().IsItPlayerTurn(playerIndex);
    }
}
