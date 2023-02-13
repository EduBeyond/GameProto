using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

#if UNITY_2019_4_OR_NEWER && ENABLE_INPUT_SYSTEM
using KeyCode = UnityEngine.InputSystem.Key;
using UnityEngine.InputSystem.LowLevel;
#endif

#if UNITY_2018 && ENABLE_INPUT_SYSTEM
using KeyCode = UnityEngine.Experimental.Input.Key;
using UnityEngine.Experimental.Input.LowLevel;
#endif

#if !ENABLE_INPUT_SYSTEM
#endif


public enum QTETimeType
{
    Normal,
    Slow,
    Paused
}

public enum QTEPressType
{
    Single,
    Simultaneously
}

[System.Serializable]
public class QTEKey
{
    public KeyCode keyboardKey;
}

[System.Serializable]
public class QTEUI
{
    public GameObject eventUI;
    public TMP_Text eventText;
    public TMP_Text passText;
    public TMP_Text eventTimerText;
    public Image eventTimerImage;
}

public class QTEEvent : ScriptableObject
{
    [Header("Event settings")]
    public List<QTEKey> keys = new List<QTEKey>();
    public QTETimeType timeType;
    public float time;
    public bool failOnWrongKey;
    public QTEPressType pressType;
    [Header("UI")]
    public QTEUI keyboardUI;
    public TMP_Text passText;
    public TMP_Text timerText;
    public List<string> fragmentsList = new List<string>();

    [Header("Event actions")]
    public UnityEvent onStart;
    public UnityEvent onEnd;
    public UnityEvent onSuccess;
    public UnityEvent onFail;
}
