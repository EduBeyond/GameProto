using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CamBaseState
{
    public abstract void EnterState(CamStateManager camState);

    public abstract void UpdateState(CamStateManager camState);
}