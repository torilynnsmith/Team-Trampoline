using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementDetection : MonoBehaviour
{
    //TO DO:
        //particle effect on correct placement
        //sound effect on correct placement

    //Trigger Relevant Variables
    public GameObject[] validObjects; //an array in editor, can dynamically change what is correct in this list
        //originally used public GameObject correct Object, but this allows for the placement of multiple objects in a "correct space"
        //HOWEVER, we'll have to pull the original material for each object in order to really make this work.

    //Color/Material Changing Relevant Variables
    public Renderer objectRenderer; //name variable for objectRenderer
    public Material mat1; //original material color,
                          //TO DO: change later to be back to original material
    public Material mat2; //green, correct placement


    public bool validName; 

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
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
            objectRenderer.material = mat2; //change material to Green

            //correctColor = new Color(0, 255, 0); //change color to green (0,255,0)
            //red (1f,0,0 = 255,0,0)

            //objectRenderer.material.SetColor("_Color", objectColor); //set new color to sphere (currently only working for 3D)
            //objectRenderer.material.color = correctColor; //set new color to sphere (currently only working for 3D
                                                          //ISSUE 2D sprite turns black...
                //IDEA: what if we specify the game object and then pull the material from that? like GameObjectVariable.material.color
                    //coolGo.GetComponent<MeshRenderer>().material DO THIS
                //also, what if instead of changing the color, we just change the material? probably simpler that way?
            Debug.Log("this is the correct object placement");
            //every object is reading as the correct object right now. 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        validName = false; //set bool validName to false
        //objectRenderer.material.color = originalColor;
        objectRenderer.material = mat1;
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
