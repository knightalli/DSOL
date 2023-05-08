using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextScene : MonoBehaviour

{
    [SerializeField] private int numberNextScene;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (numberNextScene != -1)
                SceneManager.LoadScene(numberNextScene);
            else Application.Quit();
        }
    }
}
