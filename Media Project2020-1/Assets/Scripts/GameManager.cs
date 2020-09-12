using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public float Speed = 0.1f; //Speed: 0(Pause)
    public GameObject Monster;
    public GameObject Boss;
    public GameObject GameOverGroup;
    public Text Text_KillMonsterNum;
    public Text Text_KilledMonsterNum;
    public Image GameClearImg;

    int killedMonsterNum;
    int[] SpawnEnemyArr;
    int enemyNum;
    int bossHP;
    public bool isBossMove;
    bool isMonsterMove;
    int multiple5;
    
    void Awake()
    {
        instance = this;
        AssignStageInfo();
        Debug.Log("스테이지"+PlayerPrefs.GetInt("RecentStage"));
    }
    void Start()
    {
        GameClearImg.gameObject.SetActive(false);//0619
        isMonsterMove = true;
        isBossMove = false;
        Boss.SetActive(false);
        killedMonsterNum=0;
        Text_KilledMonsterNum.text = "" + killedMonsterNum;
        multiple5 = 5; //0619
    }

    void Update()
    {
        //if Game Over아니면
        if(isMonsterMove == true) Monster.GetComponent<Enemy>().Move();
            
        if(isBossMove == true){
            if(Boss.GetComponent<Transform>().position.x<-3f) isBossMove = false;
            Boss.GetComponent<Boss>().Move();
        } 
        
    }
    private void AssignStageInfo(){//0618
        int stageNum = PlayerPrefs.GetInt("RecentStage");
        Debug.Log("Stage: " + stageNum);
        //스테이지 넘버에 따라 넣게 이 부분도 수정할것
        int[] Stage1 = {1, 2, 4, 8, 15};//1,2,3
        int[] Stage4 = {1,2,3,4,5,6,8,9,10,12,15,16,17,19,23};//4,5
        int[] Stage6 = {3,5,6,9,10,12,16,17,19,23};//6,7,11
        int[] Stage8 = {3,9,5,16,10};//8
        int[] Stage9 = {2,17,6,3,10};//9
        int[] Stage10 = {17,19,15,16,23};//10

        stageNum++;//겉모습은 1이지만 안에서는 0으로 넘버링
        if(stageNum == 1 || stageNum == 2 || stageNum == 3) SpawnEnemyArr = Stage1;
        else if(stageNum == 4 || stageNum == 5) SpawnEnemyArr = Stage4;
        else if(stageNum == 6 || stageNum == 7 || stageNum == 11) SpawnEnemyArr = Stage6;
        else if(stageNum == 8) SpawnEnemyArr = Stage8;
        else if(stageNum == 9) SpawnEnemyArr = Stage9;
        else if(stageNum == 10) SpawnEnemyArr = Stage10;

        int[] EnemyNumArr = {15, 15, 15, 15, 25, 25, 25, 30, 30, 30, 50};
        enemyNum = EnemyNumArr[stageNum];
        Text_KillMonsterNum.text = "/" + enemyNum;
        
        int[] BossHpArr = {2, 3, 4, 3, 4, 4, 5, 5, 5, 5, 5};
        bossHP = BossHpArr[stageNum];       

    }
    public int[] GetSpawnEnemyArr(){
        return SpawnEnemyArr;
    }
    public void DecreaseMonsterNum(){
        enemyNum--;
        if(enemyNum<1){//Boss Appear
            //AttackManagerScript.instance.ActiveStarButton();
            isMonsterMove = false;
            Monster.SetActive(false);
            Boss.SetActive(true);
            isBossMove = true;
        }
    }
    private void BossAppear(){
        isMonsterMove = false;
        Monster.SetActive(false);
        Boss.SetActive(true);
        isBossMove = true;
    }
    public void IncreaseKilledNum(){
        DecreaseMonsterNum();
        killedMonsterNum++;

        Text_KilledMonsterNum.text = "" + killedMonsterNum;
        //5배수가 되면 별 켜져야함
        if(killedMonsterNum/multiple5 == 1){
            AttackManagerScript.instance.ActiveStarButton();
            multiple5+=5;
        }
    }
    public int GetBossHP(){
        return bossHP;
    }
    public void GameOver(){
        GameOverGroup.SetActive(true);
        Player.instance.OffPlayerHpUI();
    }
    public int GetStarNum(){
        int starNum;
        starNum = killedMonsterNum/5;
        return starNum;
    }
    public void GameClear(){
        GameClearImg.gameObject.SetActive(true);
    }

    //치트
    public void Cheet(){
        enemyNum=0;
        DecreaseMonsterNum();
    }
    
}
