using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPosition;

    private ObjectPooler _pooler;
    private Projectile _currentProjectileLoaded;
    private Turret _turret;

    private void Start() 
    {
        _pooler = GetComponent<ObjectPooler>();
        _turret = GetComponent<Turret>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            LoadProjectile();
        }

        if(_turret.CurrentEnemyTarget != null && _currentProjectileLoaded != null 
        && _turret.CurrentEnemyTarget.EnemyHealth.CurrentHealth > 0f)
        {
            _currentProjectileLoaded.transform.parent = null;
            _currentProjectileLoaded.SetEnemy(_turret.CurrentEnemyTarget);
        }

    }

    private void LoadProjectile()
    {
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.localPosition = projectileSpawnPosition.position;
        newInstance.transform.SetParent(projectileSpawnPosition);

        _currentProjectileLoaded = newInstance.GetComponent<Projectile>();

        newInstance.SetActive(true);
    }
}
