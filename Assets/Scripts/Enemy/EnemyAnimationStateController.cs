using UnityEngine;

public class EnemyAnimationStateController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnAwake()
    {
        animator ??= GetComponent<Animator>();
    }
    
    
}
