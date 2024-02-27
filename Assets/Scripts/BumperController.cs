using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private Collider ballCollider;
    [SerializeField] private float multiplier;
    [SerializeField] private Color baseColor;
    [SerializeField] private float score;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private VFXManager vfxManager;
    [SerializeField] private ScoreManager scoreManager;

    private Rigidbody ballRigBody;
    private Animator animator;
    private Renderer renderer;
    private void Awake()
    {
        ballRigBody = ballCollider.GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        renderer.material.color = baseColor;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider == ballCollider)
        {
            Debug.Log("Hit");
            ballRigBody.velocity *= multiplier;
            animator.SetTrigger("hit");

            audioManager.PlayBumperSFX(other.transform.position);
            vfxManager.PlayBumperVFX(other.transform.position);

            // Add score
            scoreManager.AddScore(score);
        }
    }
}
