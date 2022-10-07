using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HumanBone
{
    public HumanBodyBones bone;
    public float weight = 1.0f;
}

public class AimController : MonoBehaviour
{

    /*
    public Vector3 aimPivotOffset = new Vector3(0.5f, 1.2f, 0f);         // Offset to repoint the camera when aiming.
    public Vector3 aimCamOffset = new Vector3(0f, 0.4f, -0.7f);         // Offset to relocate the camera when aiming.
    */
    public bool aimCont;

    public Transform debugtransform;
    public Transform targetTransform;
    public Transform aimTransform;


    public int iterations = 10;

    [Range(0, 1)]
    public float weight = 1;

    public float angleLimit = 90f;
    public float distaneLimit = 1.5f;



    public HumanBone[] humanBones;
    Transform[] boneTransforms;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {


        animator = GetComponent<Animator>();
        boneTransforms = new Transform[humanBones.Length];
        for (int i = 0; i < humanBones.Length; i++)
        {
            boneTransforms[i] = animator.GetBoneTransform(humanBones[i].bone);
        }

    }
    // Update is called once per frame
    void Update()
    {


        if (aimCont)
        {
            animator.SetLayerWeight(0, 0);
            targetAim();

            if (aimTransform == null)
            {
                return;
            }
            if (targetTransform == null)
            {
                return;
            }



            Vector3 targetPosition = gettargetposition();

            for (int i = 0; i < iterations; i++)
            {
                for (int b = 0; b < boneTransforms.Length; b++)
                {
                    Transform bone = boneTransforms[b];
                    float boneWight = humanBones[b].weight * weight;
                    aimatTarget(bone, targetPosition, boneWight);
                }
            }
        }

        

    }


    void aimatTarget(Transform bone, Vector3 targetPos, float weight)
    {
        Vector3 aimDirection = aimTransform.forward;
        Vector3 targetDirection = targetPos - aimTransform.position;
        Quaternion aimTowards = Quaternion.FromToRotation(aimDirection, targetDirection);
        Quaternion blendedRotation = Quaternion.Slerp(Quaternion.identity, aimTowards, weight);

        //bone.rotation = Quaternion.Slerp(blendedRotation * bone.rotation,aimTowards,weight);

        bone.rotation =  blendedRotation * bone.rotation;
        //Debug.Log(bone.rotation);

    }

    Vector3 gettargetposition()
    {
        Vector3 targetDirection = targetTransform.position - aimTransform.position;
        Vector3 aimDirection = aimTransform.forward;

        float blendOut = 0f;

        float targetAngle = Vector3.Angle(targetDirection, aimDirection);
        if (targetAngle > angleLimit)
        {
            blendOut += (targetAngle - angleLimit) / 50.0f;

        }

        float targetDistance = targetDirection.magnitude;
        if (targetDistance < distaneLimit)
        {
            blendOut += distaneLimit - targetDistance;
        }


        Vector3 direction = Vector3.Slerp(targetDirection, aimDirection, blendOut);
        return aimTransform.position + direction;
    }

    void targetAim()
    {
        Ray lookatray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        debugtransform.position = lookatray.GetPoint(30);
    }

    public void settargetTransform(Transform target)
    {
        targetTransform = target;
    }

    public void setaimTransform(Transform aim)
    {
        aimTransform = aim;
    }




}

