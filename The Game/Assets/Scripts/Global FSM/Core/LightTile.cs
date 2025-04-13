using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightTile : MonoBehaviour
{
    public bool IsOn { get; private set; }

    [Header("Görsel Işıklar")]
    public GameObject visualOn;
    public GameObject visualOff;

    [Header("Gerçek Light Bileşeni")]

    public Light2D targetLight; // 2D kullanıyorsan bunu da kullanabilirsin

    [Header("Açıkken Intensity")]
    public float activeIntensity = 2f;

    private void OnEnable()
    {
        TurnOff();
        
       
    }

    public void TurnOff()
    {
        IsOn = false;

        if (visualOn) visualOn.SetActive(false);
        if (visualOff) visualOff.SetActive(true);

        if (targetLight != null)
            targetLight.intensity = 0f;

        // targetLight2D.intensity = 0f;
    }
    public void Toggle()
    {
        IsOn = !IsOn;

        if (visualOn) visualOn.SetActive(IsOn);
        if (visualOff) visualOff.SetActive(!IsOn);

        if (targetLight != null)
            targetLight.intensity = IsOn ? activeIntensity : 0f;
    }
}