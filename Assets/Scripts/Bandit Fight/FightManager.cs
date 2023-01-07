using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public FightStates curState;
    Animator fightAnim;
    public Canvas qteCanvas;

    public enum FightStates
    {
        QTEpass,
        QTEfail,
        QTEbreak,
        QTEpause,
        QTEidle
    }

    FightStates setState 
    {
        set
        {
            curState = value;

            switch (curState)
            {
                case FightStates.QTEpass:
                    fightAnim.Play("Strafe Atk 1");
                    break;

                case FightStates.QTEfail:
                    break;

                case FightStates.QTEbreak:
                    break;

                case FightStates.QTEpause:
                    break;

                case FightStates.QTEidle:
                    Debug.Log("nle");
                    fightAnim.Play("Idle.Stance");
                    break;
            }
        }
    }

    void Start()
    {
        fightAnim = GetComponent<Animator>();
        setState = FightStates.QTEidle;
        qteCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
