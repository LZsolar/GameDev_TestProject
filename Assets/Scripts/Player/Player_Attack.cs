using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Player_Status _Player_status;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Awake()
    {
        _Player_status = GetComponent<Player_Status>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
            reducePlayerAP(5);
        }
    }

    void Shoot()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = mouseWorldPos - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Ammo>().SetDirection(shootDirection);

    }
    void reducePlayerAP(float _reduceNumber) { _Player_status.reduceAP(_reduceNumber); }
}
