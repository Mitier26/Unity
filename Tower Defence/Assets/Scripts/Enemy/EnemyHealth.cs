using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour
{
    public static Action<Enemy> OnEnemykilled;
    public static Action<Enemy> OnEnemyHit;

    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;

    [SerializeField] private float initiaHealth = 10;
    [SerializeField] private float maxHealth = 10;

    public float CurrentHealth{ get; set; }

    private Image _healthBar;
    private Enemy _enemy;

    private void Start() 
    {
        CreateHealthBar();
        CurrentHealth = initiaHealth;

        _enemy = GetComponent<Enemy>();
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
        else
        {
            OnEnemyHit?.Invoke(_enemy);
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = initiaHealth;
        _healthBar.fillAmount = 1f;
    }

    void Die()
    {
        OnEnemykilled?.Invoke(_enemy);
    }
}
