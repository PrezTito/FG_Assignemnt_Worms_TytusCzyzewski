using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI : MonoBehaviour
{
    public GameObject youWon1;
    public GameObject youWon2;
    public PlayerControls player1; 
    public PlayerControls player2; 
    private void Awake()
    {
        youWon1.SetActive(false);
        youWon2.SetActive(false);
    }

    public void EndGame1()
    {
        youWon2.SetActive(true);
        Destroy();
    }
    
    public void EndGame2()
    {
        youWon1.SetActive(true);
        Destroy();
    }

    public void Destroy()
    {
        player1.GetComponent<GameObject>();
        Destroy(player1);
        player2.GetComponent<GameObject>();
        Destroy(player2);

    }
    
    
    
}
