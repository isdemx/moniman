using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{


    public string myPlace;
    GameObject hero;
    void Start()
    {
        GameObject allData = GameObject.Find("AllData");
        hero = allData.transform.Find("Hero").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == myPlace)
        {
            transform.SetParent(other.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            GetComponent<Rigidbody2D>().simulated = false;
            //rigidbody2D.bodyType = RigidbodyType2D.Static;
            hero.GetComponent<Hero>().isTake = false;
            Globals.allInstall += 1;
            gameObject.tag = null;
            //Destroy(other.gameObject, 1);
        }
    }

}
