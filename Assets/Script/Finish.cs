using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour 
{
    private AudioSource FinishMusic;
    private bool check = false;

    // Start is called before the first frame update
    private void Start()
    {
        FinishMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Player" && !check && SceneManager.GetActiveScene().buildIndex==1)
        {
            check = true;
            FinishMusic.Play();
            Invoke("nextLevel", 2f);
        }
        else if (collision.gameObject.name == "Player" && !check &&  SceneManager.GetActiveScene().buildIndex == 2)
        {
            check = true;
            FinishMusic.Play();
            Invoke("nextLevel", 2f);
        }
        else if (collision.gameObject.name == "Player" && !check && SceneManager.GetActiveScene().buildIndex == 3)
        {
            check = true;
            FinishMusic.Play();
            Invoke("nextLevel", 2f);
        }

    }

    private void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
