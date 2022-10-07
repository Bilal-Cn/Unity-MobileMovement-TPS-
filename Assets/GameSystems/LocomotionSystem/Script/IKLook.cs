using UnityEngine;

public class IKLook : MonoBehaviour
{
    Animator anim;
    Camera maincam;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        maincam = Camera.main;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(1f, .5f, 1.2f, .5f, .5f);

        Ray lookatray = new Ray(transform.position, maincam.transform.forward);
        anim.SetLookAtPosition(lookatray.GetPoint(25));
    }


}
