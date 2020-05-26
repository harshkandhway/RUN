using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpSize;
    public static Rigidbody2D play;
    public static Animator a;
    public bool isGround = false;
    public static bool isGlide = false;
    //public static bool isAttack = false;
    float temp;
    public GameObject kunai;
    private UI ui;
    //private Kunai k;
    public float canFire = 0.0f;
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        play = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)&& Run.Dead == false)
        {
            {
                if (isGround == true)
                {
                    if (MainMenu.isSoundOn == 0)
                        FindObjectOfType<audioScript>().playSound("jump");
                    play.velocity = Vector2.up * jumpSize;
                }
            }
        }
        int i = 0;
        if ( i < Input.touchCount)
        {
            {
                if (Run.Dead == false)
                {
                        Touch t = Input.GetTouch(i);
                        if (t.position.x < Screen.width / 2)
                        {
                        if (isGround == true)
                        {
                            if (MainMenu.isSoundOn == 0)
                                FindObjectOfType<audioScript>().playSound("jump");
                            play.velocity = Vector2.up * jumpSize;
                        }

                        }

                        if (t.position.x > Screen.width / 2)
                        {
                            //isAttack = true;
                            shoot();
                        }
                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)){

            shoot();
        }
        if (isGlide == true)
        {
            temp = Object.x;
            play.constraints = RigidbodyConstraints2D.FreezePositionY;
            a.SetBool("isGlide", true);
            Object.x = 1.0f;
            StartCoroutine(glideRoutine());
        }
        /*else
        {
            a.SetBool("isJump", false);
        }*/
    }
    public void shoot()
    {
        if (UI.kunaiCount > 0)
        {
            if (Time.time>canFire)
            {
                a.SetBool("isAttack", true);
                Instantiate(kunai, transform.position + new Vector3(1, 0, 0), Quaternion.Euler(new Vector3(0, 0, -90f)));
                //isAttack = true;
                UI.kunaiCount -= 1;
                ui.updateKunai();
                canFire = Time.time + 0.25f;
                StartCoroutine(attack());
            }
        }
    }
    public IEnumerator glideRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isGlide = false;
        Player.play.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        play.constraints = RigidbodyConstraints2D.FreezeRotation;
        a.SetBool("isGlide", false);
        Object.x = temp;
    }
    public IEnumerator attack()
    {
        yield return new WaitForSeconds(0.1f);
        //isGround = true;
        a.SetBool("isAttack", false);
        //isAttack = false;
    }
}