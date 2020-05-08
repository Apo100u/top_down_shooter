using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectileShooter : Weapon
{
    [SerializeField] private GameObjectPool projectilePool;
    [SerializeField] private float projectileSpeed;

    private Dictionary<GameObject, float> shotProjectilesDistances = new Dictionary<GameObject, float>();
    private List<GameObject> projectilesToDisable = new List<GameObject>();
    private Vector3 projectileMovement = new Vector3();
    private Collider[] hitColliders;

    public override void OnSuccessfulUse()
    {
        shotProjectilesDistances.Add(projectilePool.Take(), 0f);
    }

    private void Update()
    {
        if (shotProjectilesDistances.Count > 0)
        {
            ManageShotProjectiles();
        }
    }

    private void ManageShotProjectiles()
    {
        projectilesToDisable.Clear();

        foreach (GameObject shotProjectile in shotProjectilesDistances.Keys.ToList())
        {
            MoveProjectile(shotProjectile);
            CheckProjectileHit(shotProjectile);

            shotProjectilesDistances[shotProjectile] += projectileMovement.magnitude;

            if (shotProjectilesDistances[shotProjectile] >= range)
            {
                AddProjectileToDisable(shotProjectile);
            }
        }

        for (int i = 0; i < projectilesToDisable.Count; i++)
        {
            shotProjectilesDistances.Remove(projectilesToDisable[i]);
            projectilePool.Return(projectilesToDisable[i]);
        }
    }

    private void MoveProjectile(GameObject projectile)
    {
        projectileMovement = projectile.transform.forward * projectileSpeed * Time.deltaTime;
        projectile.transform.position += projectileMovement;
    }

    private void CheckProjectileHit(GameObject projectile)
    {
        hitColliders = Physics.OverlapSphere(projectile.transform.position, 0.1f);

        Health health;

        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                health = hitColliders[i].GetComponent<Health>();

                if (health != null)
                {
                    health.ChangeCurrentBy(-Random.Range(minDamage, maxDamage));
                }
            }

            AddProjectileToDisable(projectile);
        }
    }

    private void AddProjectileToDisable(GameObject projectile)
    {
        if (!projectilesToDisable.Contains(projectile))
        {
            projectilesToDisable.Add(projectile);
        }
    }
}