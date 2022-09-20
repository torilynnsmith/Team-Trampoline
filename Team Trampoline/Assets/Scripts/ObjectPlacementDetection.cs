using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementDetection : MonoBehaviour
{
    //Trigger Relevant Variables
    public GameObject correctObject; //set correct object to be placed in Trigger Area in Inspector
        //changed to correctObject (correctTrigger)

    //Color Changing Relevant Variables
    public Renderer objectRenderer; //name variable for objectRenderer
    //private SpriteRenderer spriteRenderer; //name variable for spriteRenderer
    private Color originalColor; //name variable for object's original color
    private Color correctColor = Color.green; //name and set variable for correctColor to green
    private Color incorrectColor = Color.red; //name and set variable for incorrectColor to red

    int correctTriggerID; 

    private void Awake()
    {
        //objectRenderer = GetComponent<Renderer>();
        correctTriggerID = correctObject.GetInstanceID(); 
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

    private void OnTriggerStay(Collider other)
    {
        if (other.GetInstanceID() == correctTriggerID) 
        {
            //correctColor = new Color(0, 255, 0); //change color to green (0,255,0)
                                                 //red (1f,0,0 = 255,0,0)

            //objectRenderer.material.SetColor("_Color", objectColor); //set new color to sphere (currently only working for 3D)
            objectRenderer.material.color = correctColor; //set new color to sphere (currently only working for 3D
                                                          //ISSUE 2D sprite turns black...
            Debug.Log("this is the correct object placement");
                //every object is reading as the correct object right now. 
        }

        //WHERE I LEFT OFF:
            //1. We put this script on the item, not the trigger
            //2. it is turning to the incorrectColor no matter what
            //3. returning the same InstanceID for both items in both triggers
            //4. OPTION THAT WE SHOULD PROBABLY TAKE: instance a new collision layer for each object, would potentially reduce the amount of checks we do.
                //Would additionally keep our objects from colliding with eachother but still collide with the "apartment" with a new line of code. 
                
        else
        {
            //this needs to be for every object other than the correct one...should this be a tag situation?
            objectRenderer.material.color = incorrectColor; //set material color of object to red
            Debug.Log("this is not the correct object to put here");
        }

        Debug.Log("otherID:" + other.GetInstanceID());
        Debug.Log("correctID:" + correctTriggerID);
    }

    private void OnTriggerExit(Collider other)
    {
        objectRenderer.material.color = originalColor; 
    }
}
