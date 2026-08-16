
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class EnemyBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject player;
    public float enemySpeed;

    int aggression = 0;

    
    void Start()
    {

        player = GameObject.FindWithTag("Player");

        aggression = Random.Range(1, 5);

        

        switch (aggression)
        {
            case 1:
                enemySpeed += 0f;
                break;
            case 2:
                enemySpeed += 0.5f;
                break;
            case 3:
                enemySpeed += 1;
                break;
            case 4:
                enemySpeed += 2;
                break;
            default:
                enemySpeed += 0f;
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        


        Vector3 moveDir = (player.transform.position - transform.position).normalized;
        Vector3 movement = moveDir * enemySpeed * Time.deltaTime;
        transform.position += movement;
        
    }


    
}
