﻿using System.Collections;
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

    //0906 Editing...
    Dictionary<int, AnimatorOverrideController[]> DicMonster;
    
    void Awake()
    {        
        instance = this;
        DicAnimController = new Dictionary<int, List<AnimatorOverrideController>>();//0617
        DicEnemy = new Dictionary<int, AnimatorOverrideController>();
        DicSpawnInfo = new Dictionary<int, int[]>();
        
        //0906
        DicMonster = new Dictionary<int, AnimatorOverrideController[]>();
        //AssignDicMonster();
        //editiong..

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
    /*public void SpawnEnemy(){
        int EnemyNum = GetRandomNum();//Stage에서 등장하는 컬러num
        EnemyObj.GetComponent<Enemy>().SetColorNum(EnemyNum);//여기가 문제2
        AnimatorOverrideController[] animMonster = DicMonster[EnemyNum];

        EnemyAnim.runtimeAnimatorController = animMonster[Random.Range(0,animMonster.Length+1)];
    }
    
    private void AssignDicMonster(){
        int[] colorArray = {1,2,2,3,4,5,6,8,9,10,12,15,16,17,19,19,23};
        AnimatorOverrideController[] tempAnim = new AnimatorOverrideController[colorArray.Length];
        //colorNum이 같으면 같은 temp배열에 들어감
        int j = 0;
        for(int i=0; i<colorArray.Length; i++){
            tempAnim[j] = AnimController[i];

            if(colorArray[i] != colorArray[i++] && i != colorArray.Length-1){
                DicMonster[colorArray[i]]= tempAnim;
                j=0;
            }         
            else j++;           
            
        }

        
    } */
    //editing..
    private void AssignDic(){
        int[] colorArray = {1,2,2,3,4,5,6,8,9,10,12,15,16,17,19,19,23};
        
        //for(int i=0; i<AnimController.Length; i++){
        for(int i=0; i<colorArray.Length; i++){
            DicEnemy[colorArray[i]]= AnimController[i];
        }
    }
    
    int GetRandomNum(){
        int num = Random.Range(0,SpawnEnemyArr.Length);//여기가 문제1
        return SpawnEnemyArr[num];
    }

}
