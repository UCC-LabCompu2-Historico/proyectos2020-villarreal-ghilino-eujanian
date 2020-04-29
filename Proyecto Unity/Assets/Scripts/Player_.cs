using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Greetings from Sid!

//Thank You for watching my tutorials
//I really hope you find my tutorials helpful and knowledgeable
//Appreciate your support.

public class Player_ : MonoBehaviour {
   public float maxSpeed = 50f;
	public float speed = 50f;
	public bool grounded;
	public float jumpPower = 6.5f;
    public int health=100;
    public Collider2D PlayerColliderDeath;
    public GameObject PlayerCollider;
    
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	private bool DoubleJump;
   private int CurrentHealth;
   private bool dead;
    // Start is called before the first frame update
    void Start() {
     
     	rb2d = GetComponent<Rigidbody2D>(); 
     	anim = GetComponent<Animator>();
        CurrentHealth= health;    
        PlayerColliderDeath.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("SpeedY", (rb2d.velocity.y));

        if (grounded){
        	DoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Z) ){
        	if (grounded){
        		jump = true;
        		DoubleJump = true;
        	}
        	else if (DoubleJump){
        		jump = true;
        		DoubleJump = false;
        	}
        }

        
    }
    void FixedUpdate(){
    	Vector3 fixedVelocity = rb2d.velocity;
    	fixedVelocity.x *= 0.75f;
            if (!dead){ 
            	if(grounded){
            		rb2d.velocity = fixedVelocity;
            	} 

            	float h = Input.GetAxis("Horizontal");

            	rb2d.AddForce(Vector2.right * speed * h);

            	float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);

            	rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

            	if (h > 0.1f){
            		transform.localScale = new Vector3(1f,1f,1f);
            	}
            	if (h< -0.1f){
            		transform.localScale = new Vector3(-1f,1f,1f);
            	}

            	if (jump ){
            		rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            		jump = false;
            	}

    	 }else{
            rb2d.velocity = fixedVelocity *0;
         }
    	
    } 

    void OnBecameInvisible (){
    	transform.position = new Vector3(-9, -3, 0);
    }

   public void DamageTaken(int damage){
        CurrentHealth -= damage;
        
        anim.SetTrigger("Hurt");

        if (CurrentHealth <= 0){
            Die();
        }
    }

     void Die(){

        anim.SetBool("Death", true);

        dead = true;

        PlayerColliderDeath.enabled = true;

        PlayerCollider.SetActive(false);

        gameObject.tag = "Untagged";
        gameObject.layer = 0;

    }
}
