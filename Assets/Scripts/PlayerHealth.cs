using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int playerHealth = 9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && playerHealth > 0)
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
