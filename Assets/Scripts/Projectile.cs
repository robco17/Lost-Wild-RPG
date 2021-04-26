using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float pSpeed = 10f;
    private float maxDistance = 100f;
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

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            
        }
        else if (collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
        }
    }
}
