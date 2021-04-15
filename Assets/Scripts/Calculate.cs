using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate 
{
    public static float CalculateDamage(float damage, TypeProjectTile typeProjectTile, TypeArmor typeArmor)
    {
        float value1 = (float)typeProjectTile; // Преобразовываем значение в float
        float value2 = (float)typeArmor; // Преобразовываем значение в float

        return damage * value1 / value2; // урон умножаем на множетель урона, делим на множетель брони
    }
}
