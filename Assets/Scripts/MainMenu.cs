using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject setting;
    public GameObject about;
    public GameObject how;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject soundOn;
    public GameObject soundOff;
    audioScript a;
    public static int isSoundOn;
    public static int isMusicOn;
    public bool isSoundButton;
    public bool isMusicButton;

    
    void Awake()
    {
        a = FindObjectOfType<audioScript>();
        isSoundOn = PlayerPrefs.GetInt("sound", 0);
        isMusicOn = PlayerPrefs.GetInt("music", 0);
        if (isSoundOn == 0)
        {
            isSoundButton = true;
            soundOn.SetActive(isSoundButton);
            soundOff.SetActive(false);
        }
        else {
            isSoundButton = true;
            soundOff.SetActive(isSoundButton);
            soundOn.SetActive(false);
        }
        if (isMusicOn == 0)
        {
            isMusicButton = true;
            musicOn.SetActive(isMusicButton);
            musicOff.SetActive(false);
        }
        else
        {
            isMusicButton = true;
            musicOff.SetActive(isMusicButton);
            musicOn.SetActive(false);
        }
    }
    
    
    public void settings()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        setting.SetActive(true);
    }
    public void aboutMenu()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        about.SetActive(true);
    }

    public void howMenu()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        how.SetActive(true);
    }
    public void SoundOn()
    {
        //if(PlayerPrefs.GetInt("sound"))
        PlayerPrefs.SetInt("sound", 1);
        isSoundOn = PlayerPrefs.GetInt("sound");
        isSoundButton = false;
        soundOn.SetActive(isSoundButton);
        soundOff.SetActive(true);
        //a.playSound("coin");
        //a.playSound("gems");
        //a.playSound("dead");
    }
    public void SoundOff()
    {
        PlayerPrefs.SetInt("sound", 0);
        isSoundOn = PlayerPrefs.GetInt("sound");
        isSoundButton = false;
        soundOff.SetActive(isSoundButton);
        soundOn.SetActive(true);
        //a.StopPlaying("coin");
        //a.StopPlaying("gems");
        //a.StopPlaying("dead");
        
    }
    public void MusicOn()
    {
        PlayerPrefs.SetInt("music", 1);
        isMusicOn = PlayerPrefs.GetInt("music");

        isMusicButton = false;
        musicOn.SetActive(isMusicButton);
        musicOff.SetActive(true);
        a.StopPlaying("theme");

    }
    public void MusicOff()
    {
        PlayerPrefs.SetInt("music", 0);
        isMusicOn = PlayerPrefs.GetInt("music");
        isMusicButton = false;
        musicOff.SetActive(isMusicButton);
        musicOn.SetActive(true);
        a.playSound("theme");
       
    }
    public void back()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        setting.SetActive(false);
        about.SetActive(false);
        how.SetActive(false);
    }

    public void Quit()
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        Application.Quit();
    }
}