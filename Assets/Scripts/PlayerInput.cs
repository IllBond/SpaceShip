using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; } // Горизонтальный координат
    public float Vertical { get; private set; } // Вертикальный координат
    public Vector3 MousePosition { get; private set; } //Здесь позиция мышки

    private bool _isFire; // Переменная для проверки был ли клик 

    [SerializeField]
    private Camera _camera; // Здесь находится камера

    //События. Если на него поджпишутся то выполниться та функция которую передали через обработчик события или наоборот будет убрана эта функция
    public event Action Fired = default;

    private void Update() {
        _isFire = Input.GetMouseButton(0); // При клике левой кнопкой мышки возвращает true;

        Horizontal = Input.GetAxis("Horizontal"); // При влево вправо возвращает определеныне значения
        Vertical = Input.GetAxis("Vertical");// При вверх вниз возвращает определеныне значения
        MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition); // Обновленеи позиции мышки

        // Если нажали левой кнопкой мышки и если у события есть подписчики
        if (_isFire && Fired != null) {
            Fired(); // Срабатывает событие
        }
    }
}
