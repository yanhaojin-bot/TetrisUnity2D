using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuState : FSMState
{

    public static float transTime;
    private void Awake()
    {
        stateID = StateID.Menu;
        AddTransition(Transition.StartButtonClick, StateID.Play);
    }

    private void Start()
    {

    }


    public override void DoBeforeEntering()
    {
        ctrl.view.showMenu();
    }

    public override void DoBeforeLeaving()
    {
        //Debug.Log(stateID);
        ctrl.view.hideMenu();
    }

    public void OnStartButtonClick()
    {
        Debug.Log("Button Clicked. ClickHandler.");
        GameManager.isPause = 0;
        fsm.PerformTransition(Transition.StartButtonClick);
        transTime = Time.time;
 
    }
}
