
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Android;

public class BluetoothPermissionScript : MonoBehaviour
{

    // Check if we have Bluetooth permission
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            // Ask for Bluetooth permission
            Permission.RequestUserPermission(Permission.FineLocation);
        }
    }
}
