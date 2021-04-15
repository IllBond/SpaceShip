using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerAI : MonoBehaviour,  ITargeterAI, IRotationAI
{

    public event Action Fired = default;

    private Transform _target;
    private Transform _tower;

    [SerializeField]
    private float _shootDistance = 10f;

    private void Update() {

        if (IsTargetFound())
        {
            RotationToTarget(_target);
            if (CanFire())
            {
                Fire();
            }
        }
    }

    private void Awake() {
        _tower = GetComponent<Transform>();
    }


    public void RotationToTarget(Transform target) {

        Vector2 direction = target.position - _tower.position; // Координат мышки на экране - текущий координат корабля
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Угол корабля по отношению к мышке
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Новый угол  поворотка коробля 
        _tower.rotation = Quaternion.Slerp(_tower.rotation, rotation, 3f * Time.deltaTime); // Плавное перемещение корабля

    }
    
    public bool IsTargetFound() {
        return _target;
    }
     
    public void OnTriggerEnter2D(Collider2D collision) {
        Character target = collision.gameObject.GetComponentInChildren<Character>();
        if (target is PlayerCharacter) {
            _target = target.transform;
        }
    }     

    public void OnTriggerExit2D(Collider2D collision) {
        Character target = collision.gameObject.GetComponentInChildren<Character>();
        if (target is PlayerCharacter) {
            _target = null;
        }
    }


    
    public bool CanFire() {
        return (_target.position - _tower.position).magnitude < _shootDistance; //&&  Time.time > _timer;
    }

    public void Fire() {

        if (Fired!=null) {
            Fired();
        }
    }
}
