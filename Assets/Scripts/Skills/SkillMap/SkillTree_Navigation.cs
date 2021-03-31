using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree_Navigation : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float maximumZoom;
    public float minimumZoom;
    private float zoomAmount = -1;
    private RectTransform rt;
    private bool isHoldingMidButton = false;
    private Vector3 mousePositionSaved;
    private Vector3 basicPosition;
    void Start()
    {
        rt = GetComponent<RectTransform>();
        basicPosition = transform.position;
    }

    public void Reset()
    {
        zoomAmount = -1;
        rt.localScale = new Vector3(-zoomAmount, -zoomAmount, 1);
        transform.position = basicPosition;
    }

    void Update()
    {

        zoomAmount += Input.GetAxis("Mouse ScrollWheel");
        if (-zoomAmount < minimumZoom )
        {
            zoomAmount = -minimumZoom;
        }
        if(-zoomAmount > maximumZoom)
        {
            zoomAmount = -maximumZoom;
        }
        rt.localScale = new Vector3(-zoomAmount, -zoomAmount, 1);


        if(isHoldingMidButton)
        {
            transform.position += (Input.mousePosition - mousePositionSaved) ;
            mousePositionSaved = Input.mousePosition;
        }



        if (Input.GetMouseButtonDown(2))
        {
            mousePositionSaved = Input.mousePosition;
            isHoldingMidButton = true;
            SkillTree_ToolTip.instance.isDraginSkillTree = true;
            SkillTree_ToolTip.instance.HideDesc();
        }
        if (Input.GetMouseButtonUp(2))
        {
            isHoldingMidButton = false;
            SkillTree_ToolTip.instance.isDraginSkillTree = false;
        }

    }
}
