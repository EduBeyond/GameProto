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
     yield return new WaitForSeconds(3.15f);
     SceneManager.LoadScene("LevelSelect");
  }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
        SM_Ship_Cruiser_03.Play("ship_fly_in", 0, 4.0f);
        Canvas.Play("system_outro", 0, 4.0f);
        StartCoroutine(WaitForSceneLoad());
        }

    }
}