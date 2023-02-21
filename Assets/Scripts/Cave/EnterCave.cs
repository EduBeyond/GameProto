using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class EnterCave : MonoBehaviour
{
    [Header("Objects")]
    public GameObject player;
    public GameObject congrats;

    private static int cave = 0;
    public static int level = 0;
    private static int difficulty = 1;
    private static int correct;
    private static int mistakes = 0;

    public List<string> answers = new List<string>{ "ph", "ff", "ft", "gh", "ge", "ch", "mb" };
    [Header("Question Stuff")]
    public TMP_Text text;
    public GameObject textObject;
    public GameObject canvas;
    private string current;


    void Awake()
    {
        correct = Random.Range(1,level+4);
        print("The correct door is: " + correct);

        //clones the answers on to the top of the paths
        /*for (int i = 0; i < level+3; i++)
        {
            current = answers[Random.Range(0,answers.Count)];
            text.text = current;
            answers.Remove(current);
            GameObject clone = Instantiate(textObject);
            if (level == 0)
            {
                clone.transform.position = new Vector3((290)+(250*i), 400, 0);
            }
            if (level == 1)
            {
                clone.transform.position = new Vector3((140)+(275*i), 410, 0);
            }
            if (level == 2)
            {
                clone.transform.position = new Vector3((90)+(230*i), 415, 0);
            }
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Exit")
        {
            SceneManager.LoadScene("LevelSelect");
            print("Mistakes made: " + mistakes);
        }
        else if (other.tag == "Path")
        {
            if (other.gameObject.name == correct.ToString())
            {
                cave += 1;
            }
            else
            {
                mistakes += 1;
            }

            if (cave%difficulty == 0)
            {
                level = cave/difficulty;
            }

            SceneManager.LoadScene(level+4);
            print("cave: " + cave);
            print("level: " + level);
        }
        
    }
}
