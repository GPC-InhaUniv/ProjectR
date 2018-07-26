using UnityEngine;

public class TestTimerScr : MonoBehaviour {

    [SerializeField]
    GameTimer timer;

    GameObject skill_1_Obj;
    GameTimer skill_1_Timer;
    GameObject skill_2_Obj;
    GameTimer skill_2_Timer;

    private void Start()
    {
        skill_1_Obj = Instantiate(timer.gameObject);
        skill_1_Obj.transform.parent = transform;
        skill_1_Timer = skill_1_Obj.GetComponent<GameTimer>();
        skill_1_Timer.SetTimer(3.0f, true);
        skill_1_Timer.Callback = new TimerCallback(execute);
        skill_1_Timer.StartTimer();

        skill_2_Obj = Instantiate(timer.gameObject);
        skill_2_Obj.transform.parent = transform;
        skill_2_Timer = skill_2_Obj.GetComponent<GameTimer>();
        skill_2_Timer.SetTimer(2.0f, true);
        skill_2_Timer.Callback = new TimerCallback(execute2);
        skill_2_Timer.StartTimer();
    }

    void execute()
    {
        Debug.Log("callback execute");
    }

    void execute2()
    {
        Debug.Log("callback execute2");       
    }

    
}
