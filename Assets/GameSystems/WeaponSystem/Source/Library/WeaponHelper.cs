using UnityEngine;


namespace QoallaInteractiveWeaponHelper
{

    public class WeaponHelper 
    {








        /*
        public void weaponEquip(PlayerController controller)
        {
            controller.setisweaponEquip(true);
        }
        */




        #region characterSetanimation

        public void setEquipanim(Animator anim,bool boolean)
        {
            anim.SetBool("weaponEquip", boolean);
        }
        



        #endregion





    }

}
