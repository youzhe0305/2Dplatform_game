using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controler : MonoBehaviour
{

    public float speed;
    public float jump_force;
    int jump_times=0;
    int jump_times_limit = 1;
    public Transform player_ani;

    void Start()
    {
        player_ani = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        // move
        if(Input.GetKey(KeyCode.D)){
            if(player_ani.GetComponent<SpriteRenderer>().flipX == true)  player_ani.GetComponent<SpriteRenderer>().flipX = false;
            player_ani.GetComponent<Animator>().SetInteger("status",1);
            this.gameObject.transform.position += new Vector3(speed*Time.deltaTime,0,0);
        }
        if(Input.GetKeyUp(KeyCode.D)&&jump_times==0) player_ani.GetComponent<Animator>().SetInteger("status",0);
        if(Input.GetKey(KeyCode.A)){
            if(player_ani.GetComponent<SpriteRenderer>().flipX == false)  player_ani.GetComponent<SpriteRenderer>().flipX = true;
            player_ani.GetComponent<Animator>().SetInteger("status",1);
            this.gameObject.transform.position -= new Vector3(speed*Time.deltaTime,0,0);
        }
        if(Input.GetKeyUp(KeyCode.A)&&jump_times==0) player_ani.GetComponent<Animator>().SetInteger("status",0);
        if(Input.GetKey(KeyCode.Space)){
            if(jump_times<jump_times_limit){
                print("jump");
                this.gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0,jump_force) );
                jump_times += 1;                
            } 
        }   
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="plateform"){
            print("col pla");
            jump_times = 0;
        }
    }
}
