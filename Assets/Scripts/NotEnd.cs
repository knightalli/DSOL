using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotEnd : MonoBehaviour
{

    [SerializeField] GameObject NoEnd;

    // Start is called before the first frame update
    void Start()
    {
        NoEnd.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Hero.step = 0;
            Destroy(gameObject);
            
            NoEnd.SetActive(true);
            
        }
    }

    //private IEnumerator NoEndAtAll()
    //{        
    //    yield return new WaitForSecondsRealtime(10);
    //    SceneManager.LoadScene(0);
    //}
}
