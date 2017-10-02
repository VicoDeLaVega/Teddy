using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ProcessState2 = int;
//class ProcessState2
//{
//    public int i;
//}
//class Command2
//{
//    public int i;
//}
//public enum ProcessState2
//{
//    Idle,
//    ShowingCreateMenu,
//    ShowingUpgradeMenu,
//    Destroying,
//}

//public enum Command2
//{
//    ClickDown,
//    ClickUp,
//    ClickOutside,
//    Resume,
//    Exit
//}


//public enum ProcessState2
//{
//    Idle,
//    ShowingCreateMenu,
//    ShowingUpgradeMenu,
//    Destroying,
//}

public class PlayerGUI : MonoBehaviour
{
    const int EIdle = 0;
    const int EShowingCreateMenu = 1;

    const int SClickOutside = 0;
    const int SClickUp = 1;

    
    public GameObject goTerrain;

    public bool active = false;
    int sizeButtonW = 30;
    int sizeButtonH = 30;
    public Vector2 mousePosition;
    public int eventID=-1;
    public int state = 0;
    public FSM.Process p;
    // Use this for initialization
    void Start()
    {
        p = new FSM.Process();

        p.CurrentState = EIdle;
        p.transitions = new Dictionary<FSM.Transition, int>
            {
                { new FSM.Transition(EIdle, SClickUp), EShowingCreateMenu },
                { new FSM.Transition(EShowingCreateMenu, SClickOutside), EIdle },
                //{ new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused },
                //{ new StateTransition(ProcessState.Paused, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active }
            };
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnButtonAroundPointerAt(float x, float y, string str,int eventIDlocal)
    {
       if( GUI.Button(new Rect(x - sizeButtonW / 2, y - sizeButtonH / 2, sizeButtonW, sizeButtonH), str))
        {
            eventID = eventIDlocal;
        }

    }
    void OnGUI()
    {
            if (Input.GetMouseButtonUp(0))
        {
            active = true;
            mousePosition = Input.mousePosition;
            state = 0;
        }
    
        if (state==0)
        {

            Vector2 mp = new Vector2(mousePosition.x, Screen.height - mousePosition.y);
            SpawnButtonAroundPointerAt(mp.x, mp.y,"p",0);
            SpawnButtonAroundPointerAt(mp.x+60, mp.y, "o",1);
            state = 1;
            //   GUI.Box(new Rect(mp.x- sizeButtonW/2, mp.y- sizeButtonH/2, sizeButtonW, sizeButtonH), "P");
        }
    }
}
