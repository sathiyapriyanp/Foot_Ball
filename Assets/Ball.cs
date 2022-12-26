// using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Transform target;
    public static float Force;
    GoalKeeper goal;
    Vector3 StartPos;
    Vector3 GoalPos;
    public Slider forceUI;
    public GameObject GoalKeeper;
    public GoalKeeper goalKeeper;
    public GameObject gauge;
    private bool canDoAction = true;



    void Start()
    {
        StartPos = transform.position;
        GoalPos = GoalKeeper.transform.position;
        Debug.Log(GoalPos);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Force++;
            Slider();
            Force = 28;
        }
        if (canDoAction == true && Input.GetKeyUp(KeyCode.Space) == true)
        {
            StartCoroutine(Wait());
        }
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Right();

        // }
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     Left();

        // }
    }
    void LateUpdate()
    {
        
    }
    void OnTriggerEnter()
    {
        Debug.Log("entre");
        canDoAction = false;
    }

    void OnTriggerExit()
    {
        Debug.Log("exit");
        canDoAction = true;
    }
    // void Reset()
    // {
    //     Vector3 Shoot = (target.position - this.transform.position).normalized;
    //     GetComponent<Rigidbody>().AddForce(Shoot * 0 + new Vector3(0, 3f, 0), ForceMode.Impulse);
    //     // transform.Rotate=new Vector3(0,0,0);
    //     GetComponent<Rigidbody>().AddForce(0, 0, 0, ForceMode.Impulse);
    // }
    public void shoot()
    {
        Vector3 Shoot = (target.position - this.transform.position).normalized;
        GetComponent<Rigidbody>().angularDrag = 10;
        GetComponent<Rigidbody>().AddForce(Shoot * Force, ForceMode.Impulse);
        gauge.gameObject.SetActive(false);
    }
    public void Slider()
    {
        forceUI.value = Force;
    }
    public void ResetGauge()
    {

        Force = 0;
        forceUI.value = 0;
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.1f);
        shoot();

        yield return new WaitForSeconds(0.0f);
        FindObjectOfType<GoalKeeper>().GoalMove();

        yield return new WaitForSeconds(1.5f);
        ResetGauge();
        GetComponent<Rigidbody>().angularDrag = 40;

        yield return new WaitForSeconds(2.5f);
        GetComponent<Rigidbody>().AddForce(Vector3.right * Force, ForceMode.Impulse);
        transform.position = StartPos;
        GoalKeeper.transform.position = GoalPos;

        FindObjectOfType<GoalKeeper>().Reset();
        StartCoroutine(Gauge());
        FindObjectOfType<GoalKeeper>().Move = 0;

    }
    IEnumerator Gauge()
    {
        yield return new WaitForSeconds(5f);
        gauge.gameObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        goalKeeper.goalText.gameObject.SetActive(true);
        StartCoroutine(GoalFalse());
    }
    IEnumerator GoalFalse()
    {
        yield return new WaitForSeconds(2f);
        goalKeeper.goalText.gameObject.SetActive(false);
    }
    // void Right()
    // {

    //     target.Translate(Vector3.Normalize(target.position - transform.position) * 1);

    // }
    // void Left()
    // {

    //     target.Translate(Vector3.Normalize(target.position + transform.position) * 1);

    // }
    // void OnMouseDown()
    // {
    //     GetComponent<Rigidbody>().AddForce(Vector3.right * Force, ForceMode.Impulse);
    // }

}
