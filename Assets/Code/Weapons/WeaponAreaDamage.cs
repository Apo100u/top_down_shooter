using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAreaDamage : Weapon
{
    [Tooltip("Each ray applies damage randomized from weapon data.")]
    [SerializeField] int raysPerShot = 5;
    [SerializeField] [Range(0, 360)] private float shotAngle = 80f;
    [SerializeField] private Transform shotOrigin;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletsTransform;

    private Vector3 newOriginEulerAngles = new Vector3();
    private RaycastHit raycastHit;
    private Health hitHealth;
    private GameObject[] bullets;
    private WaitForSeconds waitForBulletsHide = new WaitForSeconds(0.05f);

    private void Start()
    {
        SpawnBulletsToVisualize();
    }

    private void SpawnBulletsToVisualize()
    {
        bullets = new GameObject[raysPerShot];
        GameObject bullet;

        for (int i = 0; i < raysPerShot; i++)
        {
            bullet = Instantiate(bulletPrefab.gameObject, bulletsTransform);
            bullet.transform.localScale = new Vector3(bullet.transform.localScale.x, bullet.transform.localScale.y, range);
            bullet.gameObject.SetActive(false);
            bullets[i] = bullet;
        }
    }

    public override void OnSuccessfulUse()
    {
        CheckBulletsHit();
    }

    private void CheckBulletsHit()
    {
        for (int i = 0; i < raysPerShot; i++)
        {
            newOriginEulerAngles = Vector3.zero;
            newOriginEulerAngles.y += (-shotAngle / 2f) + (i * (shotAngle / (raysPerShot - 1)));
            shotOrigin.localEulerAngles = newOriginEulerAngles;

            VisualizeBullet(bullets[i], shotOrigin);

            if (Physics.Raycast(shotOrigin.position, shotOrigin.forward, out raycastHit, range))
            {
                hitHealth = raycastHit.collider.GetComponent<Health>();

                if (hitHealth != null)
                {
                    hitHealth.ChangeCurrentBy(-Random.Range(minDamage, maxDamage));
                }
            }

            StartCoroutine(HideBulletsDelayed());
        }
    }

    private void VisualizeBullet(GameObject bullet, Transform origin)
    {
        bullet.SetActive(true);
        bullet.transform.position = origin.position;
        bullet.transform.eulerAngles = origin.eulerAngles;
    }

    private IEnumerator HideBulletsDelayed()
    {
        yield return waitForBulletsHide;

        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].SetActive(false);
        }
    }
}