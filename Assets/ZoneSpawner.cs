using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    public GameObject healZone;
    public GameObject damageZone;
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            

            if (i < 2)
            {

                float screenXHeal = Random.Range(-8f, 8f);
                float screenYHeal = Random.Range(-4.5f, 4.5f);

                Vector2 randomPositionHeal = new Vector2(screenXHeal, screenYHeal);

                Instantiate(healZone, randomPositionHeal, Quaternion.identity);
            }

            float screenXDamage = Random.Range(-8f, 8f);
            float screenYDamage = Random.Range(-4.5f, 4.5f);

            Vector2 randomPositionDamage = new Vector2(screenXDamage, screenYDamage);
            Instantiate(damageZone, randomPositionDamage, Quaternion.identity);
        }
    }

    
}
