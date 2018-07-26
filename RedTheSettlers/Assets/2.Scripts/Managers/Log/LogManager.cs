﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 디버그 LogColor 선택을 위한 Type 값
/// 자신의 색상값 잘 기억해둘 것
/// </summary>
public enum LogColor
{
    Orange,
    Olive,
    Green,
    Teal,
    Blue,
    Navy,
    Purple,
    Magenta,
    Brown,
}

/// <summary>
/// Log 기록을 전담
/// Test 용도로 현재 IPointerClickHandler에 OnPointerClick 이벤트 사용중
/// </summary>
public class LogManager : Singleton<LogManager>/*, IPointerClickHandler*/
{
    private static LogManager logManager;
    protected LogManager() { }

    private FileStream logFile;
    private FileInfo debugLog;
    private DirectoryInfo folderCheck;

    private string filename;
    private string className;
    private string logText;

    private void Awake()
    {
        filename = "Log-" + DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + ".txt";
        logManager = this;
        DontDestroyOnLoad(gameObject);
    }

    void CreateLogCheck(string scriptName, string text)
    {
        if (folderCheck == null)
        {
            CreateLog(scriptName, text);
            //Debug.Log("새로 만들기");
        }
        else
        {
            WriteLog(scriptName, text);
            //Debug.Log("기존거에 내용 추가");
        }
    }

    
    void CreateLog(string scriptName, string text)
    {
        folderCheck = new DirectoryInfo("./Log");
        folderCheck.Create();
        debugLog = new FileInfo("./log/" + filename);

        if (!debugLog.Exists)
        {
            logFile = debugLog.Create();
            logFile.Close();
        }

        logText = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + " [" + scriptName + "] " + "Log : " + text;
        File.AppendAllText("./log/" + filename, logText + "\n");
    }

    void WriteLog(string scriptName, string text)
    {
        logText = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + " [" + scriptName + "] " + "Log : " + text;
        File.AppendAllText("./log/" + filename, logText + "\n");
    }

    /// <summary>
    /// 프로젝트 진행 중 DebugLog 대체용 Log 메서드
    /// </summary>
    /// <param name="logColor">유니티 Console에 표시할 Log 색상</param>
    /// <param name="scriptName">Log 기록을 요청한 Script(클래스)의 명칭</param>
    /// <param name="text">기록할 로그 내용 " " 안에 원하는 내용 기입하는 것으로 내용 입력</param>
    public void UserDebug(LogColor logColor, string scriptName, string text)
    {
        Debug.Log("<color="+logColor+">" + text + "</color>");
        CreateLogCheck(scriptName, text);
    }
}