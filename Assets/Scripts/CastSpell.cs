using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code was used from https://www.youtube.com/watch?v=wBMrVrdea6s

public class CastSpell : MonoBehaviour
{
    public Rigidbody spell;
    public float throwSpeed;
    [SerializeField] GameObject Burst;

    // Start is called before the first frame update
    void Start()
    {
        spell.velocity = transform.forward * throwSpeed;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Instantiate(Burst, transform.position, transform.rotation);

        /*if (collision.transform.tag == "Enemy")
        {
            // Get comp for enemy script
            // Enemy - damage from health
        }*/

        Destroy(this.gameObject);
    }
}
