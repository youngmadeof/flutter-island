using UnityEngine;
using System.Collections;

public class Tree_Col : MonoBehaviour
{

    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }


    void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            animator.Play("TreeHide");

        }
        

    }
    void LateUpdate()
    {
        animator.Play("TreeIdle");
    }
}


