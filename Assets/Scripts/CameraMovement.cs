using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public static bool ChaseSequence;
    public float BaseCameraSpeed;
    public float CameraSpeed;
    public float CamTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SwitchScene"))
        {
            SceneManager.LoadScene("AfterChase");
        }
    }
        // Update is called once per frame
        void Update()
    {
        CamTime += Time.deltaTime;
        if (ChaseSequence == true)
        {
            transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, -10);
            if (CamTime >= 7)
            {
                CameraSpeed = BaseCameraSpeed + CamTime;
                transform.position = new Vector3(transform.position.x + 0.001f + CameraSpeed/2000, transform.position.y, -10);
            }
        }
        /*if (ChaseSequence == false)
        {
            CamTime = 0;
            transform.position = new Vector3(PlayerMovement.Position.x, transform.position.y, -10);
        }*/
        if (Time.timeScale == 0f)
        {
            ChaseSequence = false;
        }
        else 
        {
            ChaseSequence = true;
        }
        
    }
    
}
