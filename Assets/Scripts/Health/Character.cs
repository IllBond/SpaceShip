using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeArmor // � 
{
    Bullet = 1,
    Laser = 3,
    Missile = 12
}


//���������� ����� 
//�� ��� ������ ������ ������� �����
//�� ������������� ������ ��� �������
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private TypeArmor _typeArmor; // �������� ����������� ������� �� ����� ��� �� �� ������ ���� 1,3,12

    [SerializeField]
    protected float health; // �����
    [SerializeField]
    protected float currentHealth; // ������� �-�� ������

    public event Action<float> HealthChanged = default; // �������. ������ ��� float


    protected void Awake()
    {
        SetHealth(health); // ��� ������ �-��� ���������
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; //�������� ����

        if (currentHealth < 0)
        {
            currentHealth = 0; 
        }

        if (HealthChanged != null) //���� ������� ���� � ������� ���� ����������
        {
            HealthChanged(currentHealth); // ������ ����� ����� ����������� �� ��� ������� � �������� � ������� float � ����� ������� ���� ��������� ��� �-���
        }
    }
    

    //�-��� ������ ������� ��� ���� ������� �������
    public TypeArmor GetArmorType()
    {
        return _typeArmor; 
    }



    protected void SetHealth(float value)
    {
        currentHealth = health;
    }
}
