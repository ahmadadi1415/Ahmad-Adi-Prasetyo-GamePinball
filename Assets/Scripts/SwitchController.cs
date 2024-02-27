using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private Material onMaterial, offMaterial;
    [SerializeField] private float score;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private AudioManager audioManager;


    private Renderer renderer;
    private SwitchState state = SwitchState.Off;
    private enum SwitchState
    {
        On, Off, Blink
    }

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        Set(false);
        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == ballCollider)
        {
            vfxManager.PlaySwitchVFX(other.transform.position);
            Toggle();
            if (state == SwitchState.On) {
                audioManager.PlaySwitchOnSFX(other.transform.position);
            }
            else if (state == SwitchState.Off) {
                audioManager.PlaySwitchOffSFX(other.transform.position);
            }
        }
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }


    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
