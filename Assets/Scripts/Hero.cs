using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 7;
    [SerializeField] private int lifes = 10;
    [SerializeField] private float jumpForce = 20f;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float startTimeBtwAttack;
    [SerializeField] private int numberScene;

    public static bool closing = true;
    public static int step = 1;


    private int jumpCount = 0;
    private int maxJumpCount = 2;
    private bool isHitted = false;
    private bool isAttacked = false;
    private bool jumpControl = true;
    public static bool facingRight = true;
    public float dir;
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    private float timeBtwAttack;

    public int numOfBattery;
    public Sprite[] batteries;
    [SerializeField] Image battery;


    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    AudioManager audioManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Update()
    {
        if (isGrounded && !isAttacked && !isHitted) { anim.SetInteger("state", 0); }

        if (Input.GetButton("Horizontal"))
            Run();

        Jump();

        //if (Input.GetKeyDown(KeyCode.LeftShift) && !lockLunge)
        //{
        //    Lunge();
        //}

        if (lifes <= 0)
        {
            StartCoroutine(sceneLoader());
        }

        if (isHitted == true && lifes > 0)
        {
            StartCoroutine(damageMoment());
        }

        if (Input.GetKey(KeyCode.K))
        {
            isAttacked = true;
            StartCoroutine(attackMoment());
        }
    }

    private void FixedUpdate()
    {
        if (lifes > numOfBattery)
        {
            lifes = numOfBattery;
        }
        battery.sprite = batteries[lifes];
    }


    private void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            audioManager.PlaySFX(audioManager.shortShoot);
            anim.SetInteger("state", 6);
            Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(2, 2), enemy);
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].CompareTag("EnemyWalk"))
                    enemies[i].GetComponent<EnemyWalk>().TakeDamage(damage);
                else if (enemies[i].CompareTag("EnemyStay"))
                    enemies[i].GetComponent<EnemyStay>().TakeDamage(damage);
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector2(2, 2));
    }

    private void Run()
    {
        if (isGrounded) { anim.SetInteger("state", 1); }

        dir = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(dir * speed * step, GetComponent<Rigidbody2D>().velocity.y);

        if (dir > 0 && !facingRight)
            Flip();
        else if (dir < 0 && facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space))
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Invoke("IgnoreLayerOff", 0.5f);
            jumpControl = false;
        }

        if (jumpControl)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                {
                    audioManager.PlaySFX(audioManager.jump);
                    anim.SetInteger("state", 2);
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpForce);
                }
                else if (++jumpCount < maxJumpCount)
                {
                    audioManager.PlaySFX(audioManager.jump);
                    anim.SetInteger("state", 2);
                    rb.velocity = new Vector2(0, 15);
                }

            }
        }
    }

    void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(6, 7, false);
        jumpControl = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Battery"))
        {
            lifes++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Peaks"))
        {
            lifes = 0;
        }


    }

    public void TakeDamage(int damage)
    {
        lifes -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        jumpCount = 0;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    //private bool lockLunge = false;
    //[SerializeField] private float lungeImpulse = 655f;

    //private void Lunge()
    //{
    //    anim.SetInteger("state", 3);
    //    lockLunge = true;
    //    Invoke("LungeLock", 0.7f);

    //    if (!facingRight)
    //    {
    //        rb.velocity = new Vector2(0, rb.velocity.y);
    //        rb.AddForce(Vector2.left * lungeImpulse);
    //    }
    //    else
    //    {
    //        rb.velocity = new Vector2(0, rb.velocity.y);
    //        rb.AddForce(Vector2.right * lungeImpulse);
    //    }
    //}

    //private void LungeLock()
    //{
    //    lockLunge = false;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyWalk")
        {
            isHitted = true;
            lifes -= 3;
        }
    }



    private IEnumerator sceneLoader()
    {
        if (!facingRight)
            Flip();

        speed = 0;
        anim.SetInteger("state", 4);
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(numberScene);
    }

    private IEnumerator damageMoment()
    {
        anim.SetInteger("state", 5);
        yield return new WaitForSecondsRealtime(1);
        isHitted = false;
    }

    private IEnumerator attackMoment()
    {
        anim.SetInteger("state", 6);
        Attack();
        yield return new WaitForSecondsRealtime(1f);
        isAttacked = false;
    }
}
