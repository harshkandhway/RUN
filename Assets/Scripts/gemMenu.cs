using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gemMenu : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI gem;
    public static int totalGem;
    public static int storeGems;

    // Start is called before the first frame update
    void Awake()
    {
        gem = gameObject.GetComponent<TextMeshProUGUI>();

        gem.text = PlayerPrefs.GetInt("gems", 0).ToString();
        storeGems = PlayerPrefs.GetInt("gems", 0);
    }
}
