using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate 
{
    public static float CalculateDamage(float damage, TypeProjectTile typeProjectTile, TypeArmor typeArmor)
    {
        float value1 = (float)typeProjectTile; // ��������������� �������� � float
        float value2 = (float)typeArmor; // ��������������� �������� � float

        return damage * value1 / value2; // ���� �������� �� ��������� �����, ����� �� ��������� �����
    }
}
