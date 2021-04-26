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


    // Start is called before the first frame update

  
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        playerMovement = player.GetComponent<ThirdPersonMovement>();
        enemyActions = enemy.GetComponent<Enemy>();


    }
    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")){
            agro = true;

            if (enemyActions.meleeATK == true){
                playerMovement.Health = playerMovement.Health - 10f;

            }

            
              
        }

        
        
        
    }
    
}
