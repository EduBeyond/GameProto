using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node up;
    public Node down;
    public Node left;
    public Node right;
    public GameObject go;

    public Node(GameObject g, string name, Node u = null, Node d = null, Node l = null, Node r = null)
    {
        up = u;
        down = d;
        left = l;
        right = r;
        go = g;
    }
}
