using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;

    private int musicIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    // Update is called once per frame
    public void Update()
    {
        Debug.Log("mel 1");
        // Changer la musique selon les conditions
        if (PlayerController.hasMelody1 && musicIndex != 1)
        {
            musicIndex = 1;
            PlayCurrentSong();
            Debug.Log("mel 1");
        }

        if (PlayerController.hasMelody2 && musicIndex != 2)
        {
            musicIndex = 2;
            PlayCurrentSong();
            Debug.Log("mel 2");
        }

        if (PlayerController.hasMelody3 && musicIndex != 3)
        {
            musicIndex = 3;
            PlayCurrentSong();
            Debug.Log("mel 3");
        }


        // Si la musique n'est pas en train de jouer, la jouer
        if (!audioSource.isPlaying)
        {
            Debug.Log("pas de musique");
            PlayCurrentSong();
        }
    }

    // Méthode pour jouer la chanson actuelle
    private void PlayCurrentSong()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
