using UnityEngine;
using System.Collections;

public class Flower_Anim : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }    
	
    void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.gameObject.CompareTag("Player"))
        {
            animator.Play("FlowerInter");
        }
    }	
	
    void OnTriggerExit2D(Collider2D Other)
    {
        if(Other.gameObject.CompareTag("Player"))
        {
            animator.Play("FlowerIdle");
        }
    }
}
