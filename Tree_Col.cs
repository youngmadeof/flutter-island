using UnityEngine;
using System.Collections;

public class Tree_Col : MonoBehaviour
{

    private Animator animator;

    public GameObject butt;
    

    public void Start()
    {
        animator = GetComponent<Animator>();
        
        
    }


    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
            animator.Play("TreeHide");           

        }
        

    }
    void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject == butt)
        {
            animator.Play("TreeIdle");
        }
    }
}


