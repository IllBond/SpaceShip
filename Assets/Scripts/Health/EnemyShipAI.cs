using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShipAI : MonoBehaviour, IPatrollingAI, ITargeterAI, IRotationAI
{
    public event Action Fired = default;

    [SerializeField]
    private int _speed = 1;    
    
    [SerializeField]
    private float _shootDistance = 10f;

    [SerializeField]
    private List<Transform> _wellPoint = new List<Transform>();
    private Transform _currentWellPoint;

    private Transform _ship;
    private Transform _target;



    private void Update() {
        Patrolling();
    }

    private void Awake() {
        _ship = GetComponent<Transform>();
    }

    public void Patrolling() {
        if (_currentWellPoint != null)
        {
            RotationToTarget(_currentWellPoint);

            Vector3 direction = _currentWellPoint.position - _ship.position;
            _ship.position = _ship.position + direction.normalized * Time.deltaTime * _speed;

            if (direction.magnitude < 0.1f)
            {
                _currentWellPoint = null;
            }
        }
        else {
            if (IsTargetFound()) {
                
                MoveToTarget();

                if (CanFire()) {
                    
                    Fire();
                }
            } else { 
            _currentWellPoint = _wellPoint[Random.Range(0, _wellPoint.Count - 1)];
            }
        }
    }

    public void RotationToTarget(Transform target) {
        Vector2 direction = target.position - _ship.position; // Координат мышки на экране - текущий координат корабля
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Угол корабля по отношению к мышке
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // Новый угол  поворотка коробля 
        _ship.rotation = Quaternion.Slerp(_ship.rotation, rotation, 3f * Time.deltaTime); // Плавное перемещение корабля
    }
    
    public bool IsTargetFound() {
        return _target;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Character target = collision.gameObject.GetComponentInChildren<Character>();
        if (target is PlayerCharacter)
        {
            _target = target.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Character target = collision.gameObject.GetComponentInChildren<Character>();
        if (target is PlayerCharacter)
        {
            _target = null;
        }
    }


    public void MoveToTarget() {
        RotationToTarget(_target);
        Vector3 direction = _target.position - _ship.position;
       

        if (direction.magnitude > _shootDistance/2)
        {
            _ship.position = _ship.position + direction.normalized * Time.deltaTime * _speed;
        }
    }
    
    public bool CanFire() {
           return (_target.position - _ship.position).magnitude < _shootDistance;
    }    
    
    public void Fire() {
        if (Fired != null)
        {
            Fired();
        }
    }


}
