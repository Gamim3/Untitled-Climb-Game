using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public Transform barrel;
    public Rigidbody bulletRb;
    public float bulletSpeed;

    private void Start()
    {
        bulletTransform = bullet.transform;
        bulletRb = bullet.GetComponent<Rigidbody>();
    }
    public void Fire()
    {
        bulletTransform.position = barrel.position;
        bulletRb.velocity = barrel.forward * bulletSpeed * Time.deltaTime;
    }

}
