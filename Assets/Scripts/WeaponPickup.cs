using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] WeaponSO _weaponSO;

    const string PLAYER_STRING = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_STRING))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();

            activeWeapon.SwitchWeapon(_weaponSO);
            Destroy(this.gameObject);
        }
    }
}
