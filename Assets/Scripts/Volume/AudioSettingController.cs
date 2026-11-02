using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class AudioSettingsController : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;

    [Header("Interface")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TMP_Text volumeText;

    private const string VolumeParameter = "MasterVolume";


    private void Start()
    {
        volumeSlider.minValue = 0;
        volumeSlider.maxValue = 100;
        volumeSlider.wholeNumbers = true;

        volumeSlider.onValueChanged.AddListener(SetVolume);

        volumeSlider.value = 50;
        SetVolume(50);
    }

    public void SetVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixer.SetFloat(VolumeParameter, -80f);
        }
        else
        {
            float decibels = Mathf.Log10(volume / 100f) * 20f;
            audioMixer.SetFloat(VolumeParameter, decibels);
        }

        volumeText.text = Mathf.RoundToInt(volume) + "%";
    }
}
