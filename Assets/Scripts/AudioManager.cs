using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;

    [Header("Audio Sources")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambienceSource;

    [Header("Audio Clips")]

    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioClip ambienceClip;

    
   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        musicSource.clip = musicClip;
        musicSource.Play();

        ambienceSource.clip = ambienceClip;
        ambienceSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        musicSource.loop = true;
        ambienceSource.loop = true;
    }
}
