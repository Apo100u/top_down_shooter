using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    public PlayerInput Input { get { return input; } }

    [SerializeField] private PlayerMovement movement;
    public PlayerMovement Movement { get { return movement; } }

    [SerializeField] private PlayerCombat combat;
    public PlayerCombat Combat { get { return combat; } }

    [SerializeField] private Health health;
    public Health Health { get { return health; } }

    private void Start()
    {
        health.SetAsMax();
        movement.Init(this);
        combat.Init(this);
    }

    private void Update()
    {
        input.OnUpdate();
        movement.OnUpdate();
        combat.OnUpdate();
    }
}