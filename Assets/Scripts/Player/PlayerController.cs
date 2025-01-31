using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float movementSpeed = 4f;

    private Rigidbody playerRB;
    
    public void Initialize()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    public void UpdateCharacterController()
    {
        Vector2 direction = joystick.inputDirection;
        playerRB.velocity = direction * movementSpeed;
    }
}
