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
    // Transitions
    const int TransitionClickOutside = 0;
    const int TransitionClickUp = 1;
    const int TransitionCreateTower = 2;
    const int TransitionFinished = 3;
    const int TransitionDownMoving = 4;
    const int TransitionUp = 5;
    public bool MouseButtonUp = false;
    public bool MouseButtonDown = false;
    public Vector3 moveDiff;
    public float moveDiffMagnitude;
    void Start () {

        fsmProcess = new FSM.Process();

        fsmProcess.CurrentState = StateIdle;
        fsmProcess.transitions = new Dictionary<FSM.Transition, int>
            {
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
    void Update()
    {
       
        MouseButtonUp = Input.GetMouseButtonUp(0);
        MouseButtonDown = Input.GetMouseButtonDown(0);
        if (fsmProcess.CurrentState == StateClear)
        {
            Debug.Log("StateClear");
            CreateTowersMenuCanvas.enabled = false;
            MouseButtonUp = false;
            fsmProcess.MoveNext(TransitionFinished);
            InvisibleCanvas.enabled = false;
            return;
        }
        if (fsmProcess.CurrentState == StateDrag)
        {
            InvisibleCanvas.enabled = false;
            Debug.Log("StateDrag");
            if (MouseButtonUp)
            {
                fsmProcess.MoveNext(TransitionUp);
                Debug.Log("TransitionUp");
                return;
            }
        }
        if (fsmProcess.CurrentState == StateIdle)
        {
            //  Debug.Log("StateIdle");
           moveDiff = mousePosition - Input.mousePosition;
            moveDiffMagnitude = moveDiff.magnitude;
            InvisibleCanvas.enabled = false;
            if (MouseButtonDown&& moveDiffMagnitude > 0)
            {
                fsmProcess.MoveNext(TransitionDownMoving);
                return;
            }
            mousePosition = Input.mousePosition;
            if (MouseButtonUp)
            {
                fsmProcess.MoveNext(TransitionClickUp);
                return;
            }
        }
       

        if (fsmProcess.CurrentState == StateShowingCreateMenu)
        {
            Debug.Log("StateShowingCreateMenu");
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
        Debug.Log("ClickOutsideButton");
        if (fsmProcess.CurrentState == StateShowingCreateMenu)
        {
            fsmProcess.MoveNext(TransitionClickOutside);
        }
    }
    public void SpawnTower()
    {
        Debug.Log("SpawnTower");
        fsmProcess.MoveNext(TransitionCreateTower);
    }

    public void SpawnTowerType0()
    {
        Debug.Log("SpawnTowerType0");
        PlayerController.GetPlayerController().SpawnTower(mousePosition);
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void SpawnTowerType1()
    {
        Debug.Log("SpawnTowerType1");
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void SpawnTowerType2()
    {
        Debug.Log("SpawnTowerType2");
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void SpawnTowerType3()
    {
        Debug.Log("SpawnTowerType3");
        fsmProcess.MoveNext(TransitionCreateTower);
    }
    public void UpgradeTower()
    {
        Debug.Log("UpgradeTower");
        fsmProcess.MoveNext(TransitionCreateTower);
    }
}
