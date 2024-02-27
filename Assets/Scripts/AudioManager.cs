
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudioSource;
    public GameObject bumperSFXAudioSource, switchOnSFXAudioSource, switchOffSFXAudioSource;

    void Start()
    {
        PlayBGM();   
    }

    private void PlayBGM() {
        bgmAudioSource.Play();
    }

    public void PlayBumperSFX(Vector3 spawnPosition) {
        GameObject sfxObject = Instantiate(bumperSFXAudioSource, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchOnSFX(Vector3 spawnPosition) {
        GameObject sfxObject = Instantiate(switchOnSFXAudioSource, spawnPosition, Quaternion.identity);
    }

    public void PlaySwitchOffSFX(Vector3 spawnPosition) {
        GameObject sfxObject = Instantiate(switchOffSFXAudioSource, spawnPosition, Quaternion.identity);
    }
}
