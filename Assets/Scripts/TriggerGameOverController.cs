using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOverController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private GameObject gameOverCanvas;
    private void OnTriggerEnter(Collider other) {
        if (other == ballCollider) {
            gameOverCanvas.SetActive(true);
        }
    }
}
