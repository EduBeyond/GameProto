using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightOutcomes : MonoBehaviour
{
    public bool initiated;
    public bool dodged;
    public bool hit;
    public bool ip;
    public bool success;
    public bool over = false;
    public int playerAtk; //0=360atk
    public int enemyReaction; //0=hitby360
    public int cur; //0 = dodging, 1 = initiating
}
