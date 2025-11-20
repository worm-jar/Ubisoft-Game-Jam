using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHealth = 9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TakeDamage") && playerHealth > 0)
        {
            playerHealth--;
        }
        else if (playerHealth <= 0)
        {
            //to do
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
