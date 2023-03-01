using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public GameObject settingsMenu;
    public Slider volumeSlider;

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        volumeSlider.value = savedVolume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("name of the scene");
    }

    public void OpenSettings()
    {

        settingsMenu.SetActive(true);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
    }

    public void CloseSettings()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        settingsMenu.SetActive(false);
    }

  /*  public void QuitGame()
    {
      
        Application.Quit();
    }*/
}
