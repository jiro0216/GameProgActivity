using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPickUpDrop : MonoBehaviour
{
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private TextMeshProUGUI hoverText; // Reference to the TextMeshProUGUI component for displaying hover text

    private ObjectGrabbable objectGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                float pickupDistance = 2f;

                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickupDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                // Currently carrying something 
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }

        // Check if the player is hovering over a grabbable GameObject and update hover text
        UpdateHoverText();
    }

    private void UpdateHoverText()
    {
        // Check if the player is hovering over a grabbable GameObject
        RaycastHit hit;
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, Mathf.Infinity, pickUpLayerMask))
        {
            // Update hover text to display relevant information
            hoverText.text = "Press E to grab";
            hoverText.gameObject.SetActive(true);
        }
        else
        {
            // Hide hover text if not hovering over a grabbable GameObject
            hoverText.gameObject.SetActive(false);
        }
    }
}
