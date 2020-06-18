using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Main_UIManager : MonoBehaviour
{
    public GameObject[] Scene;
    public Image ImagePAB;
    private int sceneNum;
    void Start()
    {
        sceneNum = 0;
        StartCoroutine(ImageAnimation());
    }

    public void PressAnyButton(){
        if(sceneNum < 1){
            PlayerPrefs.SetInt("GameScene", 1);
            Scene[0].SetActive(false);
            Scene[1].SetActive(true);
            sceneNum++;
            GetComponent<StageManager>().SetIsStage(true);
        }       
    }

    IEnumerator ImageAnimation(){//텍스트 깜빡이기
        ImagePAB.color = new Vector4(1f,1f,1f,0f);
        yield return new WaitForSeconds(0.5f);
        ImagePAB.color = new Vector4(1f,1f,1f,1f);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ImageAnimation());
    }
    //게임 종료버튼
    

}
