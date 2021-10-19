using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    enum States { UP, DOWN, IDLE} //Spikes states
    FSMstateMachine<States> fsm = new FSMstateMachine<States>();

    [SerializeField] private int damage; //Damage done by spikes
    [SerializeField] private float speedUp, speedDown; //Speed when going up or down
    [SerializeField] private float idleWaitTime; //Time after the next state
    [SerializeField] private Transform downPoint, upPoint;//Target position when it goes down or up
    private float timerWait = 0f;
    private bool isUp; //check if the spikes are up


    void Start()
    {
        isUp = false;
        //Add spike states 
        fsm.AddState(GoUp, States.UP);
        fsm.AddState(GoDown, States.DOWN);
        fsm.AddState(GoIdle, States.IDLE);

        //First state
        fsm.ChangeState(States.IDLE);
    }

    void Update()
    {
        fsm.Update();
    }

    private void GoUp(FSMEVENT _event)
    {
        if (_event == FSMEVENT.EXIT) return;

        //start going up
        transform.position = Vector3.MoveTowards(transform.position, upPoint.position, speedUp * Time.deltaTime);
        if (transform.position.y == upPoint.position.y)
        {
            isUp = true;
            fsm.ChangeState(States.IDLE);
        }
    }

    private void GoDown(FSMEVENT _event)
    {
        if (_event == FSMEVENT.EXIT) return;

        //start going down
        transform.position = Vector3.MoveTowards(transform.position, downPoint.position, speedDown * Time.deltaTime);
        if (transform.position.y == downPoint.position.y)
        {
            isUp = false;
            fsm.ChangeState(States.IDLE);
        }
    }

    private void GoIdle(FSMEVENT _event)
    {
        if (_event == FSMEVENT.EXIT) return;

        if (_event == FSMEVENT.START)
        {
            timerWait = idleWaitTime;
        }
        else if (_event == FSMEVENT.UPDATE)
        {
            timerWait -= Time.deltaTime;
            if (timerWait <= 0f)
            {
                //Decide to go up or down after the Idle
                if(isUp)
                    fsm.ChangeState(States.DOWN);
                else
                    fsm.ChangeState(States.UP);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Damage player
            collision.gameObject.GetComponent<Player>().Health -= damage;
        }
    }

}
