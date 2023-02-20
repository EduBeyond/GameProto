using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZO : CamBaseState
{
    public Transform target;
    public GameObject camGO;
    public Camera cam;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public override void EnterState(CamStateManager camState)
    {
        camGO = GameObject.Find("Main Camera");
        camGO.transform.position = new Vector3(875, 262, 20);
        cam = camGO.GetComponent<Camera>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        //Debug.Log(cam);
    }

    public override void UpdateState(CamStateManager camState)
    {
        //Vector3 v = Vector3.LerpUnclamped(transform.forward, target.position, EaseInOutBack(1.0f));
        cam.transform.LookAt(target);
        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            camState.SwitchState(camState.camZI);
        }
    }

    public static float EaseInOutBack(float t)
    {
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;
        float t2 = t - 1f;
        return t < 0.5
            ? t * t * 2 * ((c2 + 1) * t * 2 - c2)
            : t2 * t2 * 2 * ((c2 + 1) * t2 * 2 + c2) + 1;
    }
}
