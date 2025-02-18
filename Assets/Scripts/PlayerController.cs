using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpForce = 10;

    private Vector2 movementInput;
    private bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove (InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        // Jump();
    }
    
    void OnJump()
    {
        const int jumpForceMultiplier = 3;
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce * jumpForceMultiplier, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(movementInput.x, 0.0f, movementInput.y);
        Vector3 worldMovement = transform.TransformDirection(movement) * moveSpeed;
        rb.linearVelocity = new Vector3(worldMovement.x, rb.linearVelocity.y, worldMovement.z); }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            
            Scorer scorer = gameObject.GetComponent<Scorer>();
            
            int finalScore = scorer.GetFinalScore();
            Debug.Log($"Your score is {finalScore}/100");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
