using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHealth : MonoBehaviour, IDamageable
{
    public float Health { get; set; }

    [SerializeField] private GameObject PrefabEffectsDest;

    [SerializeField] private GameObject PrefabAsteroidDivision;

    public bool Destroued = false;
    public int DivisionCounter = 2;


    public void ReceivedDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
    {
        Health -= damageAmount;
        if (Health <= 0 && !Destroued)
        {
            if(PrefabEffectsDest)
            {
                Instantiate(PrefabEffectsDest, transform.position, Quaternion.identity);
            }

            if(PrefabAsteroidDivision != null && DivisionCounter > 0)
            {
                Vector3 Shard1Pos = new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f),
                                                transform.position.y + Random.Range(-0.3f, 0.3f),
                                                transform.position.z + Random.Range(-0.3f, 0.3f));
                Vector3 Shard2Pos = new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f),
                                                transform.position.y + Random.Range(-0.3f, 0.3f),
                                                transform.position.z + Random.Range(-0.3f, 0.3f));

                var s1 = Instantiate(PrefabAsteroidDivision, Shard1Pos + PrefabAsteroidDivision.transform.localScale, Quaternion.identity);
                var s2 = Instantiate(PrefabAsteroidDivision, Shard2Pos - PrefabAsteroidDivision.transform.localScale, Quaternion.identity);

                s1.GetComponent<AsteroidHealth>().DivisionCounter = DivisionCounter--;
                s2.GetComponent<AsteroidHealth>().DivisionCounter = DivisionCounter--;
            }

            ManagerScore.OnAddScore(1);
            
            Destroued = true;
            Destroy(gameObject);
        }
    }

    public void ReceivedHeal(float healAmount, Vector3 hitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }

}
