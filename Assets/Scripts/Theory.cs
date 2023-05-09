using UnityEngine;

public class Theory : MonoBehaviour


{
    [SerializeField] private GameObject TheoryImage;
    [SerializeField] private GameObject HelpImage;
    [SerializeField] private bool canActive = false;
    [SerializeField] private bool canClose = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canActive)
        {
            ShowTheory();
            
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canClose)
        {
            UnshowTheory();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            HelpImage.gameObject.SetActive(true);
            canActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        HelpImage.gameObject.SetActive(false);
        canActive = false;
    }

    private void UnshowTheory ()
    {
        TheoryImage.gameObject.SetActive(false);
        Hero.step = 1;
    }

    private void ShowTheory()
    {
        HelpImage.gameObject.SetActive(false);
        TheoryImage.gameObject.SetActive(true);
        Hero.step = 0;
        canClose = true;
    }
        
}
