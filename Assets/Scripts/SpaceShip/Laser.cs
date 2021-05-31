using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kosmos
{
    [RequireComponent(typeof(LineRenderer))]
    public class Laser : MonoBehaviour, IWeapon
    {
        private ShipWeapons _ShipWeapons;

        public bool CanFire;

        [SerializeField] private float _maxDistance = 100f;
        [SerializeField] private float _damageAmount = 5f;
        [SerializeField] private float waitTimeFiring = 0.1f;

        [Header("Links")]
        [SerializeField] private LineRenderer _lineRenderer;

        private Coroutine _coroutineFiring;
        private WaitForSeconds waitForFiring;

        public List<IDamageable> TargetsHit = new List<IDamageable>();


        private void Awake()
        {
            if (_ShipWeapons == null)
            {
                _ShipWeapons = GetComponentInParent<ShipWeapons>();
            }

            if (_lineRenderer == null)
            {
                _lineRenderer = GetComponent<LineRenderer>();
            }
        }

        private void Start()
        {
            waitForFiring = new WaitForSeconds(waitTimeFiring);

            _lineRenderer.enabled = false;
            CanFire = true;
        }

        public Vector3 FireWeapon(Vector3 targetPosition)
        {
            RaycastHit hitInfo;
            var direction = targetPosition - transform.position;
            if(Physics.Raycast(transform.position, direction, out hitInfo, _maxDistance))
            {
                var targetHit = hitInfo.transform;
                if(targetHit != null)
                {
                    Debug.Log($"FireWeapon. targetHit: {targetHit.name}");
                    var damageableHit = targetHit.GetComponent<IDamageable>();
                    if (damageableHit != null)
                    {
                        TargetsHit.Add(damageableHit);
                        Damage(_damageAmount, targetHit.position, _ShipWeapons._SpaceShip.ShipAgent);
                    }
                    VizualizeFiring(targetHit.position);


                    return targetHit.position;
                }
            }
            VizualizeFiring(transform.position + direction.normalized * _maxDistance);
            return targetPosition;
        }

        public void Damage(float damageAmount, Vector3 targetHitPosition, GameAgent sender)
        {
            foreach(var targetHit in TargetsHit)
            {
                targetHit.ReceivedDamage(damageAmount, targetHitPosition, sender);
            }
            TargetsHit.Clear();
        }

        public void VizualizeFiring(Vector3 targetPosition)
        {
            if (CanFire)
            {
                _lineRenderer.enabled = true;
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, targetPosition);

                CanFire = false;
            }

            _coroutineFiring = StartCoroutine(FiringCor());
        }

        private IEnumerator FiringCor()
        {
            yield return waitForFiring;

            CanFire = true;
            _lineRenderer.enabled = false;
        }
    }
}