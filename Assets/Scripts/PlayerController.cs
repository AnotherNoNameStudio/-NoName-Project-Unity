using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 3;
	private Animator animator;
    private bool isPlayerMoving;
    private Vector2 lastDirectory;

	// Use this for initialization
	void Start ()
    {
		animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        Attack();
	}

    private void Move()
    {
        isPlayerMoving = false;

        // look at edit -> project settings -> input
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
            isPlayerMoving = true;
            lastDirectory = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
            isPlayerMoving = true;
            lastDirectory = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        // update values of Animator's MoveX and MoveY
        animator.SetFloat("MoveX", Input.GetAxisRaw(("Horizontal")));
        animator.SetFloat("MoveY", Input.GetAxisRaw(("Vertical")));
        animator.SetBool("IsPlayerMoving", isPlayerMoving);
        animator.SetFloat("LastMoveX", lastDirectory.x);
        animator.SetFloat("LastMoveY", lastDirectory.y);
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetTrigger("IsPlayerAttacking");

            var moveX = animator.GetFloat("MoveX");
            var lastMoveX = animator.GetFloat("LastMoveX");
            var moveY = animator.GetFloat("MoveY");
            var lastMoveY = animator.GetFloat("LastMoveY");

            if (moveX > 0 && lastMoveX > 0)
            {
                animator.SetTrigger("AttackRight");
            }
            if (moveX < 0 && lastMoveX < 0)
            {
                animator.SetTrigger("AttackLeft");
            }
            if (moveY > 0 && lastMoveY > 0)
            {
                animator.SetTrigger("AttackUp");
            }
            if (moveY < 0 && lastMoveY < 0)
            {
                animator.SetTrigger("AttackDown");
            }
        }
    }
}
