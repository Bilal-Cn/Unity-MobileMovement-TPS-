using UnityEngine;



[CreateAssetMenu(fileName = "Get Input Variables", menuName = "Qoalla Interactive Entertainment/New Input")]
public class STInput : ScriptableObject
{
    [Header("Keyboard")]
    public string AxisHorizontal;
    public string AxisVertical;




    [Header("ActionButton")]
    public KeyCode JumpButton;
    public KeyCode SprintButton;
    public KeyCode StrafeButton;
    public KeyCode EquipButton;



}
 