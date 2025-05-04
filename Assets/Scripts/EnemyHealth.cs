using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _startingHealth = 3;

    int _currentHealth;

    void Awake() 
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;

        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
