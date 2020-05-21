using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SquadManager : MonoBehaviour
{
    public List<BattleMember> squad;

    public void AddBattleMember(BattleMember unit)
    {
        squad.Add(unit);
    }
    public void RemoveBattleMember(BattleMember unit) 
    {
        squad.Remove(unit);
    }
    private void Update()
    {
            
    }
}
