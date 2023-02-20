using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject villageGO;
    public GameObject caveGO;
    public GameObject bridgeGO;
    public GameObject banditGO;

    public Node village;
    public Node cave;
    public Node bridge;
    public Node bandit;
    public Node curNode;

    void Start()
    {
        villageGO = GameObject.Find("Village Node");
        caveGO = GameObject.Find("Cave Node");
        bridgeGO = GameObject.Find("Bridge Node");
        banditGO = GameObject.Find("Bandit Node");

        village = new Node(villageGO, "village");
        cave = new Node(caveGO, "cave");
        bridge = new Node(bridgeGO, "bridge");
        bandit = new Node(banditGO, "bandit");

        curNode = village;
        village.right = cave;
        cave.left = village;
        cave.up = bridge;
        bridge.down = cave;
        bridge.up = bandit;
        bridge.left = bandit;
        bandit.down = bridge;
        bandit.right = bridge;
    }   
}

