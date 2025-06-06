using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeControlUI : MonoBehaviour
{
    [Header("Volume Sliders")]
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;
    
    [Header("Volume Labels (Optional)")]
    public TextMeshProUGUI masterVolumeLabel;
    public TextMeshProUGUI bgmVolumeLabel;
    public TextMeshProUGUI sfxVolumeLabel;
    
    private void Start()
    {
        InitializeSliders();
        SetupSliderListeners();
    }
    
    // スライダーの初期値を設定
    private void InitializeSliders()
    {
        if (AudioManager.Instance != null)
        {
            if (masterVolumeSlider != null)
            {
                masterVolumeSlider.value = AudioManager.Instance.GetMasterVolume();
                UpdateVolumeLabel(masterVolumeLabel, masterVolumeSlider.value);
            }
            
            if (bgmVolumeSlider != null)
            {
                bgmVolumeSlider.value = AudioManager.Instance.GetBGMVolume();
                UpdateVolumeLabel(bgmVolumeLabel, bgmVolumeSlider.value);
            }
            
            if (sfxVolumeSlider != null)
            {
                sfxVolumeSlider.value = AudioManager.Instance.GetSFXVolume();
                UpdateVolumeLabel(sfxVolumeLabel, sfxVolumeSlider.value);
            }
        }
    }
    
    // スライダーのイベントリスナーを設定
    private void SetupSliderListeners()
    {
        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        }
        
        if (bgmVolumeSlider != null)
        {
            bgmVolumeSlider.onValueChanged.AddListener(OnBGMVolumeChanged);
        }
        
        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        }
    }
    
    // マスター音量変更時の処理
    public void OnMasterVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMasterVolume(value);
            UpdateVolumeLabel(masterVolumeLabel, value);
        }
    }
    
    // BGM音量変更時の処理
    public void OnBGMVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetBGMVolume(value);
            UpdateVolumeLabel(bgmVolumeLabel, value);
        }
    }
    
    // SFX音量変更時の処理
    public void OnSFXVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(value);
            UpdateVolumeLabel(sfxVolumeLabel, value);
        }
    }
    
    // 音量ラベルの更新
    private void UpdateVolumeLabel(TextMeshProUGUI label, float value)
    {
        if (label != null)
        {
            label.text = Mathf.RoundToInt(value * 100) + "%";
        }
    }
    
    private void OnDestroy()
    {
        // リスナーの削除
        if (masterVolumeSlider != null)
            masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);
        if (bgmVolumeSlider != null)
            bgmVolumeSlider.onValueChanged.RemoveListener(OnBGMVolumeChanged);
        if (sfxVolumeSlider != null)
            sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
    }
}