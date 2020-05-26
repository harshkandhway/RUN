using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score;
    public static int lifeGem =0;
    public static int coins = 0;
    //public static int coin;
    public Text coinText;
    public Text kunai;
    public static int kunaiCount = 0;
    public Text t;
    public Text gem;
    public GameObject b;
    public GameObject panel;
    public GameObject exit;
    public GameObject menu;
    public GameObject pauseObj;
    public GameObject resumeObj;
    public bool isPaused = false;
    public static bool canDestroy = false;
    public GameObject playerObj;
    public GameObject resumeWithGem;
    public GameObject playerDestroy;
    GameObject[] enemies;
    public GameObject back;
    audioScript a; 
    sound[] sounds;

    void Start()
    {
        a = FindObjectOfType<audioScript>();
        playerDestroy = GameObject.FindGameObjectWithTag("play");
        if (MainMenu.isMusicOn == 0)
        {
            FindObjectOfType<audioScript>().StopPlaying("theme");
            FindObjectOfType<audioScript>().playSound("inGame");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&Object.notMove==false)
        {
            if (isPaused == true)
            {
                resume();
            }
            else
            {
                pause();
            }

        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                mainMenu("Menu");
                Object.RootcanSpawn = true;
            }
        }
        if (Object.reset == true)
        {
            
            //FindObjectOfType<audioScript>().playSound("inGame");
            //audioScript.audioSrc.volume = 0.3f;
            //audioScript.audioSrc.PlayDelayed(3.0f);
            pauseObj.SetActive(false);
            Object.reset = false;
            StartCoroutine(routine());
        }
    }
    public void updateScore()
    {
        score += 5;
        t.text = "Score: " + score;
        coins += 1;
        coinText.text = "x " + coins;
        PlayerPrefs.SetInt("coinCollect", coins);
    }

    public void updateKunai()
    {
        kunai.text = "x " + kunaiCount;
    }
    public void updateLifeGem() {
        lifeGem += 1;
        gem.text = "x " + lifeGem;
        PlayerPrefs.SetInt("gemCollect", lifeGem);
    }
   /* public static void totalUpdateCoin()
    {
        totalCoins += coins;
    }
    public static void totalUpdateGem()
    {
        totalGems += lifeGem;
    }*/

    public void restart(string newGame)
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        foreach (sound s in a.sounds)
            s.source.volume = 0.515f;
        if(MainMenu.isMusicOn==0)
        FindObjectOfType<audioScript>().playSound("inGame");
        Time.timeScale = 1;
        Object.RootcanSpawn = true;
        SceneManager.LoadScene(newGame);
        Move.canCollide = true;
        coinMenu.storeCoins = coinMenu.storeCoins + coins;
        gemMenu.storeGems = gemMenu.storeGems+ lifeGem; 
        score = 0;
        coins = 0;
        lifeGem = 0;
        Object.speed = 10.0f;
        Object.x = 0.0f;
        Object.notMove = false;
        Run.Dead = false;
        UI.kunaiCount = 0;
        //Move.canCollide = true;
        Player.isGlide = false;
        //Player.play.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        Player.play.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void mainMenu(string s)
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        //a = FindObjectOfType<audioScript>();
        if (MainMenu.isMusicOn==0)
        {
            FindObjectOfType<audioScript>().StopPlaying("inGame");
            FindObjectOfType<audioScript>().playSound("theme");
        }
        foreach (sound sM in a.sounds)
            sM.source.volume = 0.515f;
        Object.RootcanSpawn = true;
        score = 0;
        coins = 0;
        lifeGem = 0;
        Object.notMove = false;
        Run.Dead = false;
        isPaused = false;
        Object.speed = 10.0f;
        Object.x = 0.0f;
        Time.timeScale = 1;
        SceneManager.LoadScene(s);
        UI.kunaiCount = 0;
        //Move.canCollide = true;
    }
    public void pause()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        //audioScript.audioSrc.volume = 0.3f;
        b.SetActive(true);
        panel.SetActive(true);
        exit.SetActive(true);
        menu.SetActive(true);
        resumeObj.SetActive(true);
        pauseObj.SetActive(false);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void resume()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        //audioScript.audioSrc.volume = 0.515f;
        b.SetActive(false);
        panel.SetActive(false);
        exit.SetActive(false);
        menu.SetActive(false);
        pauseObj.SetActive(true);
        resumeObj.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void Back()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        back.SetActive(false);
    }
    IEnumerator routine()
    {
        yield return new WaitForSeconds(3.0f);
        foreach (sound s in a.sounds)
            s.source.volume = 0.1f;
        if(MainMenu.isMusicOn==0)
            FindObjectOfType<audioScript>().playSound("inGame");
        resumeWithGem.SetActive(true);
        panel.SetActive(true);
        b.SetActive(true);
        exit.SetActive(true);
        menu.SetActive(true);
    }
    public void resumeForGem()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        if (gemMenu.totalGem >= 50)
        {
            foreach (sound s in a.sounds)
                s.source.volume = 0.515f;
            gemMenu.storeGems -= 50;
            //Object.speed = 10.0f;
            //Object.x = 0.0f;
            Object.notMove = false;
            Run.Dead = false;
            Destroy(playerDestroy.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("play"));
            enemies = GameObject.FindGameObjectsWithTag("enemies");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);
            Object.RootcanSpawn = false;
            Instantiate(playerObj, new Vector3(-6.26f, -0.62f, 0), Quaternion.identity);
            // Move.canCollide = false;
            StartCoroutine(shieldRoutine());
            resumeWithGem.SetActive(false);
            panel.SetActive(false);
            b.SetActive(false);
            exit.SetActive(false);
            menu.SetActive(false);
            Move.canCollide = true;
        }
        else
        {
            back.SetActive(true);
        }
    }
    public void quit()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        Application.Quit();
    }

    public IEnumerator shieldRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Object.RootcanSpawn = true;
    }

}
