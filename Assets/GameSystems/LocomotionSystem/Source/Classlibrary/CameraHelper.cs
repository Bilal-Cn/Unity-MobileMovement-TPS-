using UnityEngine;

namespace QoallaInteractiveCameraHelper
{
    public class CameraHelper 
    {


        public void fallowTarget(GameObject cameraRig,GameObject target,float yOffset)
        {
            // The CameraCenter (empty gameobject) follows always the character's position:
            var position1 = target.transform.position;
            cameraRig.transform.position = new Vector3(position1.x, position1.y + yOffset, position1.z);
        }



    }

}

