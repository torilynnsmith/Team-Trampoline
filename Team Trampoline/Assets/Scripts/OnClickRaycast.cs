using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=gpnEPPyhLE8

public class OnClickRaycast : MonoBehaviour
{
    private Camera mainCamera;
    private Renderer renderer;

    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = new Ray(mainCamera.ScreenToWorldPoint(Input.mousePosition), mainCamera.transform.forward);
            //or
            //ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform == transform)
                {
                    Debug.Log("Click");
                }
            }
        }
    }
}
