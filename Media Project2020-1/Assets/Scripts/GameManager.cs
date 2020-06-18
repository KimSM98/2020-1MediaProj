using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public GameObject Monster;
    public static float Speed = 0.1f; //Speed: 0(Pause)
    public GameObject GameOverGroup;
    int[] SpawnEnemyArr;
    int enemyNum;
    int bossHP;

    void Awake()
    {
        instance = this;
        AssignStageInfo();
        Debug.Log("스테이지"+PlayerPrefs.GetInt("RecentStage"));
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if Game Over아니면
        Monster.GetComponent<Enemy>().Move();
        
    }
    private void AssignStageInfo(){//0618
        int stageNum = PlayerPrefs.GetInt("RecentStage");
        //스테이지 넘버에 따라 넣게 이 부분도 수정할것
        int[] Stage1 = {1, 2, 4, 8, 15};//1,2,3
        int[] Stage4 = {1,2,3,4,5,6,8,9,10,12,15,16,17,19,23};//4,5
        int[] Stage6 = {3,5,6,9,10,12,16,17,19,23};//6,7,11
        int[] Stage8 = {3,9,5,16,10};//8
        int[] Stage9 = {2,17,6,3,10};//9
        int[] Stage10 = {17,19,15,16,23};//10

        if(stageNum == 1 || stageNum == 2 || stageNum == 3) SpawnEnemyArr = Stage1;
        else if(stageNum == 4 || stageNum == 5) SpawnEnemyArr = Stage4;
        else if(stageNum == 6 || stageNum == 7 || stageNum == 11) SpawnEnemyArr = Stage6;
        else if(stageNum == 8) SpawnEnemyArr = Stage8;
        else if(stageNum == 9) SpawnEnemyArr = Stage9;
        else if(stageNum == 10) SpawnEnemyArr = Stage10;

        int[] EnemyNumArr = {15, 15, 15, 15, 25, 25, 25, 30, 30, 30, 50};
        enemyNum = EnemyNumArr[stageNum-1];
        int[] BossHpArr = {2, 3, 4, 3, 4, 4, 5, 5, 5, 5, 5};
        bossHP = BossHpArr[stageNum-1];       

    }
    public int[] GetSpawnEnemyArr(){
        return SpawnEnemyArr;
    }
    public void DecreaseEnemyNum(){
        enemyNum--;
        if(enemyNum<1){
            
        }
    }
    public int GetBossHP(){
        return bossHP;
    }
    public void GameOver(){
        GameOverGroup.SetActive(true);
    }
}
