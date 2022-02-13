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
    public float moveSpeed;
    public float salto;
    public Rigidbody2D theRB;
    private Animator animator;
    private SpriteRenderer theSR;

    void Start()
    {
        animator = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
		/*rigidbody2D = GetComponent<Rigidbody2D>();
    */}

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetBool("estaSaltando", true);
			rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
		}
    */
    
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"),theRB.velocity.y);
        if (Input.GetButtonDown("Jump") && CheckGround.isGrounded)
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


        animator.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        animator.SetBool("isGrounded", CheckGround.isGrounded);

    

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