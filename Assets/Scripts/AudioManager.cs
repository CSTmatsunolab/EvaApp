using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [Header("Audio Mixer Settings")]
    public AudioMixer masterMixer;
    
    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float masterVolume = 1f;
    [Range(0f, 1f)]
    public float bgmVolume = 1f;
    [Range(0f, 1f)]
    public float sfxVolume = 1f;
    
    // PlayerPrefsのキー
    private const string MASTER_VOLUME_KEY = "MasterVolume";
    private const string BGM_VOLUME_KEY = "BGMVolume";
    private const string SFX_VOLUME_KEY = "SFXVolume";
    
    private void Awake()
    {
        // シングルトンパターンの実装
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadVolumeSettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        ApplyVolumeSettings();
    }
    
    // 音量設定を読み込み
    private void LoadVolumeSettings()
    {
        masterVolume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 1f);
        bgmVolume = PlayerPrefs.GetFloat(BGM_VOLUME_KEY, 1f);
        sfxVolume = PlayerPrefs.GetFloat(SFX_VOLUME_KEY, 1f);
    }
    
    // 音量設定を保存
    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, masterVolume);
        PlayerPrefs.SetFloat(BGM_VOLUME_KEY, bgmVolume);
        PlayerPrefs.SetFloat(SFX_VOLUME_KEY, sfxVolume);
        PlayerPrefs.Save();
    }
    
    // 音量設定を適用
    private void ApplyVolumeSettings()
    {
        if (masterMixer != null)
        {
            // AudioMixerを使用する場合
            SetMixerVolume("MasterVolume", masterVolume);
            SetMixerVolume("BGMVolume", bgmVolume);
            SetMixerVolume("SFXVolume", sfxVolume);
        }
        else
        {
            // AudioListenerを使用する場合
            AudioListener.volume = masterVolume;
        }
    }
    
    // AudioMixerの音量を設定（デシベル変換）
    private void SetMixerVolume(string parameterName, float volume)
    {
        float dbValue = volume > 0 ? Mathf.Log10(volume) * 20 : -80f;
        masterMixer.SetFloat(parameterName, dbValue);
    }
    
    // マスター音量を設定
    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        ApplyVolumeSettings();
        SaveVolumeSettings();
    }
    
    // BGM音量を設定
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        ApplyVolumeSettings();
        SaveVolumeSettings();
    }
    
    // SFX音量を設定
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        ApplyVolumeSettings();
        SaveVolumeSettings();
    }
    
    // 現在の音量を取得
    public float GetMasterVolume() => masterVolume;
    public float GetBGMVolume() => bgmVolume;
    public float GetSFXVolume() => sfxVolume;
}