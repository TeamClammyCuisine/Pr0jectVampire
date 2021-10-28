using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
public class Character : MonoBehaviour
{
    private IMovementController m_MovementController;

    private void Awake()
    {
        m_MovementController ??= GetComponent<CharacterMovement>();
    }

    private void FixedUpdate()
    {
        m_MovementController.Move();
    }
}
