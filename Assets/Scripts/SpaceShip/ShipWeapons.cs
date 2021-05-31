using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public SpaceShip _SpaceShip;

    public List<IWeapon> Weapons = new List<IWeapon>();

    [SerializeField] private float _maxDistansceToTarget = 250f;

    private void Awake()
    {
        if (_SpaceShip == null)
        {
            _SpaceShip = GetComponentInParent<SpaceShip>();
        }
        Weapons = GetComponentsInChildren<IWeapon>().ToList();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireWeapons();
        }

    }

    public void FireWeapons()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if(Physics.Raycast(ray, out hit, _maxDistansceToTarget))
        {
            foreach(var weapon in Weapons)
            {
                weapon.FireWeapon(hit.point);
            }
        }
        else
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(ray.origin + ray.direction * _maxDistansceToTarget);
            }
        }
    }
}
