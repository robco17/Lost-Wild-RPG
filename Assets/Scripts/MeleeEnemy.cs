using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    
    private GameObject player;
    public float speed;
    public Transform[] moveSpots;
    public float startWaitTime;
    private float waitTime;
    private int randomSpot;
    public bool Patrolling;

    public float range = 1.0f;

    private Visionbox visionBox;
    private AgroZone agroZone;

    public ThirdPersonMovement playerMovement;

    public bool rangeATK = false;

    public bool meleeATK =  false;

    //private float mana = 100f;

    public Transform target;

    public GameObject projectile;

    private float timeBtwShoots;

    public float startTimeBtwShots;

    

    

    public GameObject front;

    public float health = 100f;

    private float projectileDMG = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
          Patrolling = true;
          visionBox = GameObject.Find("Visionbox").GetComponent<Visionbox>();
          player = GameObject.Find("Player");
          playerMovement = GetComponent<ThirdPersonMovement>();
          timeBtwShoots = startTimeBtwShots;
         agroZone = GameObject.Find("AgroZone").GetComponent<AgroZone>();
         speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
          if(Patrolling == true){
            GuardPatrol();

        }

        if (agroZone.enemyAgro == true ) {
            GuardAgro();
           
        }

       
    }

     void GuardPatrol (){
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                 randomSpot = Random.Range(0, moveSpots.Length);
                 waitTime = startWaitTime;
            } else {
                waitTime -= Time.deltaTime;
            }
            Patrolling = true;
        }
    }
//Sends Enemy towards the playa
    void GuardAgro (){
        Patrolling = false;
        speed = 10f;
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance >= range){
             LookAtPlayer();

            if(rangeATK == true){
                RangeEnemy();

            }   
            if (meleeATK == true){
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                if (Distance <= 3){
                    MEnemy();
                    

                }
               
                
            }

        }
    
    }

    //Look towards the player when agroed
    void LookAtPlayer () {
         Vector3 targetDirection = target.transform.position - transform.position;
              float singleStep = speed *Time.deltaTime;
              Vector3 lookTowardsPlayer = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
               transform.rotation = Quaternion.LookRotation(lookTowardsPlayer);
               

    }

//Creates Projectile to shoot player
    void RangeEnemy () {
        
         if (timeBtwShoots <=0){
             Instantiate(projectile, front.transform.position, front.transform.rotation);
             timeBtwShoots = startTimeBtwShots;

            }else {
                timeBtwShoots -= Time.deltaTime;
            }

    }

//Time between attacks
     void MEnemy () {
        
         if (timeBtwShoots <=0){
             Instantiate(projectile, front.transform.position, front.transform.rotation);
             timeBtwShoots = startTimeBtwShots;

            }else {
                timeBtwShoots -= Time.deltaTime;
            }

    }

    

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Projectile")){

            health -= projectileDMG;
            EnemyDeath();

        }
        
       
    }

    void EnemyDeath(){
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
