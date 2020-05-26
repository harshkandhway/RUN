using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_check : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "base")
        {
            Player.a.SetBool("isJump", false);
            player.GetComponent<Player>().isGround = true;
            Player.isGlide = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "base")
        {
            Player.a.SetBool("isJump", true);
            player.GetComponent<Player>().isGround = false;
        }
    }
}
