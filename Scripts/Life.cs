using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            Die();
        }
    }
    private void Die()
    {
        anim.SetTrigger("death");
    }
}
