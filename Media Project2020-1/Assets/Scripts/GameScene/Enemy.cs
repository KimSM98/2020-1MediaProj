using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = -0.1f;

    public int Hp { get; set; }
   // public float speed { get; set; }

    private Vector2 firstPos;
    
    public Enemy()
    {
        Hp = 1;
        //speed = 0.1f;
    }

    public void Attacked()
    {
        Hp -= 1;
        if(Hp == 0){
            GetComponent<Animator>().SetTrigger("Dead");
        }
        //GetComponent<Animator>().
    }

    public void Move()
    {
        Debug.Log("이동");
        if (this.transform.position.x > -3.3f)
            this.transform.Translate(speed*GameManager.Speed*Time.timeScale, 0, 0);
        else
            this.transform.position = firstPos;
    }

    public void ResetObj(){        
        Hp=1;
        gameObject.SetActive(false);
        transform.position = firstPos;
        gameObject.SetActive(true);


    }

    void Start()
    {
        firstPos = this.transform.position;
    }
    
}
