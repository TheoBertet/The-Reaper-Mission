using UnityEngine;
using UnityEngine.Animations;

public class MovementManager : MonoBehaviour
{
    public float speed = 5f;

    private new Rigidbody2D rigidbody;
    private new Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter();
        animateCharacter();
    }

    void moveCharacter()
    {
        float moveVertical = Input.GetAxis("Vertical") * speed;

        float moveHorizontal = Input.GetAxis("Horizontal") * speed;

        //rigidbody.MovePosition(new Vector2(transform.position.x + moveHorizontal * speed,
        //    transform.position.y + moveVertical * speed));

        rigidbody.velocity = new Vector2(moveHorizontal, moveVertical);
    }

    void animateCharacter()
    {
        if(Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("isMovingFront", true);
        }
        else
        {
            animator.SetBool("isMovingFront", false);
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("isMovingBack", true);
        }
        else
        {
            animator.SetBool("isMovingBack", false);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isMovingSide", true);

            if(Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            animator.SetBool("isMovingSide", false);
        }
    }
}
