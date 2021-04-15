using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb; // Корабль, его Riggidody2d
    [SerializeField]
    private GameObject _engine; // Двигатель
    [SerializeField]
    private Transform _transforShip; // Корабль, его Transform

    private PlayerInput _playerInput; // Данные из Input с его вартикальными и горизонтальными координатами

    [SerializeField]
    private float _force = 10f; // Сила ускорения
    [SerializeField]
    private float _speedRotation = 2f; // Скорось разворота

    private Vector2 _input; // Вспомогательная переменная что бы обьеденить Hor и Ver в 1 _input


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>(); //Как только функция просыпается берем координаты  из 
    }

    private void Update() 
    {
        TrackTarget();
    }

    private void FixedUpdate()
    {
        _input.x = _playerInput.Horizontal; // Достаем вертикальные и горизионтальные параметры 
        _input.y = _playerInput.Vertical;

        // Если корабль перемещается то: 
        if (_input != Vector2.zero)
        {
            //_rb.AddForce(input* _force); // Перемещение относительно мира
            _rb.AddForce(_transforShip.TransformDirection(_input * _force)); //  Перемещение относительно корабля
            _engine.SetActive(true);
        }
        else
        {
            _rb.velocity = Vector2.Lerp(_rb.velocity, Vector2.zero, 0.1f); // плавная остановка движения
            _engine.SetActive(false);
        }
    }

    // Функция следит за курсором мышки и поворачивается относительно него
    private void TrackTarget()
    {
        Vector2 direction = _playerInput.MousePosition - _transforShip.position; // Координат мышки на экране - текущий координат корабля
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Угол корабля по отношению к мышке
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Новый угол  поворотка коробля 
        _transforShip.rotation = Quaternion.Slerp(_transforShip.rotation, rotation, _speedRotation * Time.deltaTime); // Плавное перемещение корабля
    }


}
