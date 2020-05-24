using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour
{
    public int ArrayNum;
    public int ButtonColorNum;
    private bool isPushed = false;

    public void GetButtonColor()
    {
        if(UIManagerScript.instance.PushedButtonNum <2 && isPushed != true){//최대 2개 누를 수 있고, 선택된 것은 작동 x
            isPushed = true;
            UIManagerScript.instance.PushColorButton(ButtonColorNum, ArrayNum);
            
        }//다시 누르면 뗌
        else if(UIManagerScript.instance.PushedButtonNum>0 && isPushed == true){
            isPushed = false;
            UIManagerScript.instance.releaseColorButton(ButtonColorNum,ArrayNum);
        }
        UIManagerScript.instance.ChangeMSBSprite();
    }
    
}
