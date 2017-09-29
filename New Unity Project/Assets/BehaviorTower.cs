using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ProcessState
{
    Patrolling,
    Attacking,
    Building,
    Destroying,
}

public enum Command
{
    SeeEnemy,
    DoNotSeeEnemy,
    Pause,
    Resume,
    Exit
}
public class StateTransition
{
    readonly ProcessState CurrentState;
    readonly Command Command;

    public StateTransition(ProcessState currentState, Command command)
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
        StateTransition other = obj as StateTransition;
        return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
    }
}
public class Process
{
   

    public Dictionary<StateTransition, ProcessState> transitions;
    public ProcessState CurrentState { get;  set; }

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

    public ProcessState GetNext(Command command)
    {
        StateTransition transition = new StateTransition(CurrentState, command);
        ProcessState nextState;
        transitions.TryGetValue(transition, out nextState);
     //   if (!transitions.TryGetValue(transition, out nextState))
     //       throw new Exception("Invalid transition: " + CurrentState + " -> " + command);
        return nextState;
    }

    public ProcessState MoveNext(Command command)
    {
        CurrentState = GetNext(command);
        return CurrentState;
    }
}


public class BehaviorTower : MonoBehaviour {
    public Enemy target0;
   // public List<Enemy> enemies;
    public ParticleSystem muzzleFlashPS;
    public float rangeAttack = 1000;
    public float minDist = 1000000;
    public int damages = 10;
    Process p;
    public void SetNearestEnemy()
    {
       //foreach (Enemy enemy in enemies)
       // {
       //     float distsq = (enemy.transform.position - transform.position).sqrMagnitude ;
       //     if(/*distsq < rangeAttack &&*/ distsq < minDist)
       //     {
       //         target0 = enemy;
       //         minDist = distsq;
       //     }
       // }
    }
    public Enemy GetNearestEnemy()
    {
        target0 = null;
       

        foreach (GameObject enemy in OpponentController.instance.instances)
        {
            float distsq = (enemy.transform.position - transform.position).sqrMagnitude;
            if (distsq < rangeAttack && distsq < minDist)
            {
                target0 = enemy.GetComponent<Enemy>();
                minDist = distsq;
            }
        }
        return target0;
    }
    // Use this for initialization
    void Start () {
        p = new Process();

        p.CurrentState = ProcessState.Patrolling;
        p.transitions = new Dictionary<StateTransition, ProcessState>
            {
                { new StateTransition(ProcessState.Patrolling, Command.SeeEnemy), ProcessState.Attacking },
                { new StateTransition(ProcessState.Attacking, Command.DoNotSeeEnemy), ProcessState.Patrolling },
                //{ new StateTransition(ProcessState.Active, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Active, Command.Pause), ProcessState.Paused },
                //{ new StateTransition(ProcessState.Paused, Command.End), ProcessState.Inactive },
                //{ new StateTransition(ProcessState.Paused, Command.Resume), ProcessState.Active }
            };
        //Console.WriteLine("Current State = " + p.CurrentState);
        //Console.WriteLine("Command.Begin: Current State = " + p.MoveNext(Command.Begin));
        //Console.WriteLine("Command.Pause: Current State = " + p.MoveNext(Command.Pause));
        //Console.WriteLine("Command.End: Current State = " + p.MoveNext(Command.End));
        //Console.WriteLine("Command.Exit: Current State = " + p.MoveNext(Command.Exit));
        //Console.ReadLine();
    }
	
	// Update is called once per frame
	void Update () {
        if (p.CurrentState == ProcessState.Patrolling)
        {
            //  Debug.Log("Patrolling");
            muzzleFlashPS.Stop();
            if (GetNearestEnemy() != null)
            {
                p.MoveNext(Command.SeeEnemy);
            }
            
        }
        if (p.CurrentState == ProcessState.Attacking)
        {
           // Debug.Log("Attacking");
       
            if (target0.IsDestroyed() )
            {
                p.MoveNext(Command.DoNotSeeEnemy);
                //  enemies.Remove(target0);
                OpponentController.instance.instances.Remove(target0.gameObject);
                target0 = null;
            }

            if (target0 != null)
            {
                muzzleFlashPS.Play();
                transform.LookAt(target0.transform.position);
                if (target0.lifePoints > 0)
                    target0.Hit(damages);
            }
        }
    }
}
