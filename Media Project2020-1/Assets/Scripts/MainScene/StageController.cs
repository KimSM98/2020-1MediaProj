using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageController : MonoBehaviour
{  
    public static StageController instance;
    public StageData stageData;

    void Awake()
    {
        instance = this;
    }
    
    [ContextMenu("To Json Data")]
    public void SaveStageDataToJson(){//게임종료후 홈으로 돌아오는 버튼으로 실행?
        //stageData.SaveScore(0,1);//이런 식으로 저장
        string jsonData = JsonUtility.ToJson(stageData,true);
        string path = Path.Combine(Application.dataPath,"stageData.json");
        File.WriteAllText(path, jsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadStageDataFromJson(){
        string path = Path.Combine(Application.dataPath, "stageData.json");
        string jsonData = File.ReadAllText(path);
        stageData = JsonUtility.FromJson<StageData>(jsonData);
    }

    public int GetStageScore(int stageNum){
        return stageData.GetScore(stageNum);
    }
    public void SaveStageScore(int stageNum, int score){
        stageData.Save(stageNum, score);
        SaveStageDataToJson();
    }
   
}
[System.Serializable]
public class StageData
{
    public static StageData instance;
    public int[] StageScores;
    void Awake()
    {
        instance = this;
    }
    public void Save(int stageNum, int score){
        StageScores[stageNum] = score;
    }
    public int GetScore(int stageNum){
        return StageScores[stageNum];
    }
}
