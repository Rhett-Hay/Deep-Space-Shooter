using System;
using StarterAssets;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] int _damageAmount = 1;

    StarterAssetsInputs _starterAssetsInputs;

    const string SHOOT_STRING = "Shoot";

    void Awake() 
    {
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleShoot();       
    }

    private void HandleShoot()
    {
        if (!_starterAssetsInputs.shoot) return;

        _muzzleFlash.Play();
        _animator.Play(SHOOT_STRING, 0, 0f);
        _starterAssetsInputs.ShootInput(false);
        
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth?.TakeDamage(_damageAmount);
                
            //_starterAssetsInputs.ShootInput(false);
        }
    }
}
