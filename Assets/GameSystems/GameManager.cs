using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField, Header("Set Component")]
    private PlayerController playerController;
    public void aimBtn()
    {
        if (!playerController.getIsAim())
        {
            playerController.setIsAim(true);
        }
        else
        {
            playerController.setIsAim(false);
        }
    }



    


    private void Start()
    {

    }

    void Update()
    {
        
        /*
        if (Input.GetMouseButton(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100))
            {
                if (raycastHit.transform.gameObject.GetComponent<GetItem>() != null)
                {
                    slotManager.itemAdd(raycastHit.transform.gameObject.GetComponent<GetItem>().itemPrefab);

                    Destroy(raycastHit.transform.gameObject);
                }
            }
        }*/


        
      
        
    }
}
