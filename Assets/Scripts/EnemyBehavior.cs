
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class EnemyBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private GameObject player;
    public float enemySpeed;

    int aggression = 0;

    bool isGrowing = true;

    Vector3 starterScale;
    void Start()
    {

        player = GameObject.FindWithTag("Player");

        aggression = Random.Range(1, 5);

        starterScale = player.transform.localScale;

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

        StartCoroutine("ChangeSize");
    }

    // Update is called once per frame
    void Update()
    {

        


        Vector3 moveDir = (player.transform.position - transform.position).normalized;
        Vector3 movement = moveDir * enemySpeed * Time.deltaTime;
        transform.position += movement;
        
    }


    private IEnumerator ChangeSize()
    {

        while (true)
        {
            if (transform.localScale.x <= 1.4f * starterScale.x && isGrowing)
            {
                transform.localScale = transform.localScale + Vector3.one * 0.1f;
            }
            else if (transform.localScale.x >= 0.6f * starterScale.x && !isGrowing)
            {
                transform.localScale = transform.localScale - Vector3.one * 0.1f;
            }

            if (transform.localScale.x > 1.4f * starterScale.x)
            {
                isGrowing = false;
            }
            else if (transform.localScale.x < 0.6f * starterScale.x)
            {
                isGrowing = true;
            }

            yield return new WaitForSeconds(2);
        }
        




        
    }
}
