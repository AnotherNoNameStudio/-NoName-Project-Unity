using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 3;
	private Animator anim;

	// Use this for initialization
	void Start ()
    {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        move();
        attack();
	}

    private void move()
    {
        // look at edit -> project settings -> input
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector2(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime));
        }

        // update values of Animator's MoveX and MoveY
        anim.SetFloat("MoveX", Input.GetAxisRaw(("Horizontal")));
        anim.SetFloat("MoveY", Input.GetAxisRaw(("Vertical")));
    }

    private void attack()
    {
        if (Input.GetButtonDown("Attack_Horizontal"))
        {
            var moveX = anim.GetFloat("MoveX");
            if (moveX > 0)
            {
                anim.SetTrigger("AttackRight");
            }
            if (moveX < 0)
            {
                anim.SetTrigger("AttackLeft");
            }
        }
        if (Input.GetButtonDown("Attack_Vertical"))
        {
            var moveY = anim.GetFloat("MoveY");
            if (moveY > 0)
            {
                anim.SetTrigger("AttackUp");
            }
            if (moveY < 0)
            {
                anim.SetTrigger("AttackDown");
            }
        }
    }
}
