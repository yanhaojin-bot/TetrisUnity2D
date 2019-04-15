using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    [HideInInspector]
    public Model model;
    [HideInInspector]
    public View view;
    [HideInInspector]
    //public GameManager gameManager;

    private FSMSystem FSM;
    // Start is called before the first frame update
    private void Awake()
    {
        model = GameObject.FindGameObjectWithTag("Model").GetComponent<Model>();
        view = GameObject.FindGameObjectWithTag("View").GetComponent<View>();
    }

    private void Start()
    {
        MakeFSM();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    // start the finite state machine
    void MakeFSM()
    {
        FSM = new FSMSystem();
        FSMState [] states = GetComponentsInChildren<FSMState>();
        foreach(FSMState state in states)
        {
            FSM.AddState(state, this);
        }
        MenuState s = GetComponentInChildren<MenuState>();
        FSM.SetCurrentState(s);

    }
}
