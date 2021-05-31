using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlanet : MonoBehaviour
{
    public GameObject _target;

    public GameObject _mercury;
    public GameObject _venus;
    public GameObject _earth;
    public GameObject _mars;
    public GameObject _jupiter;
    public GameObject _saturn;
    public GameObject _uranus;
    public GameObject _neptune;

    [SerializeField] private float _speedMercury = -1f;
    [SerializeField] private float _speedVenus   = -1f;
    [SerializeField] private float _speedEarth   = -1f;
    [SerializeField] private float _speedMars    = -1f;
    [SerializeField] private float _speedJupiter = -1f;
    [SerializeField] private float _speedSaturn  = -1f;
    [SerializeField] private float _speedUranus  = -1f;
    [SerializeField] private float _speedNeptune = -1f;


    private void Update()
    {
        RotationAroundSun();
    }

    private void RotationAroundSun()
    {
        _mercury.transform.RotateAround(_target.transform.position, Vector3.up, _speedMercury * Time.deltaTime);
        _venus.transform.RotateAround(_target.transform.position, Vector3.up, _speedVenus * Time.deltaTime);
        _earth.transform.RotateAround(_target.transform.position, Vector3.up, _speedEarth * Time.deltaTime);
        _mars.transform.RotateAround(_target.transform.position, Vector3.up, _speedMars * Time.deltaTime);
        _jupiter.transform.RotateAround(_target.transform.position, Vector3.up, _speedJupiter * Time.deltaTime);
        _saturn.transform.RotateAround(_target.transform.position, Vector3.up, _speedSaturn * Time.deltaTime);
        _uranus.transform.RotateAround(_target.transform.position, Vector3.up, _speedUranus * Time.deltaTime);
        _neptune.transform.RotateAround(_target.transform.position, Vector3.up, _speedNeptune * Time.deltaTime);
    }
}
