using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public static audioManager Instance;
    public GameObject SoundPrefab;

    public AudioClip jumpSound;
    [Range(0f, 1f)] public float jumpVolume = 1.0f;
    [Space(10)]
    public AudioClip dashSound;
    [Range(0f, 1f)] public float dashVolume = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //Set the appropriate clips and volume on music and danger loop, then play
        /*musicSource.clip = backgroundMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();

        dangerSource.clip = dangerLoop;
        dangerSource.volume = 0f;
        dangerSource.Play();
        */

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip clipToPlay, float volume = 0.5f)
    {
        if (clipToPlay == null)
        {
            Debug.Log("AUDIO CLIP NOT ASSIGNED ON AUDIO DIRECTOR!");
            return;
        }
        
        GameObject newSound = Instantiate(SoundPrefab, Vector3.zero, Quaternion.identity);
        AudioSource newSoundSource = newSound.GetComponent<AudioSource>();
        newSoundSource.clip = clipToPlay;
        newSoundSource.volume = volume;
        Debug.Log("volume" + volume);
        newSoundSource.Play();
        Destroy(newSound, clipToPlay.length);
    }
}
