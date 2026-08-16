using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HealBehavior : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<SimpleGame>().playerHealth = 5;
            Debug.Log("Health: " + col.GetComponent<SimpleGame>().playerHealth);
        }

    }
}
