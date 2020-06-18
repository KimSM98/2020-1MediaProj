using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public static EnemyManagerScript instance;
    public GameObject EnemyObj;
    public AnimatorOverrideController[] AnimController;
    Animator EnemyAnim;
   // Dictionary<int,AnimatorOverrideController[]> Dic;//이부분 수정
    Dictionary<int,AnimatorOverrideController> DicEnemy; //AnimControllerNum, Color
 
    int[] SpawnEnemyArr;
    Dictionary<int, int[]> DicSpawnInfo;
    Dictionary<int, List<AnimatorOverrideController>> DicAnimController;

    void Awake()
    {        
        instance = this;
        DicAnimController = new Dictionary<int, List<AnimatorOverrideController>>();//0617
        DicEnemy = new Dictionary<int, AnimatorOverrideController>();
        DicSpawnInfo = new Dictionary<int, int[]>();

        AssignDic();
        //AssignSpawnEnemyNum();
    }
    void Start()
    {
        //0618
        SpawnEnemyArr = GameManager.instance.GetSpawnEnemyArr();
        //0618
        EnemyAnim = new Animator();
        EnemyAnim = EnemyObj.GetComponent<Animator>();
        //0616
        SpawnEnemy();
        //EnemyAnim.runtimeAnimatorController = AnimController[0];//Enemy애니메이션 세팅
    }
    public void SpawnEnemy(){
        int EnemyNum = GetRandomNum();//Stage에서 등장하는 컬러num
        EnemyObj.GetComponent<Enemy>().SetColorNum(EnemyNum);//여기가 문제2
        EnemyAnim.runtimeAnimatorController = DicEnemy[EnemyNum];
    }
    
    private void AssignDic(){
        int[] colorArray = {1,2,2,3,4,5,6,8,9,10,12,15,16,17,19,19,23};
        
        //for(int i=0; i<AnimController.Length; i++){
        for(int i=0; i<colorArray.Length; i++){
            DicEnemy[colorArray[i]]= AnimController[i];
        }
    }
    

    private void AssignSpawnEnemyNum(){//0616
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
        /*for(int i=1; i<4; i++) DicSpawnInfo[i] = Stage1;
        for(int i=4; i<6; i++) DicSpawnInfo[i] = Stage4;        
        for(int i=6; i<7; i++) DicSpawnInfo[i] = Stage6;
        DicSpawnInfo[8] = Stage8;        
        DicSpawnInfo[9] = Stage9;        
        DicSpawnInfo[10] = Stage10;        
        DicSpawnInfo[11] = Stage6; 

        SpawnEnemyArr = DicSpawnInfo[stageNum];*/

    }
    int GetRandomNum(){
        int num = Random.Range(0,SpawnEnemyArr.Length);//여기가 문제1
        return SpawnEnemyArr[num];
    }

}
