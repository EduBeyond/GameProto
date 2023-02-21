using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ship_fly_in : MonoBehaviour
{
    [SerializeField] private Animator SM_Ship_Cruiser_03;
    [SerializeField] private Animator Canvas;

    // Start is called before the first frame update
    void Start()
    {
   
    }

  private IEnumerator WaitForSceneLoad() {
     yield return new WaitForSeconds(2.2f);
     SceneManager.LoadScene("LevelSelect");
  }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
        StartCoroutine(WaitForSceneLoad());
        SM_Ship_Cruiser_03.Play("ship_fly_in");
        Canvas.Play("system_outro", 0, 2.10f);
        
        }

    }
}