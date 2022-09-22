using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private float rotationSpeed = 0.05f;
    [SerializeField] public int health;
    [SerializeField] private Rigidbody characterBody;

    private GameObject SwshitRobot;
    private Vector3 wasdInputVector3;
    private Vector3 movementDirection;
    private Vector3 velocity;
    
    
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(transform.up * (rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
            }

            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Translate(transform.forward * (speed * Time.deltaTime * Input.GetAxis("Vertical")), Space.World);
            }

            if (Input.GetKeyDown(KeyCode.Space) && IsTouchingFloor())
            {
                Jump();
            }
        }
    }
    
    private void Jump()
    {
        characterBody.AddForce(Vector3.up * 500f);
    }
    
    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result =  Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }
}


