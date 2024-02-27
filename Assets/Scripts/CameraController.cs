using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float returnTIme;
    [SerializeField] private float followSpeed;
    [SerializeField] private float length;
    [SerializeField] private Transform target;

    private Vector3 defaultPosition;

    public bool HasTarget
    {
        get
        {
            return target != null;
        }
    }

    private void Start()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void Update()
    {

        if (HasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetLength;
    }

    public void GoBackToDefault()
    {
        target = null;

        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPosition, returnTIme));

    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {

        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
