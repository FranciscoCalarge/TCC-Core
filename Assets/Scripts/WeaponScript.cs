using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    private float _projectileInterval = .5f;
    private float _weaponCD = 1.5f;
    private float _initialWeaponCD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialWeaponCD = _weaponCD;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _weaponCD -= Time.deltaTime;
            if (_weaponCD < 0)
            {
                _weaponCD += _projectileInterval;
                GameObject aux =  Instantiate(BulletPrefab,transform.position, transform.localRotation);
                aux.GetComponent<Rigidbody>().linearVelocity = transform.forward*10;

            }
        }
        else
        {
            _weaponCD = _initialWeaponCD;
        }
    }
}