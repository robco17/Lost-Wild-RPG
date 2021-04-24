using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float pSpeed = 10f;
    private float maxDistance = 300f;
    private Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * pSpeed);
        if (Vector3.Distance(spawnLocation, transform.position) > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
