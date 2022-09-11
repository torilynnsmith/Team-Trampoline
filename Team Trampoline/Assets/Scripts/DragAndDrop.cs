using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem; //use the Input System downloaded from the Package Manager

//define the action of "mouseclick", then subscribe to an event to see when we actually click the mouse
//when we do, check if there's something under the mouse
//tutorial video: https://www.youtube.com/watch?v=HfqRKy5oFDQ&t=32s

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    private InputAction mouseClick;
    [SerializeField]
    private float mouseDragPhysicsSpeed = 10; //set mouseDragPhysicsSpeed
    [SerializeField]
    private float mouseDragSpeed = .1f; //set this way b/c SmoothDamp() is usually set from 0 to 1 

    private Camera mainCamera; //set Camera to mainCamera
    private Vector3 velocity = Vector3.zero; 
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();


    private void Awake()
    {
        mainCamera = Camera.main; 
    }

    private void OnEnable()
    {
        mouseClick.Enable(); //enable the mouseClick action
        mouseClick.performed += MousePressed; //suscribe to that event
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed; //unsubscribe to that event
        mouseClick.Disable(); //disable the mouseClick avtion
    }

    private void MousePressed(InputAction.CallbackContext context)
        //information regarding our action and how we interacted with it
        //we don't really need this though, what we need is our Mouse Position
        //within screen coordinates as set by camera and where the raycast determines our mouse is in space
        //Unity does this math for us.
    {
        //FOR 3D COLLIDERS
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()); //ScreenPointToRay takes into account the 3D perspective of the camera and the screen coordinates of our mouse by converting it into a ray we can query
            //ScreenToWorldPoint makes you have to pass in the correct distance that an object is from the camera
            //if you have a perspevtive camera, this messes up.
        RaycastHit hit; //will be populated if it hits something
            if (Physics.Raycast(ray, out hit)) //if it hits somthing, will output into the hit variable above
            {
                if (hit.collider != null //if we hit an object with a collider 
                && (hit.collider.gameObject.CompareTag("Draggable") //AND it's tagged "Draggable
                || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") //OR on the "Draggable" layer
                || hit.collider.gameObject.GetComponent<IDrag>() != null)) //OR has an IDrag component script on it
                    //then we will start dragging that object
                {
                StartCoroutine(DragUpdate(hit.collider.gameObject)); //start the DragUpdate coroutine
                }
            }

        //FOR 2D SPRITES
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null //if we hit an object with a collider 
                && (hit2D.collider.gameObject.CompareTag("Draggable") //AND it's tagged "Draggable
                || hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Draggable") //OR on the "Draggable" layer
                || hit2D.collider.gameObject.GetComponent<IDrag>() != null)) //OR has an IDrag component script on it
                                                                           //then we will start dragging that object
        {
            StartCoroutine(DragUpdate(hit2D.collider.gameObject)); //start the DragUpdate coroutine
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
        //CoRoutines run like functions, but their executions can be paused with certain conditions
        //runs when we click an object and drag, stops when we let go
    {
        clickedObject.TryGetComponent<Rigidbody>(out var rb); //will try to get this component and if it does will output into a variable called rb
        clickedObject.TryGetComponent<IDrag>(out var iDragComponent);
        iDragComponent?.onStartDrag(); //is this null? if not, we can call it.

        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        while (mouseClick.ReadValue<float>() != 0) //currently clicking down = 1
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
                //every frame this is run will cast a ray to take into account the new mouse position
            if (rb != null) //then we will move it using physics
            {
                //must set the velocity that our mouse is moving at so our object can follow
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position; //move our object towards our mouse.
                rb.velocity = direction * mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate;

                //NOTE: if the rigidBody object is moving quickly, it may look wonky,
                //so we can set CollisionDetection on the movable object to Continuous Dynamic
                //and the objects it's colliding with to Continious.
                //HOWEVER, this takes a alot of power so we should try to avoid it
                //setting the "floor" to static helps with less power
            }
            else //if you don't have a rigidBody
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
                //SmoothDampe(move from point, to point, outputs current velocity, speed)
                //SmoothDamp creates a smooth movement with acceleration and decceleration
                yield return null; //yields the while loop until the next frame
            }
        }

        iDragComponent?.onEndDrag(); //is this null? if not, we can call it.
    }
}
