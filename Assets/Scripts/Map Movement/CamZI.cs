using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZI : CamBaseState
{
    public Transform target;
    public GameObject camGO;
    public Camera cam;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(60, 50, -10);

    public override void EnterState(CamStateManager camState)
    {
        camGO = GameObject.Find("Main Camera");
        cam = camGO.GetComponent<Camera>();
        target = GameObject.Find("Player").GetComponent<Transform>();
        //cam.transform.LookAt(new Vector3(60, 90, 0));
        //cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, Quaternion.Euler(60, 90, 0), Time.deltaTime * 2.0f);
        cam.transform.rotation = Quaternion.Euler(30, -90, 0);
    }

    public override void UpdateState(CamStateManager camState)
    {
        //Vector3 v = Vector3.LerpUnclamped(transform.forward, target.position, EaseInOutBack(1.0f));
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(cam.transform.position, desiredPosition, smoothSpeed);
        cam.transform.position = smoothPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            camState.SwitchState(camState.camZO);
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
