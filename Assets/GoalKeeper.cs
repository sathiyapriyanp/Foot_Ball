using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalKeeper : MonoBehaviour
{
    public int[] Pos;
    public int Move;
    public int index;
    Animator goalKeeper;


    public Text goalText;


    public Ball ball;




    void Start()
    {
        goalKeeper = GetComponent<Animator>();
        goalText.gameObject.SetActive(false);
    }


    void FixedUpdate()
    {

        if (Move == 0)
        {
            Reset();


        }
        if (Move == 1)
        {
            SaveR();



        }

        if (Move == 2)
        {
            SaveL();


        }
    }

    public void GoalMove()
    {
        Debug.Log("goalmove");
        index = Random.Range(0, Pos.Length);

        Move = Pos[index];

        if (Move == 1)
        {

            StartCoroutine(WaitGoal());
        }
        if (Move == 2)
        {

            StartCoroutine(WaitGoal());
        }

    }
    public void SaveR()
    {
        Debug.Log("r");
        goalKeeper.SetFloat("Save", 0.5f);





    }
    public void SaveL()
    {
        Debug.Log("l");
        goalKeeper.SetFloat("Save", 1f);



    }
    public void Reset()
    {
        goalKeeper.SetFloat("Save", 0f);
        ball.gauge.gameObject.SetActive(true);


    }
    IEnumerator WaitGoal()
    {
        yield return new WaitForSeconds(2f);
        // goalText.gameObject.SetActive(true);
        // yield return new WaitForSeconds(1f);
        // goalText.gameObject.SetActive(false);

    }

}
