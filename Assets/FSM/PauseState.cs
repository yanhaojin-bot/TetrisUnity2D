using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : FSMState
{
    private void Awake()
    {
        stateID = StateID.Pause;
        AddTransition(Transition.pause2play, StateID.Play);
    }



    public override void DoBeforeEntering()
    {
        ctrl.view.showPause();
    }

    public void Update()
    {
        if (GameManager.isPause == 0 && GameManager.SpaceNum % 2 == 0 && GameManager.change == 1)
        {
            Debug.Log("Pause2Play");
            fsm.PerformTransition(Transition.pause2play);
            GameManager.change = 0;
        }
    }

    public override void DoBeforeLeaving()
    {
        ctrl.view.hidePause();
    }



}
