using UnityEngine;
using StarterAssets;
using System;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO _weaponSO;

    Animator _animator;
    StarterAssetsInputs _starterAssetsInputs;
    Weapon _currentWeapon;

    const string SHOOT_STRING = "Shoot";

    float _timeSinceLastShot = 0f;

    private void Awake()
    {
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentWeapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        Debug.Log("Player picked up " +  weaponSO.name);

        if (_currentWeapon)
        {
            Destroy(_currentWeapon.gameObject);
        }

        Weapon newWeapon = Instantiate(weaponSO.WeaponPrefab, transform).GetComponent<Weapon>();
        _currentWeapon = newWeapon;
        this._weaponSO = weaponSO;
    }

    private void HandleShoot()
    {
        _timeSinceLastShot += Time.deltaTime;
        if (!_starterAssetsInputs.shoot) return;

        if(_timeSinceLastShot >= _weaponSO.FireRate)
        {
            _currentWeapon.Shoot(_weaponSO);
            _animator.Play(SHOOT_STRING, 0, 0f);
            _timeSinceLastShot = 0f;
        }

        if (!_weaponSO.isAutomatic)
        {
            _starterAssetsInputs.ShootInput(false);
        }
    }

    private void HandleZoom()
    {
        if (!_weaponSO.CanZoom) return;

        if (_starterAssetsInputs.zoom)
        {
            Debug.Log("Zooming In");
        }
        else
        {
            Debug.Log("Not Zooming In");
        }
    }
}
