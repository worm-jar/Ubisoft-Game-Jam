using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeTimer;
    public float shakeForce;
    public Vector3 origPos;
    public float ShakeTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShakeTime += Time.deltaTime;
        if (ShakeTime >= 10)
        {
            if (shakeTimer > 0)
            {
                this.gameObject.transform.position += new Vector3(Mathf.Sin(Time.time * 50f) * shakeForce, Mathf.Cos(Time.time * 500f) * shakeForce, -10f);
                shakeTimer -= Time.deltaTime;
                if (shakeTimer <= 0)
                {
                    shakeTimer = 0;
                    this.gameObject.transform.position = origPos;
                }
            }
        }
    }
}
