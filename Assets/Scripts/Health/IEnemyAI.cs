using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public interface IEnemyAI
{ 
    void Patrolling(); //��������������
    void RotationToTarget(Transform target); // �������� � �����
    bool IsTargetFound(); // ���� �� ����� ����
    void MoveToTarget(); // �������� � ����
    bool CanFire(); //����� ��������?
    void Fire();//��������
}*/

public interface IPatrollingAI
{ 
    void Patrolling(); //��������������
    void MoveToTarget(); // �������� � ���� 
}

public interface ITargeterAI
{
    bool IsTargetFound(); // ���� �� ����� ����
    bool CanFire(); //����� ��������?
    void Fire();//��������
}

public interface IRotationAI
{
    void RotationToTarget(Transform target); // �������� � �����
}
