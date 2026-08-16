using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;

    public GameObject bulletPrefab;

    float shootCounter = 0;
    public float shootTimer = 2;

    public float shootForce = 3f;

    void Start()
    {
        shootCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = (player.transform.position - transform.position).normalized;

        transform.up = lookDir;

        shootCounter += Time.deltaTime;

        if (shootCounter >= shootTimer)
        {
            Vector3 shootPosition = transform.position + transform.up * 2f;
            GameObject bullet = Instantiate(bulletPrefab, shootPosition, transform.rotation);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.up * shootForce, ForceMode2D.Impulse);

            shootCounter = 0f;
        }

    }
}
