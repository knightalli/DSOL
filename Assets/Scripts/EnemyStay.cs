using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStay : MonoBehaviour
{
    
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
        isHit = true;
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPunch = true;
            StartCoroutine(punchMoment());
        }
    }

    

    private IEnumerator punchMoment()
    {
        anima.SetInteger("int", 2);
        yield return new WaitForSecondsRealtime(1);

        isPunch = false;
    }
    private IEnumerator deathMoment()
    {
        isDeath = true;
        anima.SetInteger("int", 3);
        yield return new WaitForSecondsRealtime(1);
        Destroy();
    }

    private IEnumerator hitMoment()
    {
        //isHit = true;
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
