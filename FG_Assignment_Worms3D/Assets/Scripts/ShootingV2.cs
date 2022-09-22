using UnityEngine;

public class ShootingV2 : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] float bulletForce;
    [SerializeField] public Camera cam;
    public Transform attackPoint;
   

    void Update()
    {
        MyInput();
    }

    // SHOOTING
    // ReSharper disable Unity.PerformanceAnalysis
    private void MyInput()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (IsPlayerTurn)
                {
                    TurnManager.GetInstance().TriggerChangeTurn();
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    Vector3 targetPoint;
                    if (Physics.Raycast(ray, out hit))
                        targetPoint = hit.point;
                    else
                        targetPoint = ray.GetPoint(75);

                    Vector3 directionWithoutSpread = (targetPoint - attackPoint.position);

                    GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

                    currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * bulletForce, ForceMode.Impulse);
                    Destroy(currentBullet, 120f);

                    currentBullet.GetComponent<SphereCollider>();
                    currentBullet.GetComponent<BulletsCollisions>();
                }
            }
    }
}
