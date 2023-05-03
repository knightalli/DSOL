using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPos;    
    public GameObject Bullet;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(Bullet, shotPos.transform.position, transform.rotation);
        }

    }
}
