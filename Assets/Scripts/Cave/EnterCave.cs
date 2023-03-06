using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class EnterCave : MonoBehaviour
{
    [Header("References")]
    public GameObject player;
    public GameObject congrats;
    public GameObject button;
    public PlayPhonics playPhonics;
    public AudioClip[] sounds;

    private static int cave = 0;
    public static int level = 0;
    private static int difficulty = 1;
    private static int correctIndex;
    private static string correctAnswer;
    private static int mistakes = 0;

    [Header("Question Stuff")]
    private List<string> answers = new List<string>{"b", "ch", "j", "m", "p", "sh", "v", "y", "z"};
    public List<string> used = new List<string>();
    public TMP_Text text;
    public GameObject textObject;
    public GameObject canvas;
    private string current;


    void Awake()
    {
        playPhonics = button.GetComponent<PlayPhonics>();

        if (level != 3)
        {
            for (int i = 0; i < level+3; i++)
            {
                //randomly picking potential answers to use
                current = answers[Random.Range(0,answers.Count)];
                used.Add(current);
                text.text = current;
                answers.Remove(current);

                //cloning answers and putting them above the paths
                GameObject clone = Instantiate(textObject);
                if (level == 0)
                {
                    clone.transform.position = new Vector3((416)+(10*i), 13, 129);
                }
                if (level == 1)
                {
                    clone.transform.position = new Vector3((508)+(8*i), 18, 383);
                }
                if (level == 2)
                {
                    clone.transform.position = new Vector3((502)+(8.5f*i), 18, 383);
                }
            }
        }

        correctIndex = Random.Range(0,level+3);
        correctAnswer = used[correctIndex];
        answers = new List<string>{"b", "ch", "j", "m", "p", "sh", "v", "y", "z"};
        /*for (int i = 0; i < answers.Count; i++)
        {
            print(answers[i]);
        }*/
        print(correctAnswer);
        print(correctIndex);
        playPhonics.audioClip = sounds[answers.IndexOf(correctAnswer)];
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
            if (other.gameObject.name == (correctIndex + 1).ToString())
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
