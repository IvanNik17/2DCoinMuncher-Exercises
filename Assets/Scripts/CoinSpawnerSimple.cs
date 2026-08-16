using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class CoinSpawnerSimple : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject superCoinPrefab;
    public int maxCoins = 5; 
    public float spawnInterval = 5f; 

    private int currentCoinCount = 0;
    private float spawnCounter;
    

    void Start()
    {
        spawnCounter = spawnInterval;
    }

    void Update()
    {
        spawnCounter -= Time.deltaTime;

        if (spawnCounter <= 0)
        {

            if (currentCoinCount < maxCoins)
            {
                float screenX = Random.Range(-8f, 8f);
                float screenY = Random.Range(-4.5f, 4.5f);

                float superChance = Random.Range(0f, 1f);


                Vector2 randomPosition = new Vector2(screenX, screenY);


                if (superChance > 0.8f)
                {
                    Instantiate(superCoinPrefab, randomPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(coinPrefab, randomPosition, Quaternion.identity);
                }
                    
                currentCoinCount++;

            }
            

            spawnCounter = spawnInterval; // Reset the spawn counter
        }
    }

    public void CoinCollected()
    {
        
        currentCoinCount--;
    }





}
