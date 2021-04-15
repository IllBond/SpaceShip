using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; private set; } // �������������� ���������
    public float Vertical { get; private set; } // ������������ ���������
    public Vector3 MousePosition { get; private set; } //����� ������� �����

    private bool _isFire; // ���������� ��� �������� ��� �� ���� 

    [SerializeField]
    private Camera _camera; // ����� ��������� ������

    //�������. ���� �� ���� ����������� �� ����������� �� ������� ������� �������� ����� ���������� ������� ��� �������� ����� ������ ��� �������
    public event Action Fired = default;

    private void Update() {
        _isFire = Input.GetMouseButton(0); // ��� ����� ����� ������� ����� ���������� true;

        Horizontal = Input.GetAxis("Horizontal"); // ��� ����� ������ ���������� ������������ ��������
        Vertical = Input.GetAxis("Vertical");// ��� ����� ���� ���������� ������������ ��������
        MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition); // ���������� ������� �����

        // ���� ������ ����� ������� ����� � ���� � ������� ���� ����������
        if (_isFire && Fired != null) {
            Fired(); // ����������� �������
        }
    }
}
