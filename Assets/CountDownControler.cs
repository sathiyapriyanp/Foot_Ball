using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownControler : MonoBehaviour
{
    public GameObject ball;
    public GameObject goalKeeper;
    public GameObject target2;
    public GameObject gauge;
    public int countdownTime;

    public Text countdownDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("cdc start");
        ball.gameObject.SetActive(false);
        goalKeeper.gameObject.SetActive(false);
        target2.gameObject.SetActive(false);
        gauge.gameObject.SetActive(false);
        StartCoroutine(CountDownToStart());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator CountDownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "Go!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
        ball.gameObject.SetActive(true);
        goalKeeper.gameObject.SetActive(true);
        target2.gameObject.SetActive(true);
        gauge.gameObject.SetActive(true);


    }
}
