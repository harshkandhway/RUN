using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zombie_walk : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool canCollide = false;
    void Start()
    {
        canCollide = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Object.notMove == false)
            transform.Translate(Vector3.left * Object.speed * Time.deltaTime);
        if (transform.position.x <= -15.55f)
        {
            Destroy(this.gameObject);
        }
        if (Object.enemiesCanMove == true)
        {
            gameObject.transform.Translate(Vector3.left * Random.Range(0.0f,1.5f) * Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (canCollide == true)
        {
        if (other.tag == "play")
        {
            if (other.name != null)
            {
                Player.a.SetBool("isCollide", true);
                if (MainMenu.isSoundOn == 0)
                {
                    FindObjectOfType<audioScript>().StopPlaying("inGame");
                    FindObjectOfType<audioScript>().playSound("dead");
                }
                Run.Dead = true;
                Object.notMove = true;
                Object.RootcanSpawn = false;
                if (PlayerPrefs.GetInt("highscore") < UI.score)
                {
                    PlayerPrefs.SetInt("highscore", UI.score);
                }
                if (Object.notMove == true)
                {

                    coinMenu.totalCoin = coinMenu.storeCoins + UI.coins;
                    PlayerPrefs.SetInt("coin", coinMenu.totalCoin);
                    gemMenu.totalGem = gemMenu.storeGems + UI.lifeGem;
                    PlayerPrefs.SetInt("gems", gemMenu.totalGem);
                }
            }
            Object.reset = true;
        }
            canCollide = false;
    }
    }
}
