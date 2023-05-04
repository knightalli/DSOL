using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private float timeBtwAttack;
    [SerializeField]private float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator animat;

    private void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    //private IEnumerator hitMoment()
    //{        
    //    animat.SetInteger("state", 6);
    //    yield return new WaitForSecondsRealtime(2f);
    //}
}
