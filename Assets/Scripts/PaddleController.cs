
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private KeyCode input;
    private HingeJoint hingeJoint;

    private float targetPressed, targetReleased;

    private void Awake() {
        hingeJoint = GetComponent<HingeJoint>();
        targetPressed = hingeJoint.limits.max;
        targetReleased = hingeJoint.limits.min;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput() {
        JointSpring jointSpring = hingeJoint.spring;

        if (Input.GetKey(input)) {
            jointSpring.targetPosition = targetPressed;;
        }
        else {
            jointSpring.targetPosition = targetReleased;
        }

        hingeJoint.spring = jointSpring;
    }
}
