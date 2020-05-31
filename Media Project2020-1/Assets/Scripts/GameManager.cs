using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Monster;
    public static float Speed = 0.1f; //Speed: 0(Pause)
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if Game Over아니면
        Monster.GetComponent<Enemy>().Move();
        
    }
}
