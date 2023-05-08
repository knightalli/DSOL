using UnityEngine;


public class Bullet : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private int damage;
    public Vector2 speed = new Vector2(20, 20);
    public Vector2 direction = new Vector2(1, 0);
    public Vector2 movement;



    public void Start()
    {
        if (Hero.facingRight == true)
        {
            movement = new Vector2(speed.x * direction.x, 0);
        }
        else if (Hero.facingRight == false)
        {
            movement = new Vector2(speed.x * (-direction.x), 0);
        }

    }

    private void Update()
    {
        Invoke("Destroy", 1f);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("EnemyWalk"))
        {
            collision.gameObject.GetComponent<EnemyWalk>().TakeDamage(damage);
            Destroy();
        }
        else if (collision.CompareTag("EnemyStay"))
        {
            collision.gameObject.GetComponent<EnemyStay>().TakeDamage(damage);
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
