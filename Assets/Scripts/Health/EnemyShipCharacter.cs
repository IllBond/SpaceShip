using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCharacter : Character
{
    void OnEnable() {
        HealthChanged += Say; // �����������. ������� Say ��������� � ������ �����
    }

    public void Say(float health) {
        Debug.Log(health);
    }
}
