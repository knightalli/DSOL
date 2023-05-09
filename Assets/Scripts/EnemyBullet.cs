using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    [SerializeField] private int damage;
    public Vector2 speed = new Vector2(20, 20);
    public Vector2 direction = new Vector2(1, 1);
    public Vector2 movement;
    [SerializeField] private GameObject player;

    public float fireRate = 0.5f;

    public void Start()
    {
        //movement = new Vector2(speed.x * direction.x * player.transform.position.x, speed.y * direction.y * player.transform.position.y);
    }

    private void Update()
    {
        Invoke("Destroy", 1f);
    }

    void FixedUpdate()
    {
        //GetComponent<Rigidbody2D>().velocity = movement;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Hero>().TakeDamage(damage);
            Destroy();
        }

        if (collision.CompareTag("Ground"))
            Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
