using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    public int cherries = 0,target;

    [SerializeField] private Text CherriesText;
    [SerializeField] private Text TargetText;
    [SerializeField] private AudioSource CollectionSoundEffect;
    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            TargetText.text = "Target : 10";
            target = 10;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            TargetText.text = "Target : 15";
            target = 15;

        }
        else 
        {
            target = 40;
            TargetText.text = "Target : 40";
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            CollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            if (cherries>=target) CherriesText.color = Color.green;
            CherriesText.text = "Fruits : " + cherries;

        }
    }
}
