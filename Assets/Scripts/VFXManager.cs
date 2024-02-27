using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject bumperVFXSource;
    public GameObject switchVFXSource;

    public void PlayBumperVFX(Vector3 spawnPosition)
    {
        GameObject sfxObject = Instantiate(bumperVFXSource, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchVFX(Vector3 spawnPosition)
    {
        GameObject sfxObject = Instantiate(switchVFXSource, spawnPosition, Quaternion.identity);
    }
}
