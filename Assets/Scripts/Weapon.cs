using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs _starterAssetsInputs;

    void Awake() 
    {
        _starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_starterAssetsInputs.shoot)
        {
            RaycastHit _hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, Mathf.Infinity))
            {
                Debug.Log(_hit.collider.name);
                _starterAssetsInputs.ShootInput(false);
            }
        }
        
    }
}
