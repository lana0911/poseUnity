using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_txt : MonoBehaviour
{
    // Start is called before the first frame update
    float gameNameTime = 4.0f;
    void Start()
    {
        //��3���A���� "�ŤM���Y��"
        StartCoroutine(showGameName(gameNameTime)); //���� IEnumerator
    }


    IEnumerator showGameName(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Gobal_TCP.pss_name = 0;

    }

}
