using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private string horizontalInputAxis = "Horizontal";
    [SerializeField] private string verticalInputAxis = "Vertical";
    [SerializeField] private KeyCode fireKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode[] weaponKeys;

    public event Action<int> OnWeaponKeyPressed;

    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }
    public Vector3 MouseTarget { get; private set; }
    public bool FireButtonPressed { get; private set; }

    private Ray mouseRay;
    private RaycastHit mouseRaycastHit;

    public void OnUpdate()
    {
        GetMovementInput();
        GetWeaponInput();
        GetMouseTarget();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void GetMovementInput()
    {
        HorizontalInput = Input.GetAxisRaw(horizontalInputAxis);
        VerticalInput = Input.GetAxisRaw(verticalInputAxis);
    }

    private void GetWeaponInput()
    {
        FireButtonPressed = Input.GetKey(fireKey);

        for (int i = 0; i < weaponKeys.Length; i++)
        {
            if (Input.GetKeyDown(weaponKeys[i]))
            {
                OnWeaponKeyPressed?.Invoke(i);
            }
        }
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