﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Image[] ImageHeart;
    
    int Hp;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Hp = 3;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Enemy")){
            Attacked();
            GameManager.instance.DecreaseMonsterNum();
        }
        else if(coll.CompareTag("Boss")){
            GameManager.instance.GameOver();
        }
    }
    private void Attacked(){
        if(Hp>0){
            Hp--;
            ImageHeart[Hp].gameObject.SetActive(false);
            GetComponent<Animator>().SetTrigger("IsAttacked");
        }
        if(Hp<1){
            GetComponent<Animator>().SetTrigger("IsDead");
            GameManager.instance.GameOver();
            //게임 오버
        }
        //게임 오버
    }
    public void AnimIdle(){
        GetComponent<Animator>().SetTrigger("Idle");
    }
    public void AnimAttack(){
        GetComponent<Animator>().SetTrigger("Attack");
    }
}
