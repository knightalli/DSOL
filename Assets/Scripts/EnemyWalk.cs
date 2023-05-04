using System.Collections;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] positions;
    [SerializeField] private int lifes = 16;

    private bool isPunch = false;
    private bool isHit = false;
    private bool isDeath = false;
    private SpriteRenderer sprite;
    private Animator anima;


    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anima = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {        
        StartCoroutine(hitMoment());
        lifes -= damage;
        isHit = false;
        if (lifes <= 0)
        {
            StartCoroutine(deathMoment());
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private int currentTarget;

    public void FixedUpdate()
    {
        if (!isPunch && !isDeath && !isHit)
            Walk();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPunch = true;
            StartCoroutine(punchMoment());
        }
    }

    private void Walk()
    {
        anima.SetInteger("int", 0);
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
            {
                currentTarget++;
                Flip();
            }
            else
            {
                currentTarget = 0;
                Flip();
            }
        }
    }  

    private IEnumerator punchMoment()
    {
        anima.SetInteger("int", 2);
        yield return new WaitForSecondsRealtime(1);

        if (currentTarget < positions.Length - 1)
        {
            currentTarget++;
            Flip();
        }
        else
        {
            currentTarget = 0;
            Flip();
        }
        isPunch = false;
    }
    private IEnumerator deathMoment()
    {
        isDeath = true;
        speed = 0;
        anima.SetInteger("int", 3);
        yield return new WaitForSecondsRealtime(1);
        Destroy();
    }

    private IEnumerator hitMoment()
    {
        isHit = true;
        anima.SetInteger("int", 1);
        yield return new WaitForSecondsRealtime(2f);
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}


