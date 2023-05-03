using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3[] positions;
    [SerializeField] private int lifes = 16;
    

    public void TakeDamage(int damage)
    {
        lifes -= damage;
        if (lifes <= 0)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private int currentTarget;

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);

        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (currentTarget < positions.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
            }
            //èãðàåò àíèìàöèÿ óäàðà
        }
    }
    //ÇÄÅÑÜ ÍÓÆÍÎ ÑÒÎËÊÍÎÂÅÍÈÅ Ñ ÓÄÀÐÎÌ!!
}


