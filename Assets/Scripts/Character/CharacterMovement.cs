using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour, IMovementController
{
    private const float raycastPadding = 0.1f;
    private PlayerInputActions.PlayerActions inputActions { get; set; }
    private InputAction movement { get; set; }
    private Animator Animator;

    [SerializeField] private CharacterAttributes characterAttributes;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Collider playerCollider;

    private bool isGrounded =>
        Physics.Raycast(playerCollider.bounds.center, Vector3.down,
            playerCollider.bounds.extents.z + raycastPadding);

    private void Awake()
    {
        inputActions = (new PlayerInputActions()).Player;
        characterAttributes ??= ScriptableObject.CreateInstance<CharacterAttributes>();
        playerCollider ??= GetComponentInChildren<Collider>();
        playerRigidbody ??= GetComponentInChildren<Rigidbody>();
        Animator ??= GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        movement = inputActions.Movement;
        inputActions.Jump.performed += JumpOnPerformed;
        inputActions.Attack.performed += AttackOnPerformed;
    }

    private void AttackOnPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Attack!");
    }

    public void Move()
    {
        var movementVector = movement.ReadValue<Vector2>();
        if (movementVector == Vector2.zero)
        {
            Animator.SetInteger("Running",0);

        }
        else if(movementVector.y == 1)
        {
            Animator.SetInteger("Running",1);

        } else if(movementVector.y == -1)
        {
            Animator.SetInteger("Running",-1);
        }
        else if(movementVector.x == 1)
        {
            Animator.SetInteger("Running",2);
        }
        else if(movementVector.x == -1)
        {
            Animator.SetInteger("Running",-2);
        }
        Debug.Log(Animator.GetInteger("Running"));
        Debug.Log(movementVector);
        transform.Translate(ApplyForce(movementVector.x), 0, ApplyForce(movementVector.y));

        float ApplyForce(float vector) => vector * Time.deltaTime * characterAttributes.MovementSpeed;
    }

    private void JumpOnPerformed(InputAction.CallbackContext context)
    {
         if (!isGrounded) return;

        playerRigidbody.AddForce(Vector3.up * characterAttributes.JumpSpeed, ForceMode.Impulse);
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Jump.Disable();
    }
}