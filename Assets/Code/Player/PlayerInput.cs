using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private string horizontalInputAxis = "Horizontal";
    [SerializeField] private string verticalInputAxis = "Vertical";

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public Vector3 MouseTarget { get; private set; }

    private Ray mouseRay;
    private RaycastHit mouseRaycastHit;

    public void OnUpdate()
    {
        GetMovementInput();
        GetMouseTarget();
    }

    private void GetMovementInput()
    {
        HorizontalInput = Input.GetAxisRaw(horizontalInputAxis);
        VerticalInput = Input.GetAxisRaw(verticalInputAxis);
    }

    private void GetMouseTarget()
    {
        mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseRay, out mouseRaycastHit))
        {
            MouseTarget = mouseRaycastHit.point;
        }
    }
}