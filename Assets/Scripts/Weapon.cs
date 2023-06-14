using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotPos;    
    public GameObject Bullet;

    AudioManager audioManager;

    private void Awake()
    {        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            audioManager.PlaySFX(audioManager.jump);
            Instantiate(Bullet, shotPos.transform.position, transform.rotation);
        }

    }
}
