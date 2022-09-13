using UnityEngine;

public class SphereController : MonoBehaviour, IDrag //inherit from our interface, hover and CTRL + .
{
    private Rigidbody rb; //ref RigidBody on attached object
        //WHERE I LEFT OFF
        //NOTE: alter these into an if statement? not everything will have a rigidbody, but I want to code this for both.

    private Renderer objectRenderer; //name variable for objectRenderer
    private Color objectColor; //name variable for objectColor

    //private float randomChannelOne, randomChannelTwo, randomChannelThree; //color channels

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        objectRenderer = GetComponent<Renderer>(); 
    }

    public void onStartDrag()
    {
        //throw new System.NotImplementedException();
        rb.useGravity = false; //ignore gravity when dragging

    }

    public void onEndDrag()
    {
        //throw new System.NotImplementedException();
        rb.useGravity = true; //reinstate gravity when done dragging
        rb.velocity = Vector3.zero; //object will drop straight down when dropped

        //Randomize color channel values on End Drag
        //randomChannelOne = Random.Range(0f, 1f);
        //randomChannelTwo = Random.Range(0f, 1f);
        //randomChannelThree = Random.Range(0f, 1f);

        //CHANGE COLOR
            //WHERE I LEFT OFF
            //CHECK IF OBJECT IS IN THE CORRECT PLACE, IF YES THEN OBJECT IS GREEN, IF NOT OBJECT IS RED
        objectColor = new Color(1f, 0, 0); //change color to red (1f,0,0 = 255,0,0) 

        objectRenderer.material.SetColor("_Color", objectColor); //set new color to sphere
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
