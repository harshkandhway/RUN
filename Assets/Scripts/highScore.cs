using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highScore : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI highscore;
    void Start()
    {
        highscore = gameObject.GetComponent<TextMeshProUGUI>();
        highscore.text += PlayerPrefs.GetInt("highscore").ToString();
    }

    // Update is called once per fram
}
