using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    const int StateIdle = 0;
    const int StateSelectBaseLocation = 1;
    const int StateStartingLevel = 2;
    const int StatePlaying = 3;
    const int StateWin = 4;
    const int StateLose = 5;
    const int StateInGameMenu = 6;


    const int TransitionStarted = 0;
    const int TransitionRestorePreviousGame=1;
    const int TransitionBaseSelected = 2;
    const int TransitionFinished = 3;
    const int TransitionBaseDestroyed = 4;
    const int TransitionAllEnemiesDestroyed = 5;
    const int TransitionOpenInGameMenu = 6;
    const int TransitionCloseInGameMenu = 7;
    const int TransitionNoBaseYet = 8;
    const int TransitionLevelReady = 9;

    PlayerController pc;
    FSM.Process fsmProcess;
    LevelController currentLevel;
	// Use this for initialization
	void Start () {
        pc = PlayerController.GetPlayerController();
        fsmProcess = new FSM.Process();
        fsmProcess.CurrentState = StateIdle;

        fsmProcess.transitions = new Dictionary<FSM.Transition, int>
            {
                { new FSM.Transition(StateIdle, TransitionStarted), StateStartingLevel },
                { new FSM.Transition(StateIdle, TransitionNoBaseYet), StateSelectBaseLocation },
                { new FSM.Transition(StateSelectBaseLocation, TransitionBaseSelected), StateStartingLevel },
                { new FSM.Transition(StateStartingLevel, TransitionLevelReady), StatePlaying },
                { new FSM.Transition(StatePlaying, TransitionBaseDestroyed), StateLose },
                { new FSM.Transition(StatePlaying, TransitionAllEnemiesDestroyed), StateWin},
                //{ new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused },
                //{ new StateTransition(ProcessState.Paused, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active }
            };
    }
	LevelController GetCurrentLevel()
    {
        return pc.Level0;
    }
	// Update is called once per frame
	void Update () {
        currentLevel = pc.Level0;

        if (fsmProcess.CurrentState == StateIdle)
        {
            Utils.TDDebug("pb:StateIdle");
            if (currentLevel.hasPlayerBase == false)
            {
                Utils.TDDebug("TransitionNoBaseYet");
                fsmProcess.MoveNext(TransitionNoBaseYet);
                return;
            }
            else
            {
                Utils.TDDebug("TransitionStarted");
                fsmProcess.MoveNext(TransitionStarted);
                return;
            }
        }

        if(fsmProcess.CurrentState == StateSelectBaseLocation)
        {
            Utils.TDDebug("pb:StateSelectBaseLocation");
            pc.PlaceBaseLocationTarget();
            if (pc.IsBaseReady())
            {
                pc.StartLevel();
                Utils.TDDebug("pb:TransitionBaseSelected");
                fsmProcess.MoveNext(TransitionBaseSelected);
                return;
            }
        }

        if (fsmProcess.CurrentState == StateStartingLevel)
        {
            Utils.TDDebug("pb:StateStartingLevel");
         //  fsmProcess.MoveNext(TransitionStarted);
            return;
        }
    }
}
