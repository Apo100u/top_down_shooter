using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    public PlayerInput Input { get { return input; } }

    [SerializeField] private PlayerMovement movement;
    public PlayerMovement Movement { get { return movement; } }

    private void Start()
    {
        movement.Init(this);
    }

    private void Update()
    {
        input.OnUpdate();
        movement.OnUpdate();
    }
}