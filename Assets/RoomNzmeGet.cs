using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class RoomNzmeGet :  NetworkBehaviour
{

    NetworkRunner runner;
    NetworkObject n; 
    void Start()
    {

        n = GetComponent<NetworkObject>();
        runner = transform.gameObject.GetComponent<NetworkRunner>();
        //string p = Fusion.;
        StartCoroutine(ShowRoomName());
    }

    void Update()
    {


    }

    IEnumerator ShowRoomName()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("имя текущй комнаты:" + n.Runner.SessionInfo.Name);
        GetComponent<Text>().text = "имя текущй комнаты:" + n.Runner.SessionInfo.Name;
    }
}
