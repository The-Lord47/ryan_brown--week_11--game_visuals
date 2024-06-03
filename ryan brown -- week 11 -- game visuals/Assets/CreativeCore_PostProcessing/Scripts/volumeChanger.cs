using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class volumeChanger : MonoBehaviour
{
    [SerializeField] private Volume globalVolOverlay, globalVolBase;
    private ColorAdjustments _colAdj;
    


    [SerializeField] private GameObject UI;
    [SerializeField] private Slider bloomSlider, vignetteSlider, crAbSlider;
    [SerializeField] private TMP_Dropdown filterDropdown;
    private bool UIactive;
    private Bloom _bloom;
    private Vignette _vignette;
    private ChromaticAberration _CrAb;


    // Start is called before the first frame update
    void Start()
    {
        globalVolBase.profile.TryGet(out _colAdj);
        globalVolBase.profile.TryGet(out _bloom);
        globalVolBase.profile.TryGet(out _vignette);
        globalVolBase.profile.TryGet(out _CrAb);
    }

    // Update is called once per frame
    void Update()
    {
        ToggleUI();
    }


    public void PostProcessingToggle()
    {
        globalVolBase.enabled = !globalVolBase.enabled;
    }

    public void BloomToggle()
    {
        _bloom.active = !_bloom.active;
    }

    public void BloomSlider()
    {
        _bloom.intensity.value = bloomSlider.value;
    }

    public void VignetteToggle()
    {
        _vignette.active = !_vignette.active;
    }

    public void VignetteSlider()
    {
        _vignette.intensity.value = vignetteSlider.value;
    }

    public void CrAbToggle()
    {
        _CrAb.active = !_CrAb.active;
    }

    public void CrAbSlider()
    {
        _CrAb.intensity.value = crAbSlider.value;
    }

    public void FilterDropdown()
    {
        if(filterDropdown.value == 1)
        {
            _colAdj.saturation.value = -100;
        }
        else
        {
            _colAdj.saturation.value = 0;
        }
    }

    void ToggleUI()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIactive = !UIactive;
            UI.SetActive(UIactive);
        }
    }





    public void ChangeVolSettings()
    {
        globalVolOverlay.priority = 5;
        globalVolOverlay.weight = 1;
    }

    public void blackAndWhiteFilter()
    {
        _colAdj.saturation.value = -100f;
    }
}
