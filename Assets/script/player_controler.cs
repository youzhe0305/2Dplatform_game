using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class player_controler : MonoBehaviour
{

    public float speed;
    public float jump_force;
    int jump_times=0;
    int jump_times_limit = 1;
    public Transform player_ani;
    Animator player_ani_animator;
    public Image blood;
    public TextMeshProUGUI Hp_text;
    public Image hurtfalsh;
    float hurtflash_timer=0;
    float Hp,Max_Hp,blood_len;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player_ani = this.transform.GetChild(0);
        player_ani_animator = player_ani.GetComponent<Animator>();
        Max_Hp = 10;
        Hp = Max_Hp;
        blood_len = blood.transform.localScale.x;
        // integer : status = (0,idle / 1,run / 2 jump_up / 3 jump_down)
    }

    // Update is called once per frame
    void Update()
    {
        // move
        if(Input.GetKey(KeyCode.D)){
            if(player_ani.GetComponent<SpriteRenderer>().flipX == true)  player_ani.GetComponent<SpriteRenderer>().flipX = false;
            player_ani_animator.SetInteger("status",1);
            this.gameObject.transform.position += new Vector3(speed*Time.deltaTime,0,0);
        }
        if(Input.GetKeyUp(KeyCode.D)&&jump_times==0) player_ani_animator.SetInteger("status",0);
        if(Input.GetKey(KeyCode.A)){
            if(player_ani.GetComponent<SpriteRenderer>().flipX == false)  player_ani.GetComponent<SpriteRenderer>().flipX = true;
            player_ani_animator.SetInteger("status",1);
            this.gameObject.transform.position -= new Vector3(speed*Time.deltaTime,0,0);
        }
        if(Input.GetKeyUp(KeyCode.A)&&jump_times==0) player_ani_animator.SetInteger("status",0);
        if(Input.GetKey(KeyCode.Space)){
            if(jump_times<jump_times_limit){
                player_ani_animator.SetInteger("status",2);
                print("jump");
                this.gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0,jump_force) );
                jump_times += 1;                
            } 
        }   
        if(jump_times!=0&&this.gameObject.GetComponent<Rigidbody2D>().velocity.y<0){
            player_ani_animator.SetInteger("status",3);
        }

        // blood bar, Hp modify
        if(Input.GetKeyDown(KeyCode.K)) {
            Hp -= 1;
            hurtfalsh.GetComponent<Image>().enabled = true;
        }
        if(hurtfalsh.GetComponent<Image>().enabled == true)  hurtflash_timer += 1*Time.deltaTime;
        if(hurtflash_timer>=0.1f) {
            hurtfalsh.GetComponent<Image>().enabled = false;
            hurtflash_timer=0;
        }
        blood.transform.localScale = new Vector3(blood_len * (Hp/Max_Hp), blood.transform.localScale.y, blood.transform.localScale.z);
        Hp_text.text = Hp.ToString() + "/" + Max_Hp.ToString();

    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="plateform"){
            print("col pla");
            jump_times = 0;
            player_ani_animator.SetInteger("status",0);
        }
    }
}
