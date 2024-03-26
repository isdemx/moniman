using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{

    [SerializeField] ParticleSystem crashEffet;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            FindObjectOfType<HeroController>().DisableControls();
            crashEffet.Play();
            Invoke("LineIsFinished", 1f);

        }
    }

    void LineIsFinished()
    {
        SceneManager.LoadScene(1);
    }
}


