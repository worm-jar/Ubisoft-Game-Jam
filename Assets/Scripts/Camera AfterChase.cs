using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAfterChase : MonoBehaviour

{
    public GameObject Player;

    public 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, 0, -10); 
    }
}
