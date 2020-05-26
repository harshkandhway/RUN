using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class object_spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] spawn;
    public GameObject coin;
    public int randomSpawnObjects;
    public float canSpawn = 0.0f;
    public float timer = 0f;
    public float y;
    float birdY = 0.0f;
    public float randomX;
    void Start()
    {
        spawnManager();
    }

    // Update is called once per frame
    public void spawnManager()
    {
            randomSpawnObjects = Random.Range(0, spawn.Length);
            switch (randomSpawnObjects)
            {
                case 0:
                
                y = 1.33f;
                    break;
                case 1:
                
                y = 1.41f;
                    break;
                case 2:
                
                    y = 1.3f;
                    break;
                case 3:
                
                    y = 1.78f;
                    break;
                case 4:
                
                y = 1.99f;
                    break;
                case 5:
                
                y = 4.04f;
                    birdY = 1.91f;
                    break;
            case 6:
                
                y = 1.55f;
                break;
        }
            Instantiate(spawn[randomSpawnObjects], new Vector3(transform.position.x, y, 0), Quaternion.identity);
            if (randomSpawnObjects == 5)
                Instantiate(coin, new Vector3(transform.position.x, 3.15f-birdY, 0), Quaternion.identity);
            else
                Instantiate(coin, new Vector3(transform.position.x, 3.15f, 0), Quaternion.identity);
            birdY = 0.0f;
        }
    }
