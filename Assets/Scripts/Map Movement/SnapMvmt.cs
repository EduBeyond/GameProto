using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapMvmt : MonoBehaviour
{
    public bool IsMoving;
    private Vector3 OrigPos, UnitTargetPos;
    private float TimeToMove = 0.3f;

    public GameObject player;
    private GenerateMap map;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        map = player.GetComponent<GenerateMap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !IsMoving && map.curNode.up != null)
        {
            StartCoroutine(MoveSelectedUnit(GetDistance(map.curNode.go, map.curNode.up.go), player));
            map.curNode = map.curNode.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !IsMoving && map.curNode.down != null)
        {
            StartCoroutine(MoveSelectedUnit(GetDistance(map.curNode.go, map.curNode.down.go), player));
            map.curNode = map.curNode.down;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !IsMoving && map.curNode.right != null)
        {
            StartCoroutine(MoveSelectedUnit(GetDistance(map.curNode.go, map.curNode.right.go), player));
            map.curNode = map.curNode.right;

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !IsMoving && map.curNode.left != null)
        {
            StartCoroutine(MoveSelectedUnit(GetDistance(map.curNode.go, map.curNode.left.go), player));
            map.curNode = map.curNode.left;
        }
    }

    public Vector3 GetDistance(GameObject a, GameObject b)
    {
        Vector3 av = a.transform.position;
        Vector3 bv = b.transform.position;
        return (bv - av);
    }

    public IEnumerator MoveSelectedUnit(Vector3 direction, GameObject player)
    {
        IsMoving = true;

        float ElapsedTime = 0;

        OrigPos = player.transform.position;
        UnitTargetPos = OrigPos + direction;

        while (ElapsedTime < TimeToMove)
        {
            player.transform.position = Vector3.Lerp(OrigPos, UnitTargetPos, (ElapsedTime / TimeToMove));
            ElapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = UnitTargetPos;
        IsMoving = false;
    }
}