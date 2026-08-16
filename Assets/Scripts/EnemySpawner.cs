//using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    GameObject[] EnemiesArray;
    public string[] EnemyNamesArray;

    public int numEnemies = 3;

    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    void Start()
    {
        EnemiesArray = new GameObject[numEnemies];
        EnemyNamesArray = new string[numEnemies];

        for (int i = 0; i < numEnemies; i++)
        {

            float screenX = Random.Range(-8f, 8f);
            float screenY = Random.Range(-4.5f, 4.5f);

            Vector2 randomPosition = new Vector2(screenX, screenY);


            GameObject currEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

            int charAmount = Random.Range(5, 10);

            string currEnemyName = "";

            for (int j = 0; j < charAmount; j++)
            {
                currEnemyName += glyphs[Random.Range(0, glyphs.Length)];
            }


            EnemiesArray[i] = currEnemy;
            EnemyNamesArray[i] = currEnemyName;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
