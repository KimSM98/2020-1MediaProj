using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : Color // Game  Manager에 넣기?
{
    public Button[] ColorButtons;
    public Button[] AttackButton;
    //Game Object[] Button해서 0~5 빨, 노, 파, 흰,검 순서로 넣기
    private int[] buttonColor = {(int)ColorState.Red, (int)ColorState.Yellow, (int)ColorState.Blue,
                                 (int)ColorState.White, (int)ColorState.Black};
    private int sumOfSelectedColor = 0;
    private int selectNum = 0;
    
    void Start()
    {
        //Color 정보 넣기
        for(int i=0; i<ColorButtons.Length; i++)
        {
            //ColorButtons[i].GetComponent<ColorButton>().SetButtonsColor(buttonColor[i]);
        }        
    }

    public void SelectButton()//Check num of selected Button
    {        
        selectNum++;
    }

    public void Attack()
    {

    }
}
