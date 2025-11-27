using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    

    // Update is called once per frame
    void Update()
    {
        CamTime = Time.time;
        if (ChaseSequence == true)
        {
            transform.position = new Vector3(transform.position.x + 0.001f, transform.position.y, -10);
            if (CamTime >= 5)
            {
                CameraSpeed = BaseCameraSpeed + CamTime;
                transform.position = new Vector3(transform.position.x + 0.001f + CameraSpeed/2000, transform.position.y, -10);
            }
        }
        if (ChaseSequence == false)
        {
            transform.position = new Vector3(PlayerMovement.Position.x, transform.position.y, -10);
        }
        
    }
    
}
