
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [Header("Sound")]
    public Slider mainvolume;
    Slider sfx;
    Slider musicvolume;
    [Header("Controls")]
    Slider Msense;

    private void Awake()
    {
        mainvolume.value = PlayerPrefs.GetFloat("MainVolume");
    }

    public void ChangeMainVolume(float volume) 
    {
        globalvariables.mainsoundvolume = volume;
        PlayerPrefs.SetFloat("MainVolume", volume);
        PlayerPrefs.Save();
    }
      
}
