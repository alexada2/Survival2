using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    private int currentWeaponIndex;
    private Weapon currentWeapon;
    [SerializeField] private Transform rTargetPosition;
    [SerializeField] private Transform rHintPosition;
    [SerializeField] private List<Weapon> weapons;
    void Update()
    {
        if (Input.anyKey)
        {
            bool changeINDX = true;
            int toint = currentWeaponIndex;
            bool result = int.TryParse(Input.inputString, out toint);
            if (toint == 0 || toint > weapons.Count)
            {
                changeINDX = false;
            }
            if (changeINDX)
            {
                weapons[currentWeaponIndex].gameObject.SetActive(false);
                currentWeaponIndex = toint - 1;
                weapons[currentWeaponIndex].gameObject.SetActive(true);
                weapons[currentWeaponIndex].Pose(rTargetPosition, rHintPosition);
            }
        }
    }
}
