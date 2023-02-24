using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_controler : MonoBehaviour
{
    // Start is called before the first frame update
    public string scene_name;
    GameObject player;
    void Start()
    {
        this.gameObject.tag = "portal";
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            print("col_player");
            SceneManager.LoadScene(scene_name);   
            player.transform.position = new Vector3(-7.8f,-0.4f,0);
        }        
    }

}
