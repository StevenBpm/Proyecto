using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
	/*public float fuerzaSalto;
	public GameManager gameManager;
	
	//private Rigidbody2D rigidbody2D;
	
    // Start is called before the first frame update

*/
    public static Jugador instance;
    public float moveSpeed;
    public float salto;
    public Rigidbody2D theRB;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private Animator animator;
    private SpriteRenderer theSR;

    public float KnockbackLength, knockBackForce;
    private float knockBackCounter;
    

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
		
    }

    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetBool("estaSaltando", true);
			rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
		}
    */
        if(knockBackCounter <=0)
        {

            theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"),theRB.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 2f, whatIsGround);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, salto);
            }
            
            if(theRB.velocity.x < 0)
            {
                theSR.flipX = true;
            }else if(theRB.velocity.x > 0)
            {
                theSR.flipX = false;
            }
        }else{
            knockBackCounter -= Time.deltaTime;
            if(!theSR.flipX)
            {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }else{
                theRB.velocity = new Vector2(+knockBackForce, theRB.velocity.y);
            }
        }

        animator.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        animator.SetBool("isGrounded", isGrounded);

    

    }
	
    public void Knockback()
    {
        knockBackCounter = KnockbackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
    }

	/*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
        }
		
		if (collision.gameObject.tag == "Obstaculo")
		{
			gameManager.gameOver = true;
		}
    }*/
}