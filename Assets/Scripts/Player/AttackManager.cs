using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackManager : MonoBehaviour
{
    public GameObject AttackAnimation;
    public float attackCooldown = 1f;
    public float damages = 0.5f;

    private float attackStartTime = 0f;
    private GameObject target = null;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time <= attackCooldown + attackStartTime)
        {
            animator.SetBool("reload", false);
        }

        if (Input.GetMouseButtonDown(0) && Time.time > attackCooldown + attackStartTime)
        {
            GameObject newAnimation = Instantiate(AttackAnimation);
            newAnimation.transform.position = transform.position;

            if(target != null)
            {
                target.GetComponent<AdventurerManager>().Damage(damages);
            }

            attackStartTime = Time.time;
            animator.SetBool("reload", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Adventurer")
        {
            target = collision.gameObject.transform.parent.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Adventurer")
            if (target != null)
            {
                target = null;
            }
    }


}
