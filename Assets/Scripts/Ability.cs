using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    #region Variables
    public GameObject projectile;
    public float attackSpeed;
    public Vector3 spawnOffset;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireProjectileRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FireProjectileRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackSpeed); //Pauses the Corotine for seconds equal to attackSpeed
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        Instantiate(projectile, transform.parent.position + spawnOffset, transform.parent.rotation);
    }
}
