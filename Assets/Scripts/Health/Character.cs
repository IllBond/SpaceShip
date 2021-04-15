using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TypeArmor // В 
{
    Bullet = 1,
    Laser = 3,
    Missile = 12
}


//Абстрактый класс 
//На его основе нельзя создать обьек
//Он используетеся только как базовый
public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private TypeArmor _typeArmor; // Появится возможность выбрать из Юнити что то из списка выше 1,3,12

    [SerializeField]
    protected float health; // Жизни
    [SerializeField]
    protected float currentHealth; // Текущее к-во жизней

    public event Action<float> HealthChanged = default; // Событие. Вернет тип float


    protected void Awake()
    {
        SetHealth(health); // Как только ф-ция проснется
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage; //Уменьшит урон

        if (currentHealth < 0)
        {
            currentHealth = 0; 
        }

        if (HealthChanged != null) //Если получен урон и события есть подписчики
        {
            HealthChanged(currentHealth); // Теперь извне можно подписаться на это событие и передать в функцию float и когда получим урон сработает эта ф-ция
        }
    }
    

    //ф-ция вернет текущий тип урон данного обьекта
    public TypeArmor GetArmorType()
    {
        return _typeArmor; 
    }



    protected void SetHealth(float value)
    {
        currentHealth = health;
    }
}
