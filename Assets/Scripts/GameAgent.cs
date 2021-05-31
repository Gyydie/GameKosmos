using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAgent : MonoBehaviour
{
    public enum Faction
    {
        Player,
        Allies,
        Empire
    }

    public Faction ShipFaction;
}
