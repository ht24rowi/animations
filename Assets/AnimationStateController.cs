using UnityEngine;
public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    float Velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decelation = 0.5f;
    int isWalkingHash;
    int isRunningHash;
    int VelocityHash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool forwardPressed = Input.GetKey("w");
        


        //Accel + Decel
        if (forwardPressed && Velocity < 1.0f)
        {
            Velocity += Time.deltaTime * acceleration;
        }
        
        if (!forwardPressed && Velocity > 0.0f)
        {
            Velocity -= Time.deltaTime * decelation;
        }
        if  (!forwardPressed && Velocity < 0.0f)
        {
            Velocity = 0.0f;
        }
        animator.SetFloat(VelocityHash, Velocity);

        //walking
        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);  
        }
        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }
        
        //Running
        if (!isRunning && (runPressed && forwardPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!runPressed || !forwardPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

    }
}
