using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIEventManager : MonoBehaviour {
    public float sams;
    public Vector3 mousePosition;
    public List<GameObject> CreateTowersMenu;
    public List<Vector3> CreateTowersMenuOffsets;
    public List<GameObject> UpgradeTowersMenu;
    public Canvas CreateTowersMenuCanvas;
    public Canvas InvisibleCanvas;
    // Use this for initialization
    public FSM.Process fsmProcess;

 

    // States
    const int StateIdle = 0;
    const int StateShowingCreateMenu = 1;
    const int StateClear = 2;
    const int StateDrag = 3;
    const int StateWaitToStart = 4;
    // Transitions
    const int TransitionClickOutside = 0;
    const int TransitionClickUp = 1;
    const int TransitionCreateTower = 2;
    const int TransitionFinished = 3;
    const int TransitionDownMoving = 4;
    const int TransitionUp = 5;
    const int TransitionLevelReady=6;

    public bool MouseButtonUp = false;
    public bool MouseButtonDown = false;
    public Vector3 moveDiff;
    public float moveDiffMagnitude;
    public int frame = 0;
    public bool MouseDownPressed = false;
    public Vector3 SpawnTowerPosition;
        
    void Start () {

        fsmProcess = new FSM.Process();

        fsmProcess.CurrentState = StateWaitToStart;
        fsmProcess.transitions = new Dictionary<FSM.Transition, int>
            {
                { new FSM.Transition(StateWaitToStart, TransitionLevelReady), StateIdle },
                { new FSM.Transition(StateIdle, TransitionClickUp), StateShowingCreateMenu },
                { new FSM.Transition(StateIdle, TransitionDownMoving), StateDrag },
                { new FSM.Transition(StateDrag, TransitionUp), StateClear },
                { new FSM.Transition(StateShowingCreateMenu, TransitionClickOutside), StateClear },
                { new FSM.Transition(StateShowingCreateMenu, TransitionCreateTower), StateClear },
                { new FSM.Transition(StateClear, TransitionFinished), StateIdle },
                //{ new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused },
                //{ new StateTransition(ProcessState.Paused, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active }
            };
        CreateTowersMenuCanvas.enabled=(false);
     
    }
    void OnGUI()
    {
        //if(GUI.Button(new Rect(0,0, Screen.width, Screen.height), "P"))
        //{
        //    fsmProcess.MoveNext(TransitionClickOutside);
        //}

    }
    // Update is called once per frame
    void UpdateInputs()
    {
  //      MouseButtonUp = Input.GetMouseButtonUp(0);
        MouseButtonDown = Input.GetMouseButtonDown(0);
    }
    void Update()
    {
        frame++;
        if(fsmProcess.CurrentState == StateWaitToStart)
        {
            if (PlayerController.GetPlayerController().Level0.HasStarted())
            {
                fsmProcess.MoveNext(TransitionLevelReady);
                return;
            }
        }
       if (fsmProcess.CurrentState == StateClear)
        {
            Utils.TDDebug("StateClear");
            MouseButtonUp = false;
            MouseButtonDown = false;
            CreateTowersMenuCanvas.enabled = false;
            InvisibleCanvas.enabled = false;
            Utils.TDDebug("TransitionFinished");
            fsmProcess.MoveNext(TransitionFinished);
            return;
        }

        if (fsmProcess.CurrentState == StateDrag)
        {
            InvisibleCanvas.enabled = false;
            UpdateInputs();
            Utils.TDDebug("StateDrag");
            if (MouseButtonDown==false)
            {
                fsmProcess.MoveNext(TransitionUp);
                Utils.TDDebug("TransitionUp");
                return;
            }
        }

        if (fsmProcess.CurrentState == StateIdle)
        {
            UpdateInputs();
            if(MouseButtonDown)
            {
                Utils.TDDebug("MouseDownPressed");
                MouseDownPressed = true;
            }

            Utils.TDDebug("StateIdle");
            moveDiff = mousePosition - Input.mousePosition;
            mousePosition = Input.mousePosition;
            PlaceSpotTarget();
            moveDiffMagnitude = moveDiff.magnitude;
            InvisibleCanvas.enabled = false;
            if (MouseButtonDown&& moveDiffMagnitude > 0)
            {
                Debug.Log("moveDiffMagnitude:" + moveDiffMagnitude);
                Utils.TDDebug("TransitionDownMoving");
                fsmProcess.MoveNext(TransitionDownMoving);
                MouseDownPressed = false;
                return;
            }
            if (MouseButtonDown == false && MouseDownPressed == true)
            {
                Utils.TDDebug("MouseButtonDownReleased");
                MouseDownPressed = false;
                MouseButtonUp = true;
                Utils.TDDebug("TransitionUp");
                mousePosition = Input.mousePosition;
                fsmProcess.MoveNext(TransitionClickUp);
                return;
            }
            //if (MouseButtonUp)
            //{
            //    Utils.TDDebug("TransitionUp");
            //    fsmProcess.MoveNext(TransitionClickUp);
            //    return;
            //}
        }

        if (fsmProcess.CurrentState == StateShowingCreateMenu)
        {
            Utils.TDDebug("StateShowingCreateMenu");

            Vector3 Inputpos = new Vector3(mousePosition.x, mousePosition.y, 0);
            for (int i = 0; i < CreateTowersMenu.Count; i++)
            {
                CreateTowersMenu[i].transform.position = Inputpos + CreateTowersMenuOffsets[i];
            }
            CreateTowersMenuCanvas.enabled = true;
            InvisibleCanvas.enabled = true;
            return;
        }
      

    }
    public void ClickOutsideButton()
    {
        Utils.TDDebug("ClickOutsideButton");
        if (fsmProcess.CurrentState == StateShowingCreateMenu)
        {
            fsmProcess.MoveNext(TransitionClickOutside);
        }
    }
    public void PlaceSpotTarget()
    {
        PlayerController.GetPlayerController().PlaceSpotTarget(mousePosition);
    }
    public void SpawnTower()
    {
        Debug.Log("SpawnTower");
        fsmProcess.MoveNext(TransitionCreateTower);
    }

    public void SpawnTowerType0()
    {
        Debug.Log("SpawnTowerType0");
        TowerFactory.GetInstance().SpawnTower(mousePosition,0);
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void SpawnTowerType1()
    {
        Debug.Log("SpawnTowerType1");
        TowerFactory.GetInstance().SpawnTower(mousePosition, 1);
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void SpawnTowerType2()
    {
        Debug.Log("SpawnTowerType2");
        TowerFactory.GetInstance().SpawnTower(mousePosition, 2);
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void SpawnTowerType3()
    {
        Debug.Log("SpawnTowerType3");
        TowerFactory.GetInstance().SpawnTower(mousePosition, 3);
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void UpgradeTower()
    {
        Debug.Log("UpgradeTower");
        fsmProcess.MoveNext(TransitionCreateTower);
    }
}
