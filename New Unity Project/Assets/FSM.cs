using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class Transition
    {
        readonly int CurrentState;
        readonly int Command;

        public Transition(int currentState, int command)
        {
            CurrentState = currentState;
            Command = command;
        }

        public override int GetHashCode()
        {
            return 17 + 31 * CurrentState.GetHashCode() + 31 * Command.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Transition other = obj as Transition;
            return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
        }
    }
    public class Process
    {
        public Dictionary<Transition, int> transitions;
        public int CurrentState { get; set; }

        public Process()
        {
            //CurrentState = ProcessState.Inactive;
            //transitions = new Dictionary<StateTransition, ProcessState>
            //    {
            //        { new StateTransition(ProcessState.Inactive, Command.Exit), ProcessState.Terminated },
            //        { new StateTransition(ProcessState.Inactive, Command.Begin), ProcessState.Active },
            //        { new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive },
            //        { new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused },
            //        { new StateTransition(ProcessState.Paused, Command.End), ProcessState.Inactive },
            //        { new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active }
            //    };
        }

        public int GetNext(int command)
        {
            Transition transition = new Transition(CurrentState, command);
            int nextState;
            transitions.TryGetValue(transition, out nextState);
            //   if (!transitions.TryGetValue(transition, out nextState))
            //       throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
            return nextState;
        }

        public int MoveNext(int command)
        {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }
}
//public class FSM : MonoBehaviour {

//	// Use this for initialization
//	void Start () {

//	}

//	// Update is called once per frame
//	void Update () {

//	}
//}
