using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, 1f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private float m_JumpForce = 300f;              // Amount of force added when the player jumps.

    private Rigidbody2D m_Rigidbody2D;
    private bool FacingLeft = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;


    public void SetMovementSmoothing(float value)
    {
        m_MovementSmoothing = value;
    }


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }


    public void Move(float move, bool crouch, bool jump)
    {
        // Move the character by finding the target velocity
         Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
        if (jump)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }


        if (move < 0 && !FacingLeft)
        {
            Flip();
        }
        else if (move > 0 && FacingLeft)
        {
            Flip();
        }
    }
    private void Flip()
    {
        FacingLeft = !FacingLeft;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
