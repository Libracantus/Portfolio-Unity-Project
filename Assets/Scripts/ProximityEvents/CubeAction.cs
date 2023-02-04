using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ProximityEvent/CubeAction")]
public class CubeAction : ProximityEvent
{
    public override void Activate(GameObject self, GameObject target)
    {
        Debug.Log("Cube does stuff");
    }
    public override void Deactivate(GameObject self, GameObject target)
    {
        Debug.Log("Cube Stops doing stuff");
    }
}
