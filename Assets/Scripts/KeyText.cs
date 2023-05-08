using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyText : MonoBehaviour
{
    [SerializeField] public static int keyNow;
    [SerializeField] private int keyAll;
    [SerializeField] private TMP_Text text;
    [SerializeField] GameObject lastDoor;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        keyNow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = keyNow.ToString()+'/'+keyAll.ToString();
        if (keyNow == keyAll)
        {
            ChangeLastDoor();
            lastDoor.GetComponent<BoxCollider2D>().enabled = false;            
        }
    }
    public SpriteRenderer lastDoorSpriteRenderer;
    public Sprite lastDoorNewSprite;
    public void ChangeLastDoor()
    {
        lastDoorSpriteRenderer.sprite = lastDoorNewSprite;
    }


}
