using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loadingScreen;
    public Slider slider;
    public void startGame(int sceneIndex)
    {
        if (MainMenu.isSoundOn == 0)
            FindObjectOfType<audioScript>().playSound("button");
        Time.timeScale = 1;
        //Move.canCollide = true;
        
        
        Object.RootcanSpawn = true; //can spawn root
        StartCoroutine(load(sceneIndex));
    }
    IEnumerator load(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            
            slider.value = operation.progress;
            yield return null;

        }
    }
}
