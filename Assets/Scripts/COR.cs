using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COR : MonoBehaviour
{
    [SerializeField] float time = 3;
    [SerializeField] bool go = false;

    Coroutine timerCoroutine;
    void Start()
    {
        timerCoroutine = StartCoroutine(Timer(time));
        StartCoroutine("StoryTime");
        StartCoroutine(WaitAction());
    }

    // Update is called once per frame
    void Update()
    {
        //time -= Time.deltaTime;
        //if (time < 0 )
        //{
        //    time = 3;
        //    print("hello :)");
        //}
    }

    IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            print("hello :)");
        }   
    }

    IEnumerator StoryTime()
    {
        print("h-hello..?");
        yield return new WaitForSeconds(1);
        print("wow,,, a whole second.,.,.,");
        yield return new WaitForSeconds(1);
        print("wow,,, a whole ,..,. another second!");


        StopCoroutine(timerCoroutine);

        yield return null;
    }

    IEnumerator WaitAction()
    {


        yield return new WaitWhile(() => go);
        print(go.ToString());
        yield return null;

    }
}
