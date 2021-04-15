using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//������ ����� ���������� �� ����

public enum TypeProjectTile
{ 
    Bullet = 1,
    Laser = 3,
    Missile = 12
}

public class ProjectTile : MonoBehaviour
{

    [SerializeField]
    private TypeProjectTile _typeProjectTile;

    [SerializeField]
    private float _damage;

    private void Awake()
    {
        if (_damage<=0) {
            _damage = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    //private void OnTriggerEnter2D(Collider2D collision)
    {
        Character target = collision.gameObject.GetComponentInChildren<Character>(); // ���� ��������� ������ ���� ������ ����� null
        //Character target = collision.gameObject.GetComponentInChildren<Character>(); // ���� ��������� ������ ���� ������ ����� null

        if (target != null)
        {

            /*
            // �������� ������ �� ������������� � ����� ������
            if (target is EnemyShipCharacter) {
                target.TakeDamage(_damage);
            } else if (target is EnemyTowerCharacter) {
                target.TakeDamage(_damage*10);
            }*/

            target.TakeDamage(Calculate.CalculateDamage(_damage, _typeProjectTile, target.GetArmorType()));

            
        }
        Destroy(gameObject);
    }
}
