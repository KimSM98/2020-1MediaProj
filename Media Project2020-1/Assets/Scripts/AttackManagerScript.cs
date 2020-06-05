using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackManagerScript : MonoBehaviour
{
    public static AttackManagerScript instance;
    public GameObject AttackEffect;

    public Button[] ColorButtons; 
    public Button MiddleStarButton; 
    public Sprite[] ClickedColorButtonSprites;
    public Sprite[] MiddleStarButtonColors;
    public int SumOfColor = 0;
    public int PushedButtonNum = 0;

    private Sprite[] OriginCBSprites = new Sprite[5];
    void Awake()
    {
        instance = this;
    }
  
   void Start()
   {
       if(SumOfColor == 0) MiddleStarButton.gameObject.SetActive(false);
       for(int i=0; i<ColorButtons.Length; i++){
           OriginCBSprites[i] = ColorButtons[i].image.sprite; //공격하면 원래대로 돌리기
       }
   }
   public void Attack(){
        MiddleStarButton.gameObject.SetActive(false);
        AttackEffect.SetActive(true);
        AttackEffect.GetComponent<AttackEffect>().StartAnim(SumOfColor);
        AttackEffect.GetComponent<AttackEffect>().SetisMove(true);
   }

    public void ChangeMSBSprite(){ 
        if(SumOfColor != 0) MiddleStarButton.gameObject.SetActive(true);
        else if(SumOfColor == 0) MiddleStarButton.gameObject.SetActive(false);

        MiddleStarButton.image.sprite = MiddleStarButtonColors[SumOfColor];
    }//공격 후에는 false로(SumOfColor가 0이 되면 꺼짐)
    public void PushColorButton(int ColorNum, int ButtonArrayNum){
        ColorButtons[ButtonArrayNum].image.sprite = ClickedColorButtonSprites[ButtonArrayNum];
        PushedButtonNum++;
        SumOfColor+=ColorNum;
    }
    public void releaseColorButton(int ColorNum, int ButtonArrayNum){//버튼에서 손을 뗏을 때 
        ColorButtons[ButtonArrayNum].image.sprite = OriginCBSprites[ButtonArrayNum];
        PushedButtonNum--;
        SumOfColor-=ColorNum;
    }

    
}
