using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public interface IEnemyAI
{ 
    void Patrolling(); //Патрулирование
    void RotationToTarget(Transform target); // Разворот в точке
    bool IsTargetFound(); // Есть ли рядом враг
    void MoveToTarget(); // Движение к цели
    bool CanFire(); //Может стрелять?
    void Fire();//Стрелять
}*/

public interface IPatrollingAI
{ 
    void Patrolling(); //Патрулирование
    void MoveToTarget(); // Движение к цели 
}

public interface ITargeterAI
{
    bool IsTargetFound(); // Есть ли рядом враг
    bool CanFire(); //Может стрелять?
    void Fire();//Стрелять
}

public interface IRotationAI
{
    void RotationToTarget(Transform target); // Разворот в точке
}
