using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public Image[] StageButton;
    public Image[] DirectionPivot;
    public Image[] Star;

    bool IsStageScreen;

    private int pivotNum;
    private int temp_PivotNum;
  
    void Start()
    {
        IsStageScreen=false;
        pivotNum = PlayerPrefs.GetInt("RecentStage");
        SetStage();
    }
    void SetStage(){
        temp_PivotNum = pivotNum-1;
        SetDifficultyStar();
        for(int i=0; i<3; i++){       
            StageButton[i].GetComponent<Stage>().SetStageNum(temp_PivotNum);
            temp_PivotNum++; 
        }

        if(pivotNum <= 1){//stage1
            StageButton[0].gameObject.SetActive(false);
            DirectionPivot[0].gameObject.SetActive(false);
        }
        else if(pivotNum > 9){
            StageButton[2].gameObject.SetActive(false);            
            DirectionPivot[1].gameObject.SetActive(false);
        }
        else{
            StageButton[0].gameObject.SetActive(true);
            StageButton[2].gameObject.SetActive(true);
            DirectionPivot[0].gameObject.SetActive(true);
            DirectionPivot[1].gameObject.SetActive(true);
        }
    }
    void SetDifficultyStar(){
        for(int i=0; i<3; i++){            
            Star[i].GetComponent<DifficultyStar>().OffStar();
        }
        int num = PlayerPrefs.GetInt("RecentStage");
        for(int i=0; i<PlayerPrefs.GetInt(num.ToString()); i++){
            Star[i].GetComponent<DifficultyStar>().OnStar();
        }
    }

    public void MoveNext(){
        if(IsStageScreen == true && pivotNum < 10){                
            pivotNum++;
            SetStage();
        }
    }
    public void MovePrevious(){
        if(IsStageScreen == true && pivotNum > 1){
            pivotNum--;
            SetStage();
        }
    }

    public void SetIsStage(bool state){
        IsStageScreen = state;
    }
    public void SelectStage(){
        int gameSceneNum = PlayerPrefs.GetInt("GameScene");

        if(gameSceneNum > 0){
            PlayerPrefs.SetInt("RecentStage", pivotNum);
            SceneManager.LoadScene("GameScene");
        }
    }
}
