using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private float score;
    private void OnTriggerEnter(Collider other) {
        if (other == ballCollider) {
            scoreManager.AddScore(score);
        }
    }
}
