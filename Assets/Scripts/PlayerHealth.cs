using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHealth = 9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerHealth > 1)
        {
            playerHealth--;
        }
        else if (playerHealth <= 1)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerHealth--;
        }
    }
}
