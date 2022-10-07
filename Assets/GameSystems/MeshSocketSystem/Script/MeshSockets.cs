using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace socket {

    public class MeshSockets : MonoBehaviour
    {


        public void Attach(Transform socketTransform, Transform objectTransform)
        {
            objectTransform.SetParent(socketTransform);
            objectTransform.localPosition = Vector3.zero;
            objectTransform.localRotation = Quaternion.identity;
        }

    }
}

