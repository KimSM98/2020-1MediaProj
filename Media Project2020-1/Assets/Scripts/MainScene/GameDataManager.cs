using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    bool isSave;

    void Awake()
    {
        isSave = PlayerPrefs.HasKey("RecentStage");
        if(!isSave){//처음 실행
            for(int i=1; i < 11; i++){
                PlayerPrefs.SetInt(i.ToString(), 0);
            }
            PlayerPrefs.SetInt("RecentStage", 1);
        }       
    }

    
}
