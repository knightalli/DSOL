using System.Collections;
using UnityEngine;

public class EnemyStay : MonoBehaviour
{

    [SerializeField] private Vector3[] positions;
    [SerializeField] private int lifes = 16;
    [SerializeField] private GameObject player;

    private bool isPunch = false;
    public static bool isHit = false;
    public static bool isDeath = false;
    private Animator anima;
    public static Vector3 theScale; 


    private void Awake()
    {
        anima = GetComponent<Animator>();
        theScale = transform.localScale;
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

    

    public void FixedUpdate()
    {
        if (!isHit && !isDeath)Turn();
    }

    private void Turn()
    {
        anima.SetInteger("int", 4);

        if (transform.position.x - player.transform.position.x > 0)
        {            
            theScale.x = -1;
            transform.localScale = theScale;
        }
        else if (transform.position.x - player.transform.position.x < 0)
        {
            theScale.x = 1;
            transform.localScale = theScale;
        }
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

    
}
