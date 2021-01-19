using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.Experimental.Rendering.RenderGraphModule;

public class WeatherRotation : MonoBehaviour
{
    private VolumeProfile volume;

    private void Update()
    {
        volume = GetComponent<Volume>().profile;
        if (!volume.TryGet<HDRISky>(out var sky))
        {
            sky = volume.Add<HDRISky>(false);
        }

        sky.rotation.value += 0.015f;

        //fog.enabled.overrideState = overrideFog;
        //fog.enabled.value = enableFog;
    }
}