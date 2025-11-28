using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public static int playerHealth = 9;
    public Animator playerAnimator;
    public Animator ownerAnimator;
    public float DeathTimer;
    public float EndTimer;
    public bool end;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        //ownerAnimator =  Owner.GetComponent<Animation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OutOfBounds"))
        {
            SceneManager.LoadScene("DeathScreen");
        }
        if (collision.gameObject.CompareTag("End"))
        {
            end = true;
            if (playerHealth == 9)
            {
                ownerAnimator.SetTrigger("GoodEnd");
            }
            else
            {
                ownerAnimator.SetTrigger("BadEnd");
            }
            
        }
        if (collision.gameObject.CompareTag("Enemy") && playerHealth > 1)
        {

            playerHealth--;
            playerAnimator.SetTrigger("IsHit");

        }
        else if (playerHealth <= 1)
        {
            playerHealth--;
            playerAnimator.SetTrigger("IsDead");

            
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            playerHealth--;
        }
        if (playerHealth <= 1)
        {
            DeathTimer -= Time.deltaTime;
        }
        if (DeathTimer <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
        if (end == true)
        {
            EndTimer -= Time.deltaTime;
        }
        if (EndTimer <= 0)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
