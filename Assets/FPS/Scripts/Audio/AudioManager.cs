using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines a WWise RTPC to be set.<br></br>
/// Based on a physic material, sets an RTPC to rtpcValue if the physic material matches an input.
/// </summary>
[System.Serializable]
public struct AudioMaterial
{
    public PhysicMaterial physicMaterial;
    public AK.Wwise.Switch materialSwitch;
}



public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public AudioMaterial[] audioMaterials;
    public Dictionary<PhysicMaterial, AK.Wwise.Switch> audioMaterialDictionary = new();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioMaterialDictionary = new();
        for (int i = 0; i < audioMaterials.Length; i++)
        {
            audioMaterialDictionary.Add(audioMaterials[i].physicMaterial, audioMaterials[i].materialSwitch);
        }
    }
    public void SetSwitchByPhysicMaterial(GameObject obj, PhysicMaterial material)
    {
        audioMaterialDictionary[material].SetValue(obj);
    }
}
