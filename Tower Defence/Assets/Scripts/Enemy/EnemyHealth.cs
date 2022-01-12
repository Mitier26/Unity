using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour
{
    public static Action OnEnemykilled;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;

    [SerializeField] private float initiaHealth = 10;
    [SerializeField] private float maxHealth = 10;

    public float CurrentHealth{ get; set; }

    private Image _healthBar;

    private void Start() 
    {
        CreateHealthBar();
        CurrentHealth = initiaHealth;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
        {
            DealDamege(5);
        }

        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount , CurrentHealth/maxHealth, Time.deltaTime *10f);
    }
    void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);

        EnemyHealthContainer container = newBar.GetComponent<EnemyHealthContainer>();
        _healthBar = container.FillAmountImage;
    }

    public void DealDamege(float damageReceived)
    {
        CurrentHealth -= damageReceived;
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = initiaHealth;
        _healthBar.fillAmount = 1f;
    }

    void Die()
    {
        ResetHealth();
        OnEnemykilled?.Invoke();

        ObjectPooler.ReturnToPool(gameObject);
    }
}
