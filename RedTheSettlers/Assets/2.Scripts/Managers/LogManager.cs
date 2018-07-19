using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager : MonoBehaviour {
    public static LogManager GameLog;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scriptName"></param>
    /// <param name="text"></param>
    public void WriteLog(string scriptName, string text)
    {
        text = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + " [" + scriptName + "] " + "Log : " + text;

    }

    public void gd(string scriptName, string text)
    {
        Debug.Log("<color=green>" + text + "</color>");
        WriteLog(scriptName, text);
    }
}

