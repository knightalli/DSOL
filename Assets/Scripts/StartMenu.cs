using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    [SerializeField] GameObject start;
    [SerializeField] GameObject load;
    private bool Loading = false;

    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        load.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadGame()
    {
        Loading = true;
        start.SetActive(false);
        load.SetActive(true);

    }

    public void LevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void LevelThree()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void Back()
    {
        load.SetActive(false);
        start.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Training");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
