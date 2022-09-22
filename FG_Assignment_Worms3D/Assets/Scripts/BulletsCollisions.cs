using UnityEngine;

public class BulletsCollisions : MonoBehaviour
{
    
    [SerializeField] private PlayerControls player;
    [SerializeField] private LoseHeath kurwa;
    
    

    public void OnTriggerEnter(Collider other)
        {
           
                if (other.gameObject.CompareTag("Player1") )
                {
                    kurwa.healthP1--;
                    kurwa.Update_HealthP1();

                }
            
                if (other.gameObject.CompareTag("Player2") )
                {
                    kurwa.healthP2--;
                    kurwa.Update_HealthP2();
                }
        }
}

 