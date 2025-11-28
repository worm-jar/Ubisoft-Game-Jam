using UnityEngine;

public class ScreenAspect : MonoBehaviour
{
    //Screen.SetResolution(int width, int height, bool fullscreen);
    private static ScreenAspect playerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
