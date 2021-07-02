using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public Button saveButton, loadButton, creditsButton, settingsButton, soundTestButton;
    public Toggle windowedMode;
    public Dropdown Resolutions;
    private Resolution[] resolutionsList;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        //Time.timeScale = 1f; -Play
        // Time.timeScale = 0f; //-Pause

    }
    public void NewGame()
    {
        
        LoadingGame.isLoadGame = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
        
        
    }
    public void LoadGame()
    {

        LoadingGame.isLoadGame = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }
    public void Credits()
    {

    }
    public void Settings()
    {
       // Time.timeScale = 0f; //-Pause
    }
    public void SoundTest()
    {
        // Time.timeScale = 0f; //-Pause
    }
    public void Resume()
    {
        //Time.timeScale = 1f; -Play
    }
    public void SaveGame()
    {
      SaveSystem.SaveGame(player);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
