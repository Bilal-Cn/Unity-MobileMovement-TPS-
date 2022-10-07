using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QoallaInteractiveCharacterHelper;

public class PlayerController : MonoBehaviour
{
    //new characterhelper
    Character getCharacter = new Character();

    //get scriptable character
    [Header("Character Scriptable Setting")]
    [SerializeField] private STCharacterHelper GetSTCharacterHelper;
    //get scriptable input
    [SerializeField] private STInput GetSTInput;
    [Header("Character Get Component")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private AimController aimController;
    [SerializeField] private WeaponController weaponController;



    #region Get Component
    [Header("Character Component")]
    [SerializeField] private Rigidbody chrigidbody;
    [SerializeField] private Transform cameraTransform;
    public Animator characterAnimator;

    [Header("Character Jump Component")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    #endregion



    //movement
    private float currentSpeed; public void setcurrentSpeed(float currentSpeed) { this.currentSpeed = currentSpeed; }
    public float getcurrentSpeed() { return this.currentSpeed; }
    //---------------------------------------
    private float walkSpeed; public void setwalkSpeed(float walkSpeed) { this.walkSpeed = walkSpeed; }
    public float getwalkSpeed() { return this.walkSpeed; }
    //---------------------------------------
    private float runSpeed; public void setrunSpeed(float runSpeed) { this.runSpeed = runSpeed; }
    public float getrunSpeed() { return this.runSpeed; }
    //---------------------------------------
    private float strafeSpeed; public void setstrafeSpeed(float strafeSpeed) { this.strafeSpeed = strafeSpeed; }
    public float getstrafeSpeed() { return this.strafeSpeed; }
    //---------------------------------------
    private float rotationSpeed; public void setrotationSpeed(float rotationSpeed) { this.rotationSpeed = rotationSpeed; }
    public float getrotationSpeed() { return this.rotationSpeed; }
    //---------------------------------------
    private bool IsSprint; public void setIsSprint(bool IsSprint) { this.IsSprint = IsSprint; }
    public bool getIsSprint() { return this.IsSprint; }
    //---------------------------------------
    private bool IsAim; public void setIsAim(bool IsAim) { this.IsAim = IsAim; }
    public bool getIsAim() { return this.IsAim; }



    //Animaton
    private float dampTime; public void setdampTime(float dampTime) { this.dampTime = dampTime; }
    public float getdampTime() { return this.dampTime; }
    //---------------------------------------
    private float deltaTime; public void setdeltaTime(float deltaTime) { this.deltaTime = deltaTime; }
    public float getdeltaTime() { return this.deltaTime; }
    //---------------------------------------
    private float currentanimSpeed; public void setcurrentanimSpeed(float currentanimSpeed) { this.currentanimSpeed = currentanimSpeed; }
    public float getcurrentanimSpeed() { return this.currentanimSpeed; }
    //---------------------------------------
    private float walkanimSpeed; public void setwalkanimSpeed(float walkanimSpeed) { this.walkanimSpeed = walkanimSpeed; }
    public float getwalkanimSpeed() { return this.walkanimSpeed; }
    //---------------------------------------
    private float runanimSpeed; public void setrunanimSpeed(float runanimSpeed) { this.runanimSpeed = runanimSpeed; }
    public float getrunanimSpeed() { return this.runanimSpeed; }



    //movement type
    private bool isStrafe; public void setisStrafe(bool isStrafe) { this.isStrafe = isStrafe; }
    public bool getisStrafe() { return this.isStrafe; }




    //jump
    private float jumpForce; public void setjumpForce(float jumpForce) { this.jumpForce = jumpForce; }
    public float getjumpForce() { return this.jumpForce; }
    //---------------------------------------
    private float checkDistance; public void setcheckDistance(float checkDistance) { this.checkDistance = checkDistance; }
    public float getcheckDistance() { return this.checkDistance; }
    //---------------------------------------

    /*
    private bool canJump; public void setcanJump(bool canJump) { this.canJump = canJump; }
    public bool getcanJump() { return this.canJump; }
    */


    //---------------------------------------

    //---------------------------------------



    #region initialize
    void initialize()
    {


        setwalkanimSpeed(.2f);
        setrunanimSpeed(1);
        setcurrentanimSpeed(getwalkanimSpeed());
        setcurrentSpeed(GetSTCharacterHelper.WalkSpeed);



        setwalkSpeed(GetSTCharacterHelper.WalkSpeed);
        setrunSpeed(GetSTCharacterHelper.RunSpeed);
        setstrafeSpeed(GetSTCharacterHelper.StrafeWalkSpeed);
        setrotationSpeed(GetSTCharacterHelper.RotationSpeed);
        setjumpForce(GetSTCharacterHelper.JumpForce);
        setcheckDistance(GetSTCharacterHelper.GroundCheckDistance);
        setdampTime(GetSTCharacterHelper.DampTime);
        setdeltaTime(GetSTCharacterHelper.DeltaTime);


    }
    #endregion
    private void OnEnable()
    {



    }

    private void Awake()
    {

    }
    private void Start()
    {
        //normalde startta çalýþýyor ama test için  update yazýcam unutma sakýn :))))
        //initialize();
    }
    void notMove()
    {
        setcurrentSpeed(0);
        setcurrentanimSpeed(0);
        if (getIsAim())
        {

            setisStrafe(false);

            getCharacter.animStrafe(characterAnimator, getisStrafe());
            getCharacter.animisAim(characterAnimator, getIsAim());

            getCharacter.movementType = Character.MovementType.strafe;



        }
        else
        {
            setisStrafe(false);
            aimController.aimCont = false;

            //getCharacter.animDirectional(characterAnimator, getcurrentanimSpeed(), getdampTime(), getdeltaTime());
            getCharacter.animStrafe(characterAnimator, getisStrafe());
            getCharacter.animisAim(characterAnimator, getIsAim());

            getCharacter.movementType = Character.MovementType.directional;


        }
        getCharacter.animDirectional(characterAnimator, getcurrentanimSpeed(), getdampTime(), getdeltaTime());


    }
    void moving()
    {
        if (Input.GetKey(GetSTInput.SprintButton))
        {
            setIsSprint(true);
            setcurrentSpeed(getrunSpeed());
            setcurrentanimSpeed(getrunanimSpeed());
            getCharacter.animDirectional(characterAnimator, getcurrentanimSpeed(), getdampTime(), getdeltaTime());
        }
        else
        {
            setIsSprint(false);
            setcurrentanimSpeed(getwalkanimSpeed());
            setcurrentSpeed(getwalkSpeed());
            getCharacter.animDirectional(characterAnimator, getcurrentanimSpeed(), getdampTime(), getdeltaTime());

        }
    }
    void strafeEnable()
    {
        setisStrafe(true);
        getCharacter.movementType = Character.MovementType.strafe;

        setcurrentSpeed(getstrafeSpeed());

        getCharacter.animisAim(characterAnimator, getIsAim());
        getCharacter.animStrafe(characterAnimator, getCharacter.getmovementInput().x, getCharacter.getmovementInput().z, getdampTime(), getdeltaTime(), getisStrafe());



    }



    void strafeDisable()
    {
        setisStrafe(false);
        getCharacter.movementType = Character.MovementType.directional;
        getCharacter.animisAim(characterAnimator, getIsAim());
        getCharacter.animStrafe(characterAnimator, getisStrafe());
        aimController.aimCont = false;

    }

    IEnumerator startAim()
    {
        yield return new WaitForSeconds(.2f);
        aimController.aimCont = true;

    }
    private void Update()
    {
        //Debug.Log(getCharacter.movementType);

        initialize();
        if (getIsAim())
        {



            cameraController.currentcamDist = cameraController.AimcamDist;



            if (weaponController.getisEquip())
            {

                //aimController.aimCont = true;

                StartCoroutine(startAim());
            }
        }
        else
        {
            cameraController.currentcamDist = cameraController.camDist;

        }



        #region statefunction 
        if (getCharacter.getmovementInput().x == 0 && getCharacter.getmovementInput().z == 0)
        {

            characterAnimator.SetBool("idle", true);
            notMove();
            
        }
        else
        {
            characterAnimator.SetBool("idle", false);

            if (getIsAim())
            {
                strafeEnable();
                //StartCoroutine(startAim());


            }

            else
            {
                strafeDisable();
                moving();
            }
        }
        #endregion



        /*
        if (Input.GetMouseButton(1))
        {
            getCharacter.movementType = Character.MovementType.strafe;

        }
        else
        {

            getCharacter.movementType = Character.MovementType.directional;
        }
        */

        #region set moving
        getCharacter.AddMovementInput(cameraTransform, Input.GetAxis(GetSTInput.AxisHorizontal), Input.GetAxis(GetSTInput.AxisVertical), getcurrentSpeed(), chrigidbody);
        #endregion



        #region is jumping
        //getCharacter.isJump(groundCheck, getcheckDistance(), groundMask);
        bool jmp = true;


        //Debug.Log(jmp);

        if (getCharacter.isJump(groundCheck, getcheckDistance(), groundMask) && Input.GetKey(GetSTInput.JumpButton))
        {
            if (jmp)
            {
                getCharacter.jumping(chrigidbody, getjumpForce());
                getCharacter.animJumpStart(characterAnimator, true);
                StartCoroutine(jmpfal());

            }

        }


        getCharacter.animisAir(characterAnimator, !getCharacter.isJump(groundCheck, getcheckDistance(), groundMask));
        getCharacter.animjumpLand(characterAnimator, getCharacter.isJump(groundCheck, getcheckDistance(), groundMask));
        getCharacter.animJumpStart(characterAnimator, false);


        /*
        if(!getCharacter.isJump(groundCheck, getcheckDistance(), groundMask))
        {
        }*/
        IEnumerator jmpfal()
        {
            yield return new WaitForSeconds(1);
            jmp = false;
            StartCoroutine(jmpfalll());
        }

        IEnumerator jmpfalll()
        {
            yield return new WaitForSeconds(20);
            jmp = true;
        }
        #endregion


        #region rotationmovement
        if (getisStrafe() || getIsAim())
        {
            getCharacter.strafeRotation(this.transform, getrotationSpeed(), cameraTransform);
        }
        else
        {
            getCharacter.directionalRotation(this.transform, getrotationSpeed());

        }
        #endregion


        #region SetaimCameraPosition
        cameraAimPosition();
        #endregion




    }

    void cameraAimPosition()
    {
        /*
        if (getIsAim())
        {
            Vector3 a = new Vector3(0.7f, 0, -1.2f);
            cameraController.camDist=Vector3.Slerp(cameraController.camDist, a, 2);
            cameraController.zoomDistance = a.z;
        }*/

    }


    public void setLocomotionStrafe()
    {
        getCharacter.movementType = Character.MovementType.strafe;
    }
    public void setLocomotionDirectional()
    {
        getCharacter.movementType = Character.MovementType.directional;
    }

}

