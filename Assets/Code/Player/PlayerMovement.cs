using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private const string HorizontalInputAxis = "Horizontal";
    private const string VerticalInputAxis = "Vertical";

    private Player player;
    private Vector3 movementDirection = new Vector3();
    private Vector3 rotationDirection = new Vector3();

    public void Init(Player player)
    {
        this.player = player;
    }

    public void OnUpdate()
    {
        Move();
        RotateTowardsMouse();
    }

    private void Move()
    {
        movementDirection = (Vector3.forward * player.Input.VerticalInput) + (Vector3.right * player.Input.HorizontalInput);
        transform.position += movementDirection.normalized * movementSpeed * Time.deltaTime;
    }

    private void RotateTowardsMouse()
    {
        rotationDirection = player.Input.MouseTarget - transform.position;
        transform.eulerAngles = Vector3.up * Mathf.Atan2(rotationDirection.x, rotationDirection.z) * Mathf.Rad2Deg;
    }
}