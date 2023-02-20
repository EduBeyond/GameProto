using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamStateManager : MonoBehaviour
{
    CamBaseState currState;

    public CamZI camZI = new CamZI();
    public CamZO camZO = new CamZO();

    void Start()
    {
        currState = camZI;
        currState.EnterState(this);
    }

    // Update is called once per frame
    public void LateUpdate()
    {
        currState.UpdateState(this);
    }

    public void SwitchState(CamBaseState camState)
    {
        currState = camState;
        camState.EnterState(this);
    }
    public IEnumerator SwitchStateDelay(CamBaseState gameState, float time)
    {
        //beingHandled = true;

        yield return new WaitForSeconds(time);

        currState = gameState;
        gameState.EnterState(this);

        //beingHandled = false;
    }
}
