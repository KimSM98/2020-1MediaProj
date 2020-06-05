using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public Sprite[] spr;
    public Sprite[] EffectSprites;
    Vector2 PreviousPos;
    public float Speed = 0.5f;
    public bool isMove = false;
    Rigidbody2D rigid;
    SpriteRenderer sprRenderer;
    int sprNum;
    float speedTemp;
    Dictionary<int,int> ColorSpr;
    int colorNum;
    void Start()
    {
        SetColorDictionary();
        PreviousPos = this.transform.position;
        sprRenderer = this.GetComponent<SpriteRenderer>();
        sprNum=0;
        rigid = GetComponent<Rigidbody2D>();
        this.gameObject.SetActive(false);
        speedTemp = Speed;
    }

    void Update()
    {
        if(isMove == true) Move();
        else BackToPos();
    }

    void SetColorDictionary(){        
        ColorSpr = new Dictionary<int, int>();//color,0의 시작(spr0~9)
        int[] array = {1,2,3,4,5,6,8,9,10,12,15,16,17,19,23};

        for(int i=0; i<array.Length; i++){
            ColorSpr.Add(array[i], i*10);
        }
    }

    public void Move(){
        if(this.transform.position.x > 2.25f){
            isMove = false;
            sprNum = 0;
            sprRenderer.sprite = spr[sprNum];
        } 

        this.transform.Translate(Speed*GameManager.Speed*Time.timeScale, 0,0);

    }
    void BackToPos(){
        this.transform.position = PreviousPos;
        Speed = speedTemp;
    }

    public void SetisMove(bool boolean){
        isMove = boolean;
    }
    public void StartAnim(int num){
        colorNum =num;
        StartCoroutine(Animation());
    }
    IEnumerator Animation(){
        for(int i=ColorSpr[colorNum]; i<ColorSpr[colorNum]+7; i++){
            sprRenderer.sprite = EffectSprites[i];
            yield return new WaitForSeconds(0.01f);
        }        

    }
    IEnumerator EndAnimation(){
        Speed = 0;
        for(int i = ColorSpr[colorNum]+7; i<ColorSpr[colorNum]+10; i++){
            sprRenderer.sprite = EffectSprites[i];
            yield return new WaitForSeconds(0.1f);
        }
        
        BackToPos();
        this.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Enemy")){
            StartCoroutine(EndAnimation());            
        }
    }
}
