using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject EnemyObj;
    public AnimatorOverrideController[] AnimController;
    Animator EnemyAnim;
    Dictionary<int,AnimatorOverrideController[]> Dic;
    void Start()
    {
        EnemyAnim = new Animator();
        EnemyAnim = EnemyObj.GetComponent<Animator>();
        EnemyAnim.runtimeAnimatorController = AnimController[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
