using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

	public Animator animator;

	public float AttacksRate = 2f;
    float nextAttack = 0f;
   
    // Update is called once per frame
    void FixedUpdate()
    {
       if (Time.time >= nextAttack){
         if  (Input.GetKeyDown(KeyCode.X)){
            Attack();
            nextAttack = Time.time + 2f/AttacksRate;
        }
       }
    }
    
	void Attack (){

		animator.SetTrigger("Attack");


	}

}
