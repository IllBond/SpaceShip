using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseWeaponSystem : MonoBehaviour
{
    // ��������� ����� ��� ���� ��� �� ���������� ������, �������� Weapon, Rocket � Laser � ��� ����� ��������� IWeapon

    // ����� ����������
    // �� ���� ������� ������� ������� ������� � ���� �� ������
    // � ���������� ������� �������� OnFired ������� ������� � ������ �����
    // OnFired ���������� ��� ������ � ��������� �� ���������� Fire 



    // ������ � HeshSet ������� ����� ��������� � ���� �� ������� ������� ������������� ��������� �� �������
    // List<IWeapon> weapons = new List<IWeapon>();
    protected HashSet<IWeapon> _weapons = new HashSet<IWeapon>();

    public void AddWeapon(IWeapon weapon)
    {
        _weapons.Add(weapon); // ��������� ������
    }

    public void RemoveWeapon(IWeapon weapon)
    {
        _weapons.Remove(weapon); //������� ������
    }


    protected virtual void OnEnable() // ������� 
    {
        FindObjectOfType<PlayerInput>().Fired += OnFired; // �������� � ������� OnFired
    }
    /*
        private void OnDisable()  // ������� 
        {
            FindObjectOfType<PlayerInput>().Fired -= OnFired; // ������ �� ������� OnFired
        }*/

    protected virtual void OnFired()
    {
        //���������� ��� ������ � �� ������� ��������� � ��� ��������� �����
        foreach (var weapon in _weapons)
        {
            weapon.Fire();
        }

    }
}


public class WeaponSystem : BaseWeaponSystem
{
   
}
