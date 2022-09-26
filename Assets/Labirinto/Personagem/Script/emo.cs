using UnityEngine;

public class emo : MonoBehaviour {

    CharacterController controller;


     Animator animator;
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;
    Vector3 inputs;
   

    
    public float Velocity = 2f;
    public float gravity;
    
    [SerializeField] private AudioSource passosAudioSource;
    [SerializeField] private AudioClip passosAudioClp;

    void Start() {

    controller = GetComponent<CharacterController>(); 
    animator = GetComponent<Animator>();

        
    }

    void Update() {

         Vector3 finalVelocity = Velocity * inputs + vertical;

    
        inputs.Set(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
         controller.Move(finalVelocity * Time.deltaTime);

        
        vertical += gravity * Time.deltaTime * Vector3.up;

        if(controller.isGrounded) {
            vertical = Vector3.down;
        }


        if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0) {
            vertical = Vector3.zero;
        }

if (inputs != Vector3.zero)
        {
            animator.SetBool("andando", true);
            transform.forward = inputs;
        }
        else
        {
            animator.SetBool("andando", false);
        }

    }

private void passos()
{
    passosAudioSource.PlayOneShot(passosAudioClp);
}
}