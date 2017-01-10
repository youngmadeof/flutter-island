using UnityEngine;
using System.Collections;

public class Tree_Col : MonoBehaviour
{

    private Animator animator;
    public bool hit;

    public void Start()
    {
        animator = GetComponent<Animator>();
        hit = false;
    }


    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            animator.Play("TreeHide");
            hit = true;

        }
        

    }
    void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            animator.Play("TreeIdle");
        }
    }
}


