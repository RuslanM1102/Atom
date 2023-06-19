using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDist = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    private void OnUse()
    {
        if (Physics.Raycast(Camera.position, Camera.forward, out RaycastHit hit, MaxUseDist, UseLayers))
        {
            if (hit.collider.TryGetComponent<DoorScript>(out DoorScript door))
            {
                    if (door.isOpen)
                    {
                        door.Close();
                    }
                    else
                    {
                        door.Open(transform.position);
                    }
            }
        }
    }
}
