using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Questions : MonoBehaviour
{
    
    public TMP_Text text;
    public List<string> answers = new List<string>{ "ph", "ff", "ft", "gh", "ge", "ch", "mb" };
    public GameObject player;
    private string current;

    // Start is called before the first frame update
    void Start()
    {
        text.text  = answers[Random.Range(0,answers.Count)];
        answers.Remove(text.text);
    }
}
