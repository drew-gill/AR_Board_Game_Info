using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Raycaster : MonoBehaviour
{
    ARRaycastManager raycastManager;

    private List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
    private HashSet<int> tappedObjects = new HashSet<int>();
    

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;

        if(raycastManager.Raycast(Input.GetTouch(0).position, m_Hits))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                URLInteraction urlInteraction = hit.collider.gameObject.GetComponent<URLInteraction>();
                if(urlInteraction != null)
                {
                    Application.OpenURL(urlInteraction.url);
                }
            }
        }
    }
}
