using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // Start is called before the first frame update
    

    [SerializeField] AmmoSlot[] ammoslots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceAmmoAmount(AmmoType ammoType)
    {
         GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseAmmoAmount(AmmoType ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount+= ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoslots)
        {
            if(slot.ammoType==ammoType)
            {
                return slot;
            }
        }
        return null;

      
    }
}
