using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCharacter : Character
{
    void OnEnable() {
        HealthChanged += Say; // Подписаться. Функция Say сработает в другом месте
    }

    public void Say(float health) {
        Debug.Log(health);
    }
}
