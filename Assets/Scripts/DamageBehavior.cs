using UnityEngine;

public class DamageBehavior : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            col.GetComponent<SimpleGame>().playerHealth -= 1;
            

            Debug.Log("Health: " + col.GetComponent<SimpleGame>().playerHealth);

        }

    }
}
