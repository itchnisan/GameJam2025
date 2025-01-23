using UnityEngine;
using UnityEngine.Audio;

public class OptionsPanel : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void SetVolume(float volume){
        audiomixer.SetFloat("volume",volume);
    }


    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }
}
