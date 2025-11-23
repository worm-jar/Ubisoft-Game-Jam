using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    public Rigidbody2D rig;
    public GameObject cam;
    public CameraShake CameraShake;
    public PlayerMovement playerMovement;
    public float pushForceX;
    public float pushForceY;
    public float pushTimer;
    public float InvincTimer;
    public Vector2 Dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera");
        CameraShake = cam.GetComponent<CameraShake>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pushTimer > 0)
        {
            //rig.AddForce(new Vector2(Dir.x * pushForceX, 0f), ForceMode2D.Force);
            this.gameObject.transform.position += new Vector3(Dir.x * pushForceX, 0f);
            pushTimer -= Time.deltaTime;
            {
                if (pushTimer <= 0)
                {
                    InvincTimer = 0.3f;
                    pushTimer = 0;
                }
            }
        }
        if (InvincTimer > 0)
        {
            InvincTimer -= Time.deltaTime;
            {
                if (InvincTimer <= 0)
                {
                    this.gameObject.layer = LayerMask.NameToLayer("PlayerDefault");
                    InvincTimer = 0;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Invincible");
            pushTimer = 0.25f;
            Dir = this.gameObject.transform.position - collision.gameObject.transform.position;
            rig.linearVelocityY = pushForceY;
            CameraShake.origPos = cam.transform.position;
            CameraShake.shakeTimer = 0.2f;
        }
    }
}
