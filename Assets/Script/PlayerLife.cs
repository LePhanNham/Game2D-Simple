using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource DeathSoundEffect;
    public int cnt = 0;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
/*            if (CheckPoint.CheckPointsList != null)
            {
                rb.transform.position = CheckPoint.GetActiveCheckPointPosition();

            }*/
            DeathSoundEffect.Play();
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            cnt++;
        }
    }
    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        /*if (CheckPoint.CheckPointsList != null)
        {
            rb.transform.position = CheckPoint.GetActiveCheckPointPosition();

        }*/
    }
    private void RestartLevel()
    {
        Vector3 result2 = new Vector3(0, 0, 0);

        if (CheckPoint.GetActiveCheckPointPosition() != result2)
        {

            rb.gameObject.GetComponent<Rigidbody2D>().position = CheckPoint.GetActiveCheckPointPosition();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
