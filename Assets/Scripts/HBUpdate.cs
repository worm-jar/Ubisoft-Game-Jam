using UnityEngine;
using UnityEngine.UI;

public class HBUpdate : MonoBehaviour
{
    public Image HealthImg;
    public Sprite Im0;
    public Sprite Im1;
    public Sprite Im2;
    public Sprite Im3;
    public Sprite Im4;
    public Sprite Im5;
    public Sprite Im6;
    public Sprite Im7;
    public Sprite Im8;
    public Sprite Im9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.playerHealth == 9)
        {
            HealthImg.sprite = Im9;
        }
        if (PlayerHealth.playerHealth == 8)
        {
            HealthImg.sprite = Im8;
        }
        if (PlayerHealth.playerHealth == 7)
        {
            HealthImg.sprite = Im7;
        }
        if (PlayerHealth.playerHealth == 6)
        {
            HealthImg.sprite = Im6;
        }
        if (PlayerHealth.playerHealth == 5)
        {
            HealthImg.sprite = Im5;
        }
        if (PlayerHealth.playerHealth == 4)
        {
            HealthImg.sprite = Im4;
        }
        if (PlayerHealth.playerHealth == 3)
        {
            HealthImg.sprite = Im3;
        }
        if (PlayerHealth.playerHealth == 2)
        {
            HealthImg.sprite = Im2;
        }
        if (PlayerHealth.playerHealth == 1)
        {
            HealthImg.sprite = Im1;
        }
        if (PlayerHealth.playerHealth == 0)
        {
            HealthImg.sprite = Im0;
        }
    }
}
