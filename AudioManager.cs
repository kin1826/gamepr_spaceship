using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public AudioSource sfxSource;
    public AudioSource musicSource;

    public AudioClip shootSound;
    public AudioClip explosionSound;
    public AudioClip hitSound;
    public AudioClip damageSound;
    public AudioClip shipDestroySound;
    public AudioClip starSound;
    public AudioClip winSound;
    public AudioClip winVoice;
    public AudioClip gameOverSound;
    
    public AudioClip clickSound;

    public AudioClip menuMusic;
    public AudioClip gameMusic;
    
    void  Awake()
    {
        // instance = this;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 🔥 sống xuyên scene
        }
        else
        {
            Destroy(gameObject); // tránh clone
        }
    }
    
    // SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    // Music
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
}
