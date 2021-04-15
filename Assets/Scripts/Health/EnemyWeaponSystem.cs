using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSystem : BaseWeaponSystem
{

    protected override void OnEnable() {
        if (GetComponent<EnemyTowerAI>()) { 
            GetComponent<EnemyTowerAI>().Fired += OnFired; 
        } 

        if (GetComponent<EnemyShipAI>()) { 
            GetComponent<EnemyShipAI>().Fired += OnFired; 
        }
            
    }
}
