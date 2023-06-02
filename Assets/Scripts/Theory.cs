using UnityEngine;

public class Theory : MonoBehaviour


{
    [SerializeField] private GameObject TheoryImage;
    [SerializeField] private GameObject HelpImage;
    [SerializeField] private GameObject Health;
    [SerializeField] private bool canActive = false;
    [SerializeField] private bool canClose = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & canActive)
        {
            if (!canClose) ShowTheory();
            else UnshowTheory();
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
        Health.gameObject.SetActive(true);
        Hero.step = 1;
        Hero.closing = true;
        canClose = false;
    }

    private void ShowTheory()
    {
        Hero.closing = false;
        HelpImage.gameObject.SetActive(false);
        Health.gameObject.SetActive(false);
        TheoryImage.gameObject.SetActive(true);
        Hero.step = 0;
        canClose = true;        
    }
        
}
