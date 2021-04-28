using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroZone : MonoBehaviour
{
    
    public bool enemyAgro;
    public GameObject player;

    public GameObject enemy;
    public ThirdPersonMovement playerMovement;

    private Enemy enemyActions;

    private MeleeEnemy meleeActions;

    public GameObject meleeEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
        //enemy = GameObject.Find("Enemy");
        //playerMovement = player.GetComponent<ThirdPersonMovement>();
        //enemyActions = enemy.GetComponent<Enemy>();
        //meleeEnemy = GameObject.Find("MeleeEnemy");
       // meleeActions = meleeEnemy.GetComponent<MeleeEnemy>();
        enemyAgro = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            enemyAgro = true;

            //if (enemyActions.meleeATK == true){
               // playerMovement.Health = playerMovement.Health - 10f;

           // }

            
              
        }
     }
}
