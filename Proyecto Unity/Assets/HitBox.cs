using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
	private int damage=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider){
  		if(collider.gameObject.CompareTag("Player")){
    		Player_ player = collider.GetComponentInParent<Player_>();
    		player.DamageTaken(damage);
 		 }
  	}
}
