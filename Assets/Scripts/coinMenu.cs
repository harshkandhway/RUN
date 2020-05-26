using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class coinMenu : MonoBehaviour
{

    TextMeshProUGUI coins;
    public static int totalCoin;
    
    public static int storeCoins;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        coins = gameObject.GetComponent<TextMeshProUGUI>();
        
        coins.text = PlayerPrefs.GetInt("coin", 0).ToString();
        storeCoins = PlayerPrefs.GetInt("coin", 0);
    }
    void Start()
    {
        
        
    }
    void updateCoin()
    {
       
    }
    }
