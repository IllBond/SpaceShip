using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb; // �������, ��� Riggidody2d
    [SerializeField]
    private GameObject _engine; // ���������
    [SerializeField]
    private Transform _transforShip; // �������, ��� Transform

    private PlayerInput _playerInput; // ������ �� Input � ��� ������������� � ��������������� ������������

    [SerializeField]
    private float _force = 10f; // ���� ���������
    [SerializeField]
    private float _speedRotation = 2f; // ������� ���������

    private Vector2 _input; // ��������������� ���������� ��� �� ���������� Hor � Ver � 1 _input


    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>(); //��� ������ ������� ����������� ����� ����������  �� 
    }

    private void Update() 
    {
        TrackTarget();
    }

    private void FixedUpdate()
    {
        _input.x = _playerInput.Horizontal; // ������� ������������ � ��������������� ��������� 
        _input.y = _playerInput.Vertical;

        // ���� ������� ������������ ��: 
        if (_input != Vector2.zero)
        {
            //_rb.AddForce(input* _force); // ����������� ������������ ����
            _rb.AddForce(_transforShip.TransformDirection(_input * _force)); //  ����������� ������������ �������
            _engine.SetActive(true);
        }
        else
        {
            _rb.velocity = Vector2.Lerp(_rb.velocity, Vector2.zero, 0.1f); // ������� ��������� ��������
            _engine.SetActive(false);
        }
    }

    // ������� ������ �� �������� ����� � �������������� ������������ ����
    private void TrackTarget()
    {
        Vector2 direction = _playerInput.MousePosition - _transforShip.position; // ��������� ����� �� ������ - ������� ��������� �������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // ���� ������� �� ��������� � �����
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward); // ����� ����  ��������� ������� 
        _transforShip.rotation = Quaternion.Slerp(_transforShip.rotation, rotation, _speedRotation * Time.deltaTime); // ������� ����������� �������
    }


}
