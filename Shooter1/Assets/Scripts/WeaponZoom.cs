using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
     Animator anim;
    [SerializeField] Camera fpsCamera;
    [SerializeField]RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedInFOV=20f;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInSensitivity = 0.5f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    bool zoomedInToggle = false;



    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {

                zoomedInToggle = true;
                anim.SetBool("Scope", true);
                FindObjectOfType<WeaponSwitcher>().enabled = false;
            }
            else
            {
                zoomedInToggle = false;
                anim.SetBool("Scope", false);
                FindObjectOfType<WeaponSwitcher>().enabled = true;
            }
        }

    }

}
