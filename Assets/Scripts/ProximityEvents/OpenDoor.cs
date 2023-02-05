using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ProximityEvent/OpenDoor")]
public class OpenDoor : ProximityEvent
{
    public override void Activate(GameObject self, GameObject target)
    {
        self.GetComponentInParent<Animator>().SetBool("isOpen", true);
    }

    public override void Deactivate(GameObject self, GameObject target)
    {
        self.GetComponentInParent<Animator>().SetBool("isOpen", false);
    }
}
