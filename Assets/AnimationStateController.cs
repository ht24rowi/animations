using UnityEngine;
public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        isJumpingHash = Animator.StringToHash("isJumping");
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool runPressed = Input.GetKey(KeyCode.LeftShift);
        bool forwardPressed = Input.GetKey("w");
        bool jumpPressed = Input.GetKey("d");
        


        //movement logic

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
        
        //jumping
        if (jumpPressed && isRunning)
        {
            animator.SetTrigger(isJumpingHash);
        }

    }
}
