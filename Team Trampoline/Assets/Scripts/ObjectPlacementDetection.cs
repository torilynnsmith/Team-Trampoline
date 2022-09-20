using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementDetection : MonoBehaviour
{
    //Trigger Relevant Variables
    public GameObject correctObject; //set correct object to be placed in Trigger Area in Inspector


    //Color Changing Relevant Variables
    public Renderer objectRenderer; //name variable for objectRenderer
    //private SpriteRenderer spriteRenderer; //name variable for spriteRenderer
    private Color originalColor; //name variable for object's original color
    private Color correctColor = Color.green; //name and set variable for correctColor to green
    private Color incorrectColor = Color.red; //name and set variable for incorrectColor to red

    private void Awake()
    {
        //objectRenderer = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        originalColor = objectRenderer.material.color; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (correctObject)
        {
            //correctColor = new Color(0, 255, 0); //change color to green (0,255,0)
                                                 //red (1f,0,0 = 255,0,0)

            //objectRenderer.material.SetColor("_Color", objectColor); //set new color to sphere (currently only working for 3D)
            objectRenderer.material.color = correctColor; //set new color to sphere (currently only working for 3D
                                                          //ISSUE 2D sprite turns black...
            print("this is the correct object placement");
                //every object is reading as the correct object right now. 
        }

        //WHERE I LEFT OFF:
            //1. Not changing to incorrectColor when any object other than the correctObject is placed?
            //2. Changing the color of the Trigger, not the placed object. 
        else
        {
            //this needs to be for every object other than the correct one...should this be a tag situation?
            objectRenderer.material.color = incorrectColor; //set material color of object to red
            print("this is not the correct object to put here");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectRenderer.material.color = originalColor; 
    }
}
