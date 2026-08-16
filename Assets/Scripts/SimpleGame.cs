using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SimpleGame : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int score = 0;

    public int playerHealth = 5;

    public CoinSpawnerSimple coinSpawner;

    List<char> cheatList = new List<char>();

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("Player started at position: " + transform.position);

        if (coinSpawner == null)
        {
            Debug.LogError("CoinSpawner not found in the scene.");
        }
    }

    void Update()
    {
        // Get input from WASD keys
        float moveX = 0f;
        float moveY = 0f;

        if (Keyboard.current.aKey.isPressed)
        {
            moveX = -1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            moveX = 1f;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            moveY = -1f;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            moveY = 1f;
        }

        Vector3 movement = new Vector3(moveX, moveY, 0f)
                         * moveSpeed
                         * Time.deltaTime;

        transform.position += movement;

        if (playerHealth <= 0)
        {
            levelRestart();
        }

        CheckForCheat();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            score++;
            Debug.Log("Score: " + score);
            coinSpawner.CoinCollected();

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("superCoin"))
        {
            score += 5;
            Debug.Log("Score: " + score);
            coinSpawner.CoinCollected();

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("enemy") ||
            collision.gameObject.CompareTag("bullet"))
        {
            playerHealth--;
            Debug.Log("Health: " + playerHealth);
        }
    }

    void levelRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void CheckForCheat()
    {
        // Check each allowed cheat key
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            cheatList.Add('u');
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            cheatList.Add('d');
        }
        else if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            cheatList.Add('l');
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            cheatList.Add('r');
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            cheatList.Add('s');
        }

        // Reset list if it gets too long
        if (cheatList.Count > 7)
        {
            cheatList.Clear();
        }

        string current = new string(cheatList.ToArray());

        string cheat = "ududlrs";

        if (current == cheat)
        {
            score += 10000;
            Debug.Log("CHEAT ACTIVATED! +10000 points!");

            cheatList.Clear();
        }
    }
}