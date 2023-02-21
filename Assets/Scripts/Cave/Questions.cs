using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Questions : MonoBehaviour
{
    
    private List<string> answers = new List<string>{"Tienlan", "Timothy", "Nicholas", "Miklos", "Hinson", "Alex", "Enzo", "Vincent"};
    public TMP_Text text;
    public GameObject textObject;
    public GameObject canvas;
    private string current;
    public static int level;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject player = GameObject.Find("Third Person Player");
        //EnterCave playerScript = player.GetComponent<EnterCave>();
        print(level);

        for (int i = 0; i < level+3; i++)
        {
            current = answers[Random.Range(0,answers.Count)];
            text.text = current;
            answers.Remove(current);
            GameObject clone = Instantiate(textObject);
#if UNITY_EDITOR
            UnityEditor.GameObjectUtility.SetParentAndAlign(clone, canvas);
#endif
            clone.transform.position = new Vector3((290-100*level)+(222*i), 425, 0);
        }
        
        
    }
}
