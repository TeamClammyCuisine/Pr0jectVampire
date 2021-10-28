using UnityEngine;

[CreateAssetMenu(menuName = "Character Attributes")]
public class CharacterAttributes : ScriptableObject
{
    [Range(1, 15)] [SerializeField] private float movementSpeed;
    [Range(1, 15)] [SerializeField] private float jumpSpeed;
    
    public float MovementSpeed => movementSpeed;
    public float JumpSpeed => jumpSpeed;
}