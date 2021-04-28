using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visionbox : MonoBehaviour
{
    public bool agro;
    public GameObject player;

    public GameObject enemy;
    public ThirdPersonMovement playerMovement;

    private Enemy enemyActions;

    private MeleeEnemy meleeActions;

    public GameObject meleeEnemy;

    public float meleeDamage;

    public float startTimeBtwAttacks;

    public float timeBtwAttacks;

     public GameObject projectile;

      public GameObject front;

      public bool inSight = false;
    


    // Start is called before the first frame update

  
    void Start()
    {
        player = GameObject.Find("Player");
        //enemy = GameObject.Find("Enemy");
        playerMovement = player.GetComponent<ThirdPersonMovement>();
        //enemyActions = enemy.GetComponent<Enemy>();
        meleeEnemy = GameObject.Find("MeleeEnemy");
        meleeActions = meleeEnemy.GetComponent<MeleeEnemy>();



    }
    // Update is called once per frame
    void Update(){

    }
    
     void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            inSight = true;
            

            
              
        }
     }
        
   //public void ATKMeleeEnemy (){
        
        //if (timeBtwAttacks <=0){
             //Instantiate(projectile, front.transform.position, front.transform.rotation);
             //timeBtwAttacks = startTimeBtwAttacks;

           // }else {
               //timeBtwAttacks -= Time.deltaTime;
            //}


        

    //}
    
}
