using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private KeyCode input;
    [SerializeField] private float maxForce;
    [SerializeField] private float maxTimeHold;
    [SerializeField] private Color holdColor;

    private bool isHold = false;

    private Renderer renderer;
    private Color baseColor;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        baseColor = renderer.material.color;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.collider == ballCollider)
        {
            ReadInput(other.collider);
        }
    }

    private void ReadInput(Collider collider)
    {
        if (Input.GetKey(input) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    private IEnumerator StartHold(Collider collider)
    {
        isHold = true;
        float force = 0.0f;
        float timeHold = 0.0f;
        while (Input.GetKey(input))
        {
            force = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;

            renderer.material.color = holdColor;
        }
        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        isHold = false;
        renderer.material.color = baseColor;
    }
}
