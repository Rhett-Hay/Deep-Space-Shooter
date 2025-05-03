using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RaycastHit _hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, Mathf.Infinity))
        {
            Debug.Log(_hit.collider.name);
        }
    }
}
