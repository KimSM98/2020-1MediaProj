﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public static Boss instance;
    public AnimatorOverrideController[] AnimController;
    public int Hp;
    Animator BossAnim;
    bool isBossDead;
    public Boss(){
        Hp = GameManager.instance.GetBossHP();
    }
    void Start()
    {
        isBossDead = false;
        //Hp = GameManager.instance.GetBossHP();//0619
        Debug.Log("boss" + Hp);
        instance = this;
        BossAnim = new Animator();
        BossAnim = GetComponent<Animator>();

        int ranNum = Random.Range(0,AnimController.Length);
        BossAnim.runtimeAnimatorController = AnimController[ranNum];
    }
    
    public override void Move(){
        /*if (this.transform.position.x > -3.3f){
            Debug.Log("보스 움직임 GameManagerSpee: " + GameManager.Speed + " time: "+ Time.timeScale);
            this.transform.Translate(speed*GameManager.Speed*Time.timeScale, 0, 0);
            
        }*/
        this.transform.Translate(speed*GameManager.Speed*Time.timeScale, 0, 0);
    }
    public override void Attacked()
    {
        Hp -= 1;
        if(Hp == 0){
            GetComponent<Animator>().SetTrigger("Dead");
            GameManager.instance.GameClear();
            isBossDead = true;
        }
        AttackManagerScript.instance.DecreaseStarNum(isBossDead);
    }
    public void OffObj(){
        gameObject.SetActive(false);
    }

}