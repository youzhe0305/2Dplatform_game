using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x>=-7.8f){
        this.gameObject.transform.position = player.transform.position + new Vector3(2.8f,-1f,this.transform.position.z);
        }


    }
}
