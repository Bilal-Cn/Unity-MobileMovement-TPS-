using UnityEngine;

namespace QoallaInteractiveCharacterHelper
{
    public class Character
    {
        //private variables
        private Vector3 forwadVector; public void setforwadVector(Vector3 forwad) { this.forwadVector = forwad; }
        public Vector3 getforwadVector() { return this.forwadVector; }
        //---------------------------------------
        private Vector3 rightVector; public void setrightVector(Vector3 right) { this.rightVector = right; }
        public Vector3 getrightVector() { return this.rightVector; }
        //---------------------------------------
        private Vector3 moveDirection;
        public void setmoveDirection(Vector3 moveDirection) { this.moveDirection = moveDirection; }
        //Overloading
        public void setmoveDirection(Vector3 vectorX, Vector3 vectorZ) { this.moveDirection = vectorX + vectorZ; }
        public Vector3 getmoveDirection() { return this.moveDirection; }
        //---------------------------------------




        private Vector3 movementInput; public void setmovementInput(Vector3 move) { this.movementInput = move; }
        public Vector3 getmovementInput() { return this.movementInput; }
        //---------------------------------------





        public enum MovementType
        {
            directional,
            strafe
        }
        public MovementType movementType;



        public void AddMovementInput(Transform cameraTransform, float Horizontalaxis, float Verticalaxis, float currentSpeed, Rigidbody rigidbody)
        {
            //set input
            //setmovementInput(new Vector3(Horizontalaxis, 0f, Verticalaxis) * speed);
            setmovementInput(new Vector3(Verticalaxis, 0f, Horizontalaxis));

            //set vectors
            setforwadVector(cameraTransform.transform.forward);
            setrightVector(cameraTransform.transform.right);

            //set vectors y axis = 0
            setforwadVector(new Vector3(getforwadVector().x, 0, getforwadVector().z));
            setrightVector(new Vector3(getrightVector().x, 0, getrightVector().z));

            getforwadVector().Normalize();
            getrightVector().Normalize();

            setmoveDirection(getrightVector() * movementInput.z, getforwadVector() * movementInput.x);

            //moving 
            rigidbody.velocity = new Vector3(getmoveDirection().x * currentSpeed, rigidbody.velocity.y, getmoveDirection().z * currentSpeed);

        }

        public bool isJump(Transform groundCheck, float checkDistance, LayerMask groundMask)
        {
            return Physics.CheckSphere(groundCheck.position, checkDistance, groundMask);
        }

        #region jump


        public void jumping(Rigidbody rigidbody, float jumpForce)
        {


            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);


        }





        #endregion


        public void directionalRotation(Transform characterTransform, float rotationSpeed)
        {
            if (moveDirection != Vector3.zero)
                characterTransform.forward = Vector3.Slerp(characterTransform.forward, moveDirection.normalized, Time.deltaTime * rotationSpeed);
        }

        public void strafeRotation(Transform characterTransform, float rotationSpeed, Transform cameraTransform)
        {
            float yawCamera = cameraTransform.rotation.eulerAngles.y;


            characterTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.Euler(0, yawCamera, 0), rotationSpeed);

            //characterTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, Quaternion.Euler(0, yawCamera, 0), rotationSpeed);
            //transform.rotation = Vector3.Slerp(transform.Rotate, new Vector3(0,0,0), rotationSpeed);
        }






        #region animationfunction



        public void animDirectional(Animator animator, float currentanimSpeed, float dampTime, float deltaTime)
        {
            animator.SetFloat("speed", currentanimSpeed, dampTime, Time.deltaTime * deltaTime);
        }
        public void animStrafe(Animator animator, float ix, float iz, float dampTime, float deltaTime, bool isStrafe)
        {
            animator.SetBool("isStrafe", isStrafe);
            animator.SetFloat("ix", ix, dampTime, Time.deltaTime * deltaTime);
            animator.SetFloat("iz", iz, dampTime, Time.deltaTime * deltaTime);
        }
        //overloading
        public void animStrafe(Animator animator, bool isStrafe)
        {
            animator.SetBool("isStrafe", isStrafe);
        }

        public void animJumpStart(Animator animator, bool jump)
        {
            animator.SetBool("jumpStart", jump);
        }

        public void animisAir(Animator animator, bool isAir)
        {
            animator.SetBool("isAir", isAir);
        }
        public void animjumpLand(Animator animator, bool isLand)
        {
            animator.SetBool("jumpLand", isLand);
        }
        public void animisAim(Animator animator, bool isAim)
        {
            animator.SetBool("isAim", isAim);
        }
    



        #endregion


       

    }




}