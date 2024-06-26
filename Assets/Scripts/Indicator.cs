using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    private GameObject indicator;
    private List<ARRaycastHit> hits= new List<ARRaycastHit>();

    void Start()
    {
        aRRaycastManager=FindObjectOfType<ARRaycastManager>();
        indicator=transform.GetChild(0).gameObject;
        indicator.SetActive(false);
    }

    void Update()
    {
        var ray = new Vector2(Screen.width/2,Screen.height/2);
        if(aRRaycastManager.Raycast(ray,hits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose= hits[0].pose;
            
            transform.position= hitPose.position;
            transform.rotation= hitPose.rotation;

            if(!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
            }

        }
    }
}
