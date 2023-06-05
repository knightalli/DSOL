using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pause;
    [SerializeField] GameObject load;
    private bool Loading = false;

    // Start is called before the first frame update
    void Start()
    {        
        pause.SetActive(false);
        load.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!Loading)
            {
                pause.SetActive(true);
                Time.timeScale = 0;
            }

            if (Loading)
            {
                load.SetActive(false);
                pause.SetActive(true);
            }
        }
    }

    public void PauseOff()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadGame()
    {
        Loading = true;
        pause.SetActive(false);
        load.SetActive(true);

    }

    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(3);
    }

    public void Back()
    {
        load.SetActive(false);
        pause.SetActive(true);
    }

    
}
