using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FightManager : MonoBehaviour
{
    public FightStates curState;
    Animator fightAnim;
    Animator enemyFightAnim;
    public Canvas qteCanvas;
    public float time;
    public Button submitBut;
    public bool curAnimFinished = false;
    public GameObject player;
    public GameObject enemy;
    public FightOutcomes outcome;
    public QTEEvent qte;


    public GameObject pass;
    public GameObject timer;
    public GameObject question;
    List<string> l = new List<string>();
    QTEManager manager = new QTEManager();
    System.Random rnd = new System.Random();

    public enum FightStates
    {
        QTEpass,
        QTEfail,
        QTEbreak,
        QTEpause,
        QTEidle
    }

    void Start()
    {

        fightAnim = GetComponent<Animator>();
        enemyFightAnim = enemy.GetComponent<Animator>();
        qteCanvas.enabled = false;
        time = 1.0f;


        pass = GameObject.Find("Pass Text");
        timer = GameObject.Find("Timer");
        question = GameObject.Find("Question Text");
        manager = GameObject.Find("QTE Canvas").GetComponent<QTEManager>();
        outcome = player.GetComponent<FightOutcomes>();
        outcome.ip = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            l.Add("A");
            l.Add("B");
            l.Add("C");
            (string, int) temp = GetQuestion();
            question.GetComponent<TMP_Text>().text = temp.Item1;
            manager.solList.Clear();
            manager.solList.Add(temp.Item2);

            qte = GetQTEEvent(l, 5f, QTETimeType.Slow, pass.GetComponent<TMP_Text>());

            StartCoroutine(init("init1", 0.2f, qte));
            StartCoroutine(initPass("initPass1", 2f));
        }

    }

    void LateUpdate()
    {
        if (!outcome.ip)

        {
            //Debug.Log("work");
            if (outcome.initiated == false)
            {
                //Debug.Log("work2");
                fightAnim.enabled = false;
                StartCoroutine(fail());
            }
            if (outcome.initiated)
            {
                StartCoroutine(hitBy360Atk());
            }

        }




    }

    IEnumerator fail()
    {
        outcome.ip = true;


        enemyFightAnim.ResetTrigger("EdodgePass3");
        enemyFightAnim.SetTrigger("EdodgePass3");

        fightAnim.enabled = true;
        foreach (AnimatorControllerParameter parameter in fightAnim.parameters)
        {
            fightAnim.SetBool(parameter.name, false);
        }


        yield return new WaitForSeconds(0.8f);

        fightAnim.ResetTrigger("test");
        fightAnim.SetTrigger("test");

        yield return new WaitForSeconds(0.5f);

        fightAnim.ResetTrigger("test");
        fightAnim.SetTrigger("test");

        yield return new WaitForSeconds(0.5f);

        fightAnim.ResetTrigger("test");
        fightAnim.SetTrigger("test");

        outcome.initiated = true;
        //qteCanvas.enabled = false;

        yield break;
    }

    IEnumerator init(string name, float timer, QTEEvent qte)
    {
        print(qte);
        curAnimFinished = false;
        foreach (AnimatorControllerParameter parameter in fightAnim.parameters)
        {
            fightAnim.SetBool(parameter.name, false);
        }

        fightAnim.SetBool(name, true);
        yield return new WaitForSeconds(timer);
        fightAnim.SetBool(name, false);
        yield return new WaitForSeconds(0.3f);
        manager.startEvent(qte);
        setCurOutcome(player, 1);
        qteCanvas.enabled = true;
        setCurQTE(submitBut, qte);
        curAnimFinished = true;
        yield break;

    }

    IEnumerator hitBy360Atk()
    {
        outcome.ip = true;
        foreach (AnimatorControllerParameter parameter in enemyFightAnim.parameters)
        {
            enemyFightAnim.SetBool(parameter.name, false);
        }

        if ((outcome.enemyReaction == 0 && outcome.initiated) || (outcome.enemyReaction == 0 && outcome.dodged))
        {
            enemyFightAnim.ResetTrigger("Ehit");
            enemyFightAnim.SetTrigger("Ehit");

            yield return new WaitForSeconds(0.5f);

            enemyFightAnim.ResetTrigger("Ehit");
            enemyFightAnim.SetTrigger("Ehit");

            yield return new WaitForSeconds(0.7f);

            enemyFightAnim.ResetTrigger("Ehit");
            enemyFightAnim.SetTrigger("Ehit");

            yield break;
        }


    }

    public void setCurOutcome(GameObject player, int state)
    {
        //dodging
        if (state == 0) { player.GetComponent<FightOutcomes>().cur = 0; }
        //initiating
        if (state == 1) { player.GetComponent<FightOutcomes>().cur = 1; }
    }

    public void setCurQTE(Button submitBut, QTEEvent qte)
    {
        submitBut.GetComponent<CurQTE>().qte = qte;
    }
    IEnumerator wait(float timer)
    {
        yield return new WaitForSeconds(timer);

    }

    IEnumerator initPass(string name, float time)
    {
        if (name == "initPass1") { 
            outcome.playerAtk = 0;
            curAnimFinished = false;
            fightAnim.SetBool(name, true);
            yield return new WaitForSeconds(1.2f);
            fightAnim.SetBool(name, false);
            curAnimFinished = true;

            yield break;
        }

    }

    IEnumerator dodgePass(string name, float time)
    {
        foreach (AnimatorControllerParameter parameter in fightAnim.parameters)
        {
            fightAnim.SetBool(parameter.name, false);
        }

        fightAnim.SetBool(name, true);
        yield return new WaitForSeconds(time);
        fightAnim.SetBool(name, false);
        yield break;
    }

    IEnumerator idle()
    {
        foreach (AnimatorControllerParameter parameter in fightAnim.parameters)
        {
            fightAnim.SetBool(parameter.name, false);
        }
        fightAnim.SetBool("idle", true);
        yield break;
    }

    public QTEEvent GetQTEEvent(List<string> fragments, float time, QTETimeType qtet, TMP_Text pass)
    {
        QTEUI qteui = new QTEUI();

        QTEEvent qte = ScriptableObject.CreateInstance<QTEEvent>();
        qte.passText = pass;
        qte.timerText = timer.GetComponent<TMP_Text>();
        qte.keyboardUI = qteui;
        qte.timeType = qtet;
        qte.keyboardUI.eventTimerText = timer.GetComponent<TMP_Text>();
        qte.fragmentsList = fragments;
        qte.time = time;

        return qte;
    }

    public (string, int) GetQuestion()
    {
        List<(string, int)> qbank = new List<(string,int)>();
        qbank.Add(("My mother's mother is: A) my aunt B) my grandmother C) my father", 1));
        qbank.Add(("My cousin's father is: A) my uncle B) my grandfather C) my father", 0));

        int randIndex = rnd.Next(qbank.Count);
        return qbank[randIndex];
    }
  
}
