using UnityEngine;



[CreateAssetMenu(fileName = "New Camera Settings", menuName = "Qoalla Interactive Entertainment/Camera Settings")]
public class STCameraHelper : ScriptableObject
{
    [Header("Camera Setting")]
    public Vector3 CameraDistance;
    [Range(0, 3)]
    public float YOffset;
    [Range(0, 8)]
    public float Sensitivity;
    [Range(0, 4)]
    public float ScrollSensitivity;
    [Range(0, 10)]
    public float ScrollDampening;
    [Range(0, 4)]
    public float ZoomMinimum;
    [Range(0, 10)]
    public float ZoomMaximum;
    [Range(0, 5)]
    public float ZoomDistance;
    [Range(0, 5)]
    public float CollisionSensitivity;




}
