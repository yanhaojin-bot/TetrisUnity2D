using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : FSMState
{

    private void Awake()
    {
        stateID = StateID.GameOver;
    }

    public override void DoBeforeEntering()
    {
        // set message text of notification 
        string Notif = "null";
            switch (Model.checkWinOrLose())
            {
                case -1:
                    Notif = "<color=#000000>Opps! Debris are filled in the storage!</color>";
                    ctrl.view.showGameOverUI(Notif);
                    break;
                case -2:
                    Notif = "<color=#FF9900>Opps! Ionised particles are not successfully lined in the storage! </color>";
                    ctrl.view.showGameOverUI(Notif);
                    break;
                case 1:
                    Notif = "<color=#FFFF00>Congratulations! You Won! </color>";
                    ctrl.view.showGameOverUI(Notif);
                    break;
            }

    }

}
