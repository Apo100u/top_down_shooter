using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private Player player;
    private Weapon currentWeapon;

    public void Init(Player player)
    {
        this.player = player;
        player.Input.OnWeaponKeyPressed += OnWeaponKeyPressed;
        SetWeapon(weapons[0]);
    }

    private void OnWeaponKeyPressed(int index)
    {
        if (index < weapons.Length)
        {
            SetWeapon(weapons[index]);
        }
    }

    private void SetWeapon(Weapon weapon)
    {
        if (currentWeapon != weapon)
        {
            currentWeapon?.gameObject.SetActive(false);
            weapon.gameObject.SetActive(true);

            currentWeapon = weapon;
        }
    }

    public void OnUpdate()
    {
        if (player.Input.FireButtonPressed)
        {
            currentWeapon.TryUse();
        }
    }
}