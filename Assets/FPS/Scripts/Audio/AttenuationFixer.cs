using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For some godforsaken reason, the attenuation scaling factor is set to 0 on a lot of game objects. This script should fix that. 
/// </summary>
public class AttenuationFixer : MonoBehaviour
{
    public float attenuationFactor = 1;
    private void Awake()
    {
        if(TryGetComponent(out AkGameObj ago)){
            AkSoundEngine.SetScalingFactor(gameObject, 1);
        }
    }
}
