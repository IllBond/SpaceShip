using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    private Rigidbody2D _rbBullet; // ������ ����
    [SerializeField]
    private Transform _pointFire; // ����� ������ ��������
    [SerializeField]
    private float _fireForce; // ���� ������
    
    [SerializeField]
    private GameObject _bulletFlash; // ��� ����� �������
    [SerializeField]
    private float _flashDelay; // ����� ������������� �������
      
    [SerializeField]
    private float _fireRate; // ���� �������� 1 ��� � _fireRate ������
    private float _timer; // ����������� ������� ���� ������� ����� ������ _timer


    private void OnEnable() {
        //��� ������ ����� ������ ������������ �� �������� � WeaponSystem � ������ ������� ����� ������
        // FindObjectOfType<WeaponSystem>().AddWeapon(this);
       
        BaseWeaponSystem wp = GetComponentInChildren<BaseWeaponSystem>();
        
        if (wp==null)
        {
            wp = GetComponentInParent<BaseWeaponSystem>();
        }

        if (wp is WeaponSystem)
        {
            WeaponSystem weaponSystem = wp as WeaponSystem; // ���������� ���������� �� ������� ������� � ������
            weaponSystem.AddWeapon(this);
        }
        else if (wp is EnemyWeaponSystem)
        {
            EnemyWeaponSystem weaponSystem = wp as EnemyWeaponSystem; // ���������� ���������� �� ������� ������� � ������
            weaponSystem.AddWeapon(this);
        }
    }

    /*private void OnDisable() {
        //��� ������ ����� ����������� ������������ ������ ������ �� WeaponSystem
        FindObjectOfType<WeaponSystem>().RemoveWeapon(this);
    }*/


    // ������ true ���� ������� ����� ������ ������� ������������ ��� ��������
    public bool CanFire()
    {
        return Time.time > _timer;
    }


    // ������� ��������
    public void Fire()
    {
        if (CanFire()) //���� ���������� ����� �� 
        {
            _timer = Time.time + _fireRate; //����� ����� ����� ���������� � ���������� ��� �����������
            // ���� ��� ������� �� ���������
            if (_bulletFlash != null)
            {
                // ��������� �������� � ������� �� �������
                StartCoroutine(Flash(_flashDelay));
            }

            var bullet = Instantiate(_rbBullet, _pointFire.transform.position, _pointFire.rotation); //������� ����
            bullet.AddForce(bullet.transform.TransformDirection(new Vector2(0, 1) * _fireForce)); // ���������� ���� ���������
        }     
    }


 

    private IEnumerator Flash(float time)
    {
        _bulletFlash.SetActive(true); // ��� ������ �������� �������� ������� 
        yield return new WaitForSeconds(time); // ����� ��������� ���������� ������� ��������� �������
        _bulletFlash.SetActive(false);
    }

}
