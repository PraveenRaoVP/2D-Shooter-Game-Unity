using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    public float msBWShots = 100;
    public float muzzleVelocity = 35;

    float nextShotTime;

    public void Shoot() {
        if(Time.time > nextShotTime) {
            nextShotTime = Time.time + msBWShots / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.setSpeed(muzzleVelocity); 
        }
    }
}
