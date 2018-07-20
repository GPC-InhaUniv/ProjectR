using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Log 기록을 전담
/// Test 용도로 현재 IPointerClickHandler에 OnPointerClick 이벤트 사용중
/// </summary>
public class LogManager : Singleton<LogManager>, IPointerClickHandler
{
    //public static LogManager GameLog;
    protected LogManager() { }

    private FileStream logFile;
    private FileInfo debugLog;
    private DirectoryInfo folderCheck;

    private string filename;
    private string logText;

    private void Awake()
    {
        filename = "Log-" + DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss") + ".txt";
        DontDestroyOnLoad(gameObject);
    }

    void CreateLogCheck(string scriptName, string text)
    {
        if (folderCheck == null)
        {
            CreateLog(scriptName, "Create and Test log Writing");
            Debug.Log("새로 만들기");
        }
        else
        {
            WriteLog(scriptName, text);
            Debug.Log("기존거에 내용 추가");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scriptName">Log 기록을 요청한 Script의 이름</param>
    /// <param name="text">기록할 로그 내용</param>
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

    public void TestUserLog(string scriptName, string text)
    {
        Debug.Log("<color=green>" + text + "</color>");
        CreateLogCheck(scriptName, text);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CreateLogCheck("LogManager", "Test");
    }
}