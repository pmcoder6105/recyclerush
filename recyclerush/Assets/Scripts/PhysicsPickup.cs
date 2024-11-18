using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    private Camera mainCamera;
    private Rigidbody selectedObject;
    private Vector3 offset;

    void Start()
    {
        // Get the main camera reference
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // Get the mouse position
            Vector3 mousePosition = Input.mousePosition;

            // Convert both positions to world space using the camera
            Ray rayFromCenter = mainCamera.ScreenPointToRay(screenCenter);
            Ray rayToMouse = mainCamera.ScreenPointToRay(mousePosition);
            Debug.DrawRay(rayToMouse.origin, rayToMouse.direction * 100, Color.blue, 2f);
            if (Physics.Raycast(rayToMouse, out RaycastHit hit, Mathf.Infinity))
            {
                // Check if the hit object has a Rigidbody
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    selectedObject = rb;
                    selectedObject.useGravity = false; // Disable gravity while dragging
                    selectedObject.velocity = Vector3.zero; // Stop any existing motion
                    Debug.Log("Checkpoint 1?");

                    // Calculate the offset between the object and the camera ray
                    offset = hit.point - selectedObject.transform.position;
                }
            }
        }

        if (Input.GetMouseButton(0) && selectedObject != null) // While holding the mouse button
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // Get the mouse position
            Vector3 mousePosition = Input.mousePosition;

            // Convert both positions to world space using the camera
            Ray rayFromCenter = mainCamera.ScreenPointToRay(screenCenter);
            Ray rayToMouse = mainCamera.ScreenPointToRay(mousePosition);
            Debug.DrawRay(rayToMouse.origin, rayToMouse.direction * 100, Color.blue, 2f);
                    Debug.Log("Checkpoint 2?");


            if (Physics.Raycast(rayToMouse, out RaycastHit hit, Mathf.Infinity))
            {
                    Debug.Log("Checkpoint 3?");

                // Update the object's position based on the ray hit
                Vector3 targetPosition = hit.point - offset;
                Debug.Log(targetPosition.x);
                selectedObject.MovePosition(new Vector3(targetPosition.x, targetPosition.y, selectedObject.position.z));
            }
        }

        if (Input.GetMouseButtonUp(0) && selectedObject != null) // Mouse button released
        {
            selectedObject.useGravity = true; // Re-enable gravity
            selectedObject = null; // Clear the reference
        }
    }
}