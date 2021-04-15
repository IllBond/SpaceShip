using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private Rigidbody2D _rbBullet; // Префаб пули
    [SerializeField]
    private Transform _pointFire; // Точка откуда стрелять
    [SerializeField]
    private float _fireForce; // Сила полета
    
    [SerializeField]
    private GameObject _bulletFlash; // Где нужна вспышка
    [SerializeField]
    private float _flashDelay; // Время существования вспышки
      
    [SerializeField]
    private float _fireRate; // Темп стрельбы 1 раз в _fireRate секунд
    private float _timer; // Производить выстрел если текущее время больше _timer


    private void OnEnable() {
        //Как только класс начнет существовать он передаст в WeaponSystem и станет орудием этого класса
        // FindObjectOfType<WeaponSystem>().AddWeapon(this);
       
        BaseWeaponSystem wp = GetComponentInChildren<BaseWeaponSystem>();
        
        if (wp==null)
        {
            wp = GetComponentInParent<BaseWeaponSystem>();
        }

        if (wp is WeaponSystem)
        {
            WeaponSystem weaponSystem = wp as WeaponSystem; // Нисходяшее приведение из высшего порядка в нисший
            weaponSystem.AddWeapon(this);
        }
        else if (wp is EnemyWeaponSystem)
        {
            EnemyWeaponSystem weaponSystem = wp as EnemyWeaponSystem; // Нисходяшее приведение из высшего порядка в нисший
            weaponSystem.AddWeapon(this);
        }
    }

    /*private void OnDisable() {
        //Как только класс отключиться существовать уберет орудие из WeaponSystem
        FindObjectOfType<WeaponSystem>().RemoveWeapon(this);
    }*/


    // Вернет true если текущее время больше времени необходисого для выстрела
    public bool CanFire()
    {
        return Time.time > _timer;
    }


    // Функция выстрела
    public void Fire()
    {
        if (CanFire()) //Если выстрелить можно то 
        {
            _timer = Time.time + _fireRate; //Время когда можно выстрелеть в следующзий раз увеличиться
            // Если нет вспышки не сработает
            if (_bulletFlash != null)
            {
                // Запускаем куратину и говорим на сколько
                StartCoroutine(Flash(_flashDelay));
            }

            var bullet = Instantiate(_rbBullet, _pointFire.transform.position, _pointFire.rotation); //Создаем пулю
            bullet.AddForce(bullet.transform.TransformDirection(new Vector2(0, 1) * _fireForce)); // Добавляеем пуле ускорение
        }     
    }


 

    private IEnumerator Flash(float time)
    {
        _bulletFlash.SetActive(true); // При старте куратины Включаем вспышку 
        yield return new WaitForSeconds(time); // Через указанный промежуток времени отключаем вспышку
        _bulletFlash.SetActive(false);
    }

}
