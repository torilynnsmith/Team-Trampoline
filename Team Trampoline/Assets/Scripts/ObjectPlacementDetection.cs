using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementDetection : MonoBehaviour
{
    //Trigger Relevant Variables
    //public GameObject correctObject; //set correct object to be placed in Trigger Area in Inspector
    //changed to correctObject (correctTrigger)

    public GameObject[] validObjects; //an array in editor, can dynamically change what is correct in this liss


    //Color Changing Relevant Variables
    public Renderer objectRenderer; //name variable for objectRenderer
    //private SpriteRenderer spriteRenderer; //name variable for spriteRenderer
    private Color originalColor; //name variable for object's original color
    private Color correctColor = Color.green; //name and set variable for correctColor to green
    private Color incorrectColor = Color.red; //name and set variable for incorrectColor to red

    public bool validName; 

    int correctTriggerID;

    private void Awake()
    {
        //objectRenderer = GetComponent<Renderer>();
        //correctTriggerID = correctObject.GetInstanceID(); 
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
        //if (other.GetName() find in List = True)
        //return valid trigger
        string[] targets = NameList(validObjects); //will return valid strings we've set for this collider
        validName = false; //set validName bool to false

        //for each index in targets, check name against collider name
        for(int i = 0; i < targets.Length; i++)
        {
            if(other.name == targets[i])
            {
                validName = true; //if we find a name match, bool sets to true
            }
        }

        if (validName)
        {
            //correctColor = new Color(0, 255, 0); //change color to green (0,255,0)
            //red (1f,0,0 = 255,0,0)

            //objectRenderer.material.SetColor("_Color", objectColor); //set new color to sphere (currently only working for 3D)
            objectRenderer.material.color = correctColor; //set new color to sphere (currently only working for 3D
                                                          //ISSUE 2D sprite turns black...
            Debug.Log("this is the correct object placement");
            //every object is reading as the correct object right now. 
        }

        else
        {
            //this needs to be for every object other than the correct one...should this be a tag situation?
            objectRenderer.material.color = incorrectColor; //set material color of object to red
            Debug.Log("this is not the correct object to put here");
        }

        //Debug.Log("otherID:" + other.GetInstanceID());
        //Debug.Log("correctID:" + correctTriggerID);
    }

    private void OnTriggerExit(Collider other)
    {
        //WHERE WE LEFT OFF: we might want to check the name of the exiting collider
        //fix renderer and color changing aspects

        validName = false; //set bool validName to false
        objectRenderer.material.color = originalColor;
    }

    string[] NameList(GameObject[] myObjects)
    {
        //establish a string[] and set the length of that array equal to the length of the myObject[] set in variables
        string[] nameList = new string[myObjects.Length];

        //for each index in myObjects, set the nameList index equal to myObjects at that index
            //for ex. GameObject "baseball" will return the string "baseball" at it's given index number
        for(int i = 0; i<myObjects.Length; i++)
        {
            nameList[i] = myObjects[i].name;
        }
        return nameList;
    }
}
