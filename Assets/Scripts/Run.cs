using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    // Start is called before the first frame update
    Material m;
    public float x;
    public static bool Dead = false;
    void Start()
    {
        m = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
            if (Dead == false)
                m.mainTextureOffset += new Vector2(x, 0) * Time.deltaTime;
            else
                m.mainTextureOffset += new Vector2(0, 0) * Time.deltaTime;
        }
    }