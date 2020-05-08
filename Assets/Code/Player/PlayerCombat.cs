using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon[] weapons;

    private Weapon currentWeapon;

    public void Init(Player player)
    {
        SetWeapon(weapons[0]);
        player.Input.OnFireButtonDown += OnFireButtonDown;
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

    private void OnFireButtonDown()
    {
        currentWeapon.TryUse();
    }
}