using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomOutController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private CameraController cameraController;

    private void OnTriggerEnter(Collider other) {
        if (other == ballCollider) {
            cameraController.GoBackToDefault();
        }
    }
}
