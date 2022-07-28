using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    #region Variables
    public int damageValue;
    public UnitTypes targetType;
    #endregion

    public void ChangeHealth(GameObject unit)
    {
        unit.GetComponent<Health>().ChangeHealth(damageValue);
    }

    private void OnTriggerEnter(Collider target)
    {
        switch(targetType)
        {
            case UnitTypes.Enemy:
            if(target.CompareTag("Enemy"))
            {
                ChangeHealth(target.gameObject);
            }
            break;
            case UnitTypes.Player:
            if(target.CompareTag("Player"))
            {
                ChangeHealth(target.gameObject);
            }
            break;
            case UnitTypes.Obstacle:
            if(target.CompareTag("Obstacle"))
            {
                ChangeHealth(target.gameObject);
            }
            break;
        }
    }

}
