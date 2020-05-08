using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : Weapon
{
    [SerializeField] private GameObjectPool projectilePool;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRange;

    private Dictionary<GameObject, float> shotProjectilesDistances = new Dictionary<GameObject, float>();
    private List<GameObject> projectilesToDisable = new List<GameObject>();
    private Vector3 projectileMovement = new Vector3();

    public override void OnSuccessfulUse()
    {
        shotProjectilesDistances.Add(projectilePool.Take(), 0f);
    }

    private void Update()
    {
        ManageShotProjectiles();
    }

    private void ManageShotProjectiles()
    {
        projectilesToDisable.Clear();

        foreach (GameObject shotProjectile in shotProjectilesDistances.Keys.ToList())
        {
            MoveProjectile(shotProjectile);
            CheckProjectileHit(shotProjectile);

            shotProjectilesDistances[shotProjectile] += projectileMovement.magnitude;

            if (shotProjectilesDistances[shotProjectile] >= projectileRange)
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

    }

    private void AddProjectileToDisable(GameObject projectile)
    {
        if (!projectilesToDisable.Contains(projectile))
        {
                projectilesToDisable.Add(projectile);
        }
    }
}