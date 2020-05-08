using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    public PlayerInput Input { get { return input; } }

    [SerializeField] private PlayerMovement movement;
    public PlayerMovement Movement { get { return movement; } }

    [SerializeField] private PlayerCombat combat;
    public PlayerCombat Combat { get { return combat; } }

    private void Start()
    {
        movement.Init(this);
        combat.Init(this);
    }

    private void Update()
    {
        input.OnUpdate();
        movement.OnUpdate();
    }
}