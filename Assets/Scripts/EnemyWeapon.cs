using System.Collections;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float speed = 10;
    public Rigidbody2D bullet;
    public Transform shootPos;
    public float fireRate = 1;
    [SerializeField] private Animator anima;
    [SerializeField] private GameObject enemy;


    float elapsedTime = 0.0f;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > fireRate && !EnemyStay.isHit && !EnemyStay.isDeath)
        {
            elapsedTime = 0.0f;
            StartCoroutine(ToDamage());

        }
    }
    //void OnTriggerStay2D(Collider2D col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        elapsedTime += Time.deltaTime;

    //        if (elapsedTime > fireRate)
    //        {
    //            elapsedTime = 0.0f;
    //            StartCoroutine(ToDamage());

    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    anima.SetInteger("int", 4);
    //    if (collision.gameObject.tag == "Player") 
    //        StopAllCoroutines();
    //}


    private IEnumerator ToDamage()
    {
        Vector3 direction = shootPos.position;
        Rigidbody2D clone = Instantiate(bullet, shootPos.position, Quaternion.identity) as Rigidbody2D;

        if (enemy.transform.localScale.x == 1)
        {
            clone.velocity = transform.TransformDirection(shootPos.right * speed);
            clone.transform.right = shootPos.right;
        }
        else if (enemy.transform.localScale.x == -1)
        {
            clone.velocity = transform.TransformDirection(-shootPos.right * speed);
            clone.transform.right = -shootPos.right;
        }

        yield return new WaitForSeconds(1f);
    }
}
