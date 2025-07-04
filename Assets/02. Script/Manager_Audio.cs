using System;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource_BGM;
    [SerializeField] private AudioSource audioSource_SFX;

    [SerializeField] private AudioClip[] clips_BGM;
    [SerializeField] private AudioClip[] clips_SFX;
    
    [SerializeField] private Slider volume_BGM;
    [SerializeField] private Slider volume_SFX;
    
    [SerializeField] private Toggle mute_BGM;
    [SerializeField] private Toggle mute_SFX;
    
    private void Awake()
    {
        volume_BGM.value = audioSource_BGM.volume;
        volume_SFX.value = audioSource_SFX.volume;
        
        mute_BGM.isOn = audioSource_BGM.mute;
        mute_SFX.isOn = audioSource_SFX.mute;
    }

    private void Start()
    {
        BGM_Play("BGM");
        
        volume_BGM.onValueChanged.AddListener(On_BGM_Volume);
        volume_SFX.onValueChanged.AddListener(On_SFX_Volume);
        
        mute_BGM.onValueChanged.AddListener(On_BGM_Mute);
        mute_SFX.onValueChanged.AddListener(On_SFX_Mute);
    }

    public void BGM_Play(string clipName)
    {
        foreach (var clip in clips_BGM)
        {
            if (clip.name == clipName)
            {
                audioSource_BGM.clip = clip;
                audioSource_BGM.Play();
                return;
            }
        }
    }
    
    public void SFX_Play(string clipName)
    {
        foreach (var clip in clips_SFX)
        {
            if (clip.name == clipName)
            {
                audioSource_SFX.PlayOneShot(clip);
                return;
            }
        }
    }

    private void On_BGM_Mute(bool isMute)
    {
        audioSource_BGM.mute = isMute;
    }

    private void On_SFX_Mute(bool isMute)
    {
        audioSource_SFX.mute = isMute;
    }

    private void On_BGM_Volume(float volume)
    {
        audioSource_BGM.volume = volume;
    }

    private void On_SFX_Volume(float volume)
    {
        audioSource_SFX.volume = volume;
    }
    
}
