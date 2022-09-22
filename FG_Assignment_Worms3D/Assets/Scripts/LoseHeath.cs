using System.Collections.Generic;
using UnityEngine;

public class LoseHeath : MonoBehaviour
{
    [SerializeField] private List<KoloroweSerduszka> heartsP1;
    [SerializeField] private List<KoloroweSerduszka> heartsP2;
    public WinLose winLoseScript;
    [SerializeField] private PlayerControls playerOne;
    [SerializeField] private PlayerControls playerTwo;
    public int healthP1;
    public int healthP2;
    
    

    private void Awake()
    {
        healthP1 = playerOne.health;
        healthP2 = playerTwo.health;
    }

    public void Update_HealthP1()
    {
        for (int i = 0; i < heartsP1.Count; i++)
        {
            if (i < healthP1)
            {
                heartsP1[i].ChangeColor(Color.red);
            }
            else
            {
                heartsP1[i].ChangeColor(Color.black);
            }
        }

        if (healthP1 == 0)
        {
            winLoseScript.Lose1();
            
        }
    }
    
    public void Update_HealthP2()
    {
        
        for (int i = 0; i < heartsP2.Count; i++)
        {
            if (i < healthP2)
            {
                heartsP2[i].ChangeColor(Color.red);
            }
            else
            {
                heartsP2[i].ChangeColor(Color.black);
            }
        }
        if (healthP2 == 0)
        {
            winLoseScript.Lose2();
            
        }
        
    }
    
    
    
}

