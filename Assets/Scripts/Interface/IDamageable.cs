using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Health { get; }

    void ReceivedDamage(float damageAmount, Vector3 hitPosition, GameAgent sender);

    void ReceivedHeal(float healAmount, Vector3 hitPosition, GameAgent sender);
}
