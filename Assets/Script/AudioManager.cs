using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;

    private int musicIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        
        
        if(!audioSource.isPlaying){
            audioSource.Play();
            //PlayNextSong();
        }
    }

    public void PlayNextSong(){
        musicIndex = (musicIndex +1)%playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
