using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Shooting : MonoBehaviour
{
    [SerializeField] public GameObject bullet;
    [SerializeField] float bulletForce;
    [SerializeField] float magazineSize, bulletsPerShot;
    [SerializeField] public float reloadTime, timeBetweenShots;
    float bulletsLeft, bulletsShot;
    private bool readyToShoot, shooting, reloading;
    public Transform attackPoint;
    public bool allowInvoke = true;
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunitionDisplay;
    [SerializeField] public Camera cam;
    
    void Awake()
    {
        readyToShoot = true;
        bulletsLeft = magazineSize;
    }

    void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shooting = true;
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }
    public void Shoot()
    {
        readyToShoot = false;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * bulletForce, ForceMode.Impulse );

        if (muzzleFlash != null)
        {
           Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }
        
        bulletsLeft -= 1;
        bulletsShot += 1;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShots);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        bulletsLeft += magazineSize;
    }
}
