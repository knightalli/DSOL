using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject windowQuiz;
    public TextMeshProUGUI textAndQuestion;
    public string[] message;
    public int numberDialog = 0;
    public UnityEngine.UI.Button buttonTrue;
    public UnityEngine.UI.Button buttonFalse;
    public bool haveKey = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            buttonTrue.gameObject.SetActive(true);
            buttonTrue.onClick.AddListener(TrueDialog);
            buttonFalse.gameObject.SetActive(true);
            buttonFalse.onClick.AddListener(FalseDialog);


            windowQuiz.SetActive(true);
            textAndQuestion.text = message[numberDialog];
        }

        if (haveKey == false)
        {            
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowQuiz.SetActive(false);
        numberDialog = 0;
        buttonTrue.onClick.RemoveAllListeners();
        buttonFalse.onClick.RemoveAllListeners();
    }

    public void TrueDialog()
    {
        numberDialog++;
        textAndQuestion.text = "Вы правы";
        buttonTrue.gameObject.SetActive(false);
        buttonFalse.gameObject.SetActive(false);
        ChangeSprite();
        if(haveKey)
        {
            haveKey = false;
            //collision.GetComponent<Collider2D>().enabled = false;
        }
        //+ключ или что-то типо

    }

    public void FalseDialog()
    {
        numberDialog++;
        textAndQuestion.text = "Попробуйте позже";
        buttonTrue.gameObject.SetActive(false);
        buttonFalse.gameObject.SetActive(false);
    }

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public void ChangeSprite()
    {
        spriteRenderer.sprite = newSprite;
    }
}