using System.Collections;
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
        //Hp = GameManager.instance.GetBossHP();
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
        if (this.transform.position.x > -3.3f){
            this.transform.Translate(speed*GameManager.instance.Speed*Time.timeScale, 0, 0);            
        }
    }
    public override void Attacked()
    {
        Hp -= 1;
        if(Hp == 0){
            isBossDead = true;
            GetComponent<Animator>().SetTrigger("Dead");
            GameManager.instance.GameClear();
        }
        AttackManagerScript.instance.DecreaseStarNum(isBossDead);
    }
    public void OffObj(){
        gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D coll){
        if(CompareTag("Player") && isBossDead != true){
            Debug.Log("보스랑 부딪힘");
            GameManager.instance.GameOver();
            coll.GetComponent<Player>().AnimDead();
        }
    }

}
