// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;

// public class PokeColorChange : MonoBehaviour
// {
//     public Material redMaterial; // Assign the red material in the inspector

//     private MeshRenderer cubeRenderer;
//     private XRBaseInteractable interactable;

//     void Start()
//     {
//         cubeRenderer = GetComponent<MeshRenderer>();
//         interactable = GetComponent<XRBaseInteractable>();

//         // Use the new selectEntered event
//         interactable.selectEntered.AddListener(OnPoke);
//     }

//     void OnPoke(SelectEnterEventArgs args)
//     {
//         // Change the color of the cube to red
//         cubeRenderer.material = redMaterial;
//     }
// }


using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PokeColorChange : MonoBehaviour
{
    public Material redMaterial; // Assign the red material in the inspector

    private MeshRenderer cubeRenderer;
    private XRBaseInteractable interactable;

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>();
        interactable = GetComponent<XRBaseInteractable>();

        // Use the new selectEntered event
        interactable.selectEntered.AddListener(OnPoke);
        Debug.Log("Event listener added");
    }

    void OnPoke(SelectEnterEventArgs args)
    {
        Debug.Log("OnPoke called");
        if (cubeRenderer != null && redMaterial != null)
        {
            // Change the color of the cube to red
            cubeRenderer.material = redMaterial;
            Debug.Log("Color changed to red");
        }
        else
        {
            Debug.LogError("MeshRenderer or redMaterial not assigned");
        }
    }
}
