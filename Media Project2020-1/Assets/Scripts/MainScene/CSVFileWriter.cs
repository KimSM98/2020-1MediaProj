using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
 
public class CSVFileWriter : MonoBehaviour 
{
    private List<string[]> StageScoreData = new List<string[]>();
    
    void Write(){
 
        string[] tempStageScoreData = new string[2];
        tempStageScoreData[0] = "StageNum";
        tempStageScoreData[1] = "StageScore";
        StageScoreData.Add(tempStageScoreData);
        for(int i = 0; i < 11; i++)//Stage갯수
        {
            tempStageScoreData = new string[2];
            tempStageScoreData[0] = i.ToString();
            tempStageScoreData[1] = 0.ToString();
            StageScoreData.Add(tempStageScoreData);
        }
 
        string[][] output = new string[StageScoreData.Count][];
 
        for(int i = 0; i < output.Length; i++)
        {
            output[i] = StageScoreData[i];
        }
 
        int     length         = output.GetLength(0);
        string     delimiter     = ",";
 
        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
        {
            sb.AppendLine(string.Join(delimiter, output[index]));
        }
        
        string filePath = getPath();
 
        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }
 
    private string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath +"/CSV/“+”/StageScoreData.csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+"StageScoreData.csv";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"StageScoreData.csv";
        #else
        return Application.dataPath +"/"+"StageScoreData.csv";
        #endif
    }
}

