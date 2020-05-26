using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Object : MonoBehaviour
{
    // Start is called before the first frame update
    public static float speed =9.3f;
    public static bool notMove = false;
    public float randomX;
    public GameObject[] spawn;
    public GameObject coin;
    public int randomSpawnObjects;
    int i = 100; public static float x = 0.2f;
    public static bool reset = false;
    public float seconds =1.2f;
    public float canSpawn = 0.0f;
    public float timer = 0f;
    public float y;
    float birdY = 0.0f;
    public GameObject[] lifeGem;
    public GameObject player;
    public static bool RootcanSpawn = false;
    public static bool enemiesCanMove = false;
    //public GameObject kunai;

    void Start()
    {
        Instantiate(player, new Vector3(-6.26f, -0.62f, 0), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (RootcanSpawn == true)
        {
            if (UI.score % i == 0 && UI.score >= i && UI.score <= 500)
            {
                speed += (float)0.45f * Time.deltaTime;
                x += (float)0.01f * Time.deltaTime;
                //seconds = 1.0f;
            }
            else if (UI.score % i == 0 && UI.score >= 500 && UI.score <= 1300f)
            {
                if(UI.score>=900)
                    enemiesCanMove = true;
                speed += (float)0.4f * Time.deltaTime;
                x += (float)0.01f * Time.deltaTime;
                
            }
            timer += Time.deltaTime;
            if (timer >= canSpawn && notMove == false)
            {
                randomSpawnObjects = Random.Range(0, spawn.Length);
                switch (randomSpawnObjects)
                {
                    case 0:
                        y = -2.69f;
                        break;
                    case 1:
                        y = -2.58f;
                        break;
                    case 2:
                        y = -2.67f;
                        break;
                    case 3:
                        y = -2.35f;
                        break;
                    case 4:
                        y = -2.11f;
                        break;
                    case 5:
                        y = -2.53f;
                        break;
                    case 6:
                        y = 0.0f;
                        birdY = -3.23f;
                        break;
                    case 7:
                            y = -2.03f;
                            break;
                    case 8:
                        y = -1.98f;
                        break;
                    case 9:
                        y = -2.03f;
                        break;
                }
                randomX = Random.Range(22.50f, 27.0f) + x;
                Instantiate(spawn[randomSpawnObjects], new Vector3(randomX, y, 0), Quaternion.identity);
                if (randomSpawnObjects == 6)
                {
                    int randomLifeGem = Random.Range(0, lifeGem.Length);
                    Instantiate(lifeGem[randomLifeGem], new Vector3(randomX, 1.24f, 0), Quaternion.identity);

                    Instantiate(coin, new Vector3(randomX, birdY + 1.24f, 0), Quaternion.identity);

                }
                //else if (randomSpawnObjects >= 7)
                //{
                  //  enemiesCanMove = true;
                //}
                else
                    Instantiate(coin, new Vector3(randomX, 1.24f, 0), Quaternion.identity);
                birdY = 0.0f;
                canSpawn += seconds;
            }
        }
    }
}
