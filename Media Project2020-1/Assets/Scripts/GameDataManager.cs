using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{//추가 필요: 사운드 버튼 On/Off 반영 // 사운드 추가되었을 때 할 것
    bool isSave;
    void Awake()
    {
        isSave = PlayerPrefs.HasKey("RecentStage");//없으면 false
        if(!isSave){//처음 실행
            for(int i=0; i < 11; i++){
                PlayerPrefs.SetInt(i.ToString(), 0);
            }
            PlayerPrefs.SetInt("RecentStage", 0);
            PlayerPrefs.SetInt("IsSoundOn", 1);
        }   
        Time.timeScale = 1;    
    }    
    void Start()
    {
        Debug.Log("저장");
        StageController.instance.SaveStageDataToJson();
    }

}
