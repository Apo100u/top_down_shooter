using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private Player player;
    private Weapon currentWeapon;

    public void Init(Player player)
    {
        this.player = player;
        SetWeapon(weapons[0]);
    }

    public void OnUpdate()
    {
        if (player.Input.FireButtonPressed)
        {
            currentWeapon.TryUse();
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
}