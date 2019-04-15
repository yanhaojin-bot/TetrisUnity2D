using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayState : FSMState
{
    double timer = 0.0d;
    private void Awake()
    {
        stateID = StateID.Play;
        AddTransition(Transition.play2pause, StateID.Pause);
        AddTransition(Transition.play2GameOver, StateID.GameOver);
    }

    public override void DoBeforeEntering()
    {
        ctrl.view.showGameUI();
    }

    public void Update()
    {
        // detect the change of state
        if (GameManager.isPause == 1 && GameManager.SpaceNum % 2 == 1 && GameManager.change == 0) {
            Debug.Log("Play2Pause");
            fsm.PerformTransition(Transition.play2pause);
            GameManager.change = 1;
        } else if (Model.checkWinOrLose() != 0 && GameManager.change == 0)
        {
            Debug.Log("Play2GameOver");
            GameManager.isPause = 2;
            fsm.PerformTransition(Transition.play2GameOver);
            GameManager.change = 1;
            
        }

        timer = 0.0d;
        if (GameManager.isPause == -1)
        {
            timer = 0.0d;
        } else
        {
            timer = Math.Round(Time.time , 2)- Math.Round(MenuState.transTime, 2);
        }

        //set HUD message
        StringBuilder textA = new StringBuilder("");
        StringBuilder textB = new StringBuilder("");
        textA.Append("DH: ");
        textA.Append(Model.HitNum);
        textA.Append("     ");
        textA.Append("IPG: ");
        textA.Append(Model.totalNum);
        textA.Append("     ");
        textA.Append("S: ");
        textA.Append(Model.score);
        textA.Append("      ");
        textA.Append("T: ");
        textA.Append(timer);

        textB.Append("R: ");
        textB.Append(Model.RNum);
        textB.Append("     ");
        textB.Append("G: ");
        textB.Append(Model.GNum);
        textB.Append("     ");
        textB.Append("B: ");
        textB.Append(Model.BNum);
        textB.Append("          ");
        textB.Append("RGB: ");
        textB.Append(Model.HorNum);
        ctrl.view.updateGameUI(String.Concat(textA), String .Concat(textB));
    }

    public override void DoBeforeLeaving()
    {

    }
}
