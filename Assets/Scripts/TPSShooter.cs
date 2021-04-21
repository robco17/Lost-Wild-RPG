using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code was used from https://www.youtube.com/watch?v=T5y7L1siFSY

public class TPSShooter : MonoBehaviour
{
    public GameObject projectile;
    public Transform firePoint;
    public float projectileSpeed = 30f;

    private Vector3 destination;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the user left clicks, then the player casts a spell.
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
           /* Ray ray = cam.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                destination = hit.point;
                else
                destination = ray.GetPoint(1000);
            
           */ InstantiateProjectile(firePoint);
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(projectile, firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
    }
}
