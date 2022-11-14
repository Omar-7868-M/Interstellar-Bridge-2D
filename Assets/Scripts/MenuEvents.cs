using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;


    public void SetVolume()
    {
        mixer.SetFloat("Volume", volumeSlider.value);
        
    }
    private void Start()
    {
        
        AudioManager.instance.Play("Menu");
        Time.timeScale = 1;
        mixer.GetFloat("Volume", out value);
        volumeSlider.value = value;
    }
    public void LoadLevel (int index)
    {
        SceneManager.LoadScene(index);
        AudioManager.instance.Stop("Menu");
    }
    
}
