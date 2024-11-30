using UnityEngine;
using UnityEngine.Audio;

public class PlayRandomMusic : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip[] musicTracks;

    private void Start()
    {
        playRandomSong();
    }

    public void playRandomSong()
    {
        int randomindex = Random.Range(0, musicTracks.Length);
        audioSource.clip = musicTracks[randomindex];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying) 
        {
            playRandomSong();
        }

    }
}
