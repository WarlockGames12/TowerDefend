using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanYouPlaceIt : MonoBehaviour
{
    public GameObject Turret;
    public bool Occupied()
    {
        if(Turret == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
