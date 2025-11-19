using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] Projectile projectile;
    [SerializeField] float muzzleVelocity;
    [SerializeField] float msBetweenSpawn;

    private float nextSpawn;

    public void Shoot()
    {
        
         if(Time.time>nextSpawn)
        {
            nextSpawn = Time.time + msBetweenSpawn / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.SetSpeed (muzzleVelocity);
        }

    }

}
