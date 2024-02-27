using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private float length;

    private void OnTriggerEnter(Collider other) {
        if (other == ballCollider) {
            cameraController.FollowTarget(ballCollider.transform, length);
        }
    }
}
