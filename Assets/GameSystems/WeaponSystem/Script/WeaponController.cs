using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QoallaInteractiveWeaponHelper;


public class WeaponController : MonoBehaviour
{
    WeaponHelper weaponHelper = new WeaponHelper();
    [SerializeField] private bool isEquip; public void setisEquip(bool isEquip) { this.isEquip = isEquip; }
    public bool getisEquip() { return this.isEquip; }



    /*
    public Transform spine;
    public Transform cam;
    public float aimingX = -65.93f;
    public float aimingY = 20.1f;
    public float aimingZ = 213.46f;
    public float point = 30;
    */




    //[SerializeField]
    //private STWeaponCharacter GetSTWeaponCharacter;
    [SerializeField]
    private STInput GetSTInput;
    [SerializeField]
    private PlayerController playerController;


    private void Start()
    {

    }
    private void Update()
    {
        weaponEquip();
        weaponUnequip();
    }

    void weaponEquip()
    {
        if (Input.GetKey(GetSTInput.EquipButton))
        {
            //playerController.setLocomotionStrafe();
            //playerController.setisweaponEquip(true);
            playerController.characterAnimator.SetBool("weaponEquip", true);
            //playerController.characterAnimator.SetLayerWeight(2,1); 



        }





    }

    void weaponUnequip()
    {
        if (Input.GetKey(KeyCode.H))
        {
            if (!playerController.getIsAim())
            {
                //playerController.setLocomotionDirectional();
                //playerController.setisweaponEquip(false);
                setisEquip(false);

                playerController.characterAnimator.SetBool("eventEquip", false);


                Invoke("invokeUnequip", .3f);

                //playerController.characterAnimator.SetLayerWeight(2, 0);
            }

        }
    }
    void invokeUnequip()
    {
        playerController.characterAnimator.SetBool("weaponEquip", false);
    }
    public void animeventEquip()
    {
        setisEquip(true);
        playerController.characterAnimator.SetBool("eventEquip", true);

    }


    

}
