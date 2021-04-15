using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseWeaponSystem : MonoBehaviour
{
    // Интерфейс нужен для того что бы обьеденить оружие, например Weapon, Rocket и Laser у них будет интерфейс IWeapon

    // Класс существует
    // Из него вызваем функцию которая добавит в него же орудия
    // В обработчик осбытий передаем OnFired который вызовем в другом месте
    // OnFired переберает все орудия и запускает из интерфейса Fire 



    // Список и HeshSet который будет принимать в себя те обьекты которые реализовывают интерфейс но быстрее
    // List<IWeapon> weapons = new List<IWeapon>();
    protected HashSet<IWeapon> _weapons = new HashSet<IWeapon>();

    public void AddWeapon(IWeapon weapon)
    {
        _weapons.Add(weapon); // Добавляем орудие
    }

    public void RemoveWeapon(IWeapon weapon)
    {
        _weapons.Remove(weapon); //Убираем орудие
    }


    protected virtual void OnEnable() // Событие 
    {
        FindObjectOfType<PlayerInput>().Fired += OnFired; // Добавить в событие OnFired
    }
    /*
        private void OnDisable()  // Событие 
        {
            FindObjectOfType<PlayerInput>().Fired -= OnFired; // Убрать из событие OnFired
        }*/

    protected virtual void OnFired()
    {
        //Перебераем все орудия и по очереди запускаем у них интерфейс Огонь
        foreach (var weapon in _weapons)
        {
            weapon.Fire();
        }

    }
}


public class WeaponSystem : BaseWeaponSystem
{
   
}
