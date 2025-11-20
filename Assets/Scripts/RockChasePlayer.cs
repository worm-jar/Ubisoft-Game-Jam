using UnityEngine;

public class RockChasePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Player;
    public Rigidbody2D rig;
    public Vector2 launchDir;
    public float speed;
    void Start()
    {
        Player = GameObject.Find("Player");
        rig = GetComponent<Rigidbody2D>();
        launchDir = Player.transform.position - this.gameObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.linearVelocity = launchDir * speed;
    }
}
