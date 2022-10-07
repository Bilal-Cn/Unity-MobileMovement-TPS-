using UnityEngine;

[CreateAssetMenu(fileName = "New Character Settings", menuName = "Qoalla Interactive Entertainment/Character Settings")]
public class STCharacterHelper : ScriptableObject
{
    [Header("Character Movement Setting")]
    [Range(0, 50)]
    public float WalkSpeed;
    [Range(0, 50)]
    public float RunSpeed;
    [Range(0, 50)]
    public float StrafeWalkSpeed;
    [Range(0, 50)]
    public float RotationSpeed;



    [Header("Character Animation Variables")]
    [Range(0, 10)]
    public float DampTime;
    [Range(0, 20)]
    public float DeltaTime;



    [Header("Character Jump Setting")]
    [Range(0, .5f)]
    public float GroundCheckDistance;
    [Range(0, 50)]
    public float JumpForce;


}
