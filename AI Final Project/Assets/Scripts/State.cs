using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{

    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK,SLEEP
    }
    
    public enum EVENT
    {
        ENTER, UPDATE,EXIT
    }

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;

    private float visDist = 10;
    float visAngle = 30;
    private float shootDis = 7;


    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
    }

    public virtual void Enter()
    {
        stage = EVENT.UPDATE;
    }
    
    public virtual void Update()
    {
        stage = EVENT.UPDATE;
    }
    
    public virtual void Exit()
    {
        stage = EVENT.EXIT;
    }

    public State Process()
    {
        if (stage == EVENT.ENTER)
        {
            Enter();
        }else if (stage == EVENT.UPDATE)
        {
            Update();
        }else if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }

        return this;
    }
}
