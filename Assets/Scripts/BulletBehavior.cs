using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float selfDestruct = 6;
    float destructCounter = 0;
    void Start()
    {
        destructCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        destructCounter += Time.deltaTime;
        
        if ( destructCounter >= selfDestruct)
        {
            Destroy(gameObject);
        }
    }
}
