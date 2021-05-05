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

    public GameObject boomBox;
    private AudioSource sound;
    public GameObject combatMusic;
    private AudioSource combatsound;
    public bool backgroundIsPlaying = true;
    public bool combatIsPlaying = false;
    public bool combatIsAlreadyPlaying = false;
    public int numberOfEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.Find("Player");
        //enemy = GameObject.Find("Enemy");
        //playerMovement = player.GetComponent<ThirdPersonMovement>();
        //enemyActions = enemy.GetComponent<Enemy>();
        //meleeEnemy = GameObject.Find("MeleeEnemy");
       // meleeActions = meleeEnemy.GetComponent<MeleeEnemy>();
       boomBox = GameObject.Find("BoomBox");
       sound = boomBox.GetComponent<AudioSource>();
        enemyAgro = false;
        combatMusic = GameObject.Find("CombatMusic");
        combatsound = combatMusic.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // If there are 0 enemies left...
        if (numberOfEnemies < 1 && combatIsAlreadyPlaying == true)
        {
            // Switches back to the regular music.
            backgroundIsPlaying = true;
            combatIsPlaying = false;
            sound.mute = false;
            combatsound.mute = true;
            combatIsAlreadyPlaying = false;
        }
    }

     void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Player")) {
            enemyAgro = true;
            sound.mute = true;
            combatsound.mute = false;
            backgroundIsPlaying = false;
            combatIsPlaying = true;
            combatIsAlreadyPlaying = true;

            //if (enemyActions.meleeATK == true) {
               // playerMovement.Health = playerMovement.Health - 10f;

           // }
            
              
        }
     }
}
