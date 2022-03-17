using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public static ChangeImage instance;

    [SerializeField]
    private Sprite[] faceImage; //表情変えるためのイラスト格納

    [SerializeField]
    private GameObject yukinaImage;

    void Awake()
    {
        if(instance == null){
            instance = this;
        }
    }

    public void ChangeSprite(int spriteNum)
    {
        yukinaImage.GetComponent<Image>().sprite = faceImage[spriteNum];
    }
}
