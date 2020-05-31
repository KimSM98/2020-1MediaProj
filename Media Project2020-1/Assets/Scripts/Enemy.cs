﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public float speed = 0.1f;

    public int Hp { get; set; }
   // public float speed { get; set; }

    private float xPos;
    private float yPos;

    public Enemy()
    {
        Hp = 1;
        //speed = 0.1f;
    }

    public void Hit()
    {

    }

    public void Move()
    {
        Debug.Log("이동");
        if (this.transform.position.x > -3.3f)
            this.transform.Translate(-0.1f*GameManager.Speed*Time.timeScale, 0, 0);
        else
            this.transform.position = new Vector2(xPos, yPos);
    }

    void Start()
    {
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
    }
    
}