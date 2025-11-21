using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VrMovement : MonoBehaviour
{

    public float m_Sensitivity = .1f;
    public float m_MaxSpeed = 1.0f;

    public SteamVR_Action_Boolean m_MovePress = null;
    public SteamVR_Action_Vector2 m_MoveValue = null;

    private float m_Speed = 0.0f;

    private CharacterController m_CharacterController = null;
    private Transform m_cameraRig = null;
    private Transform m_head = null;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_cameraRig = SteamVR_Render.Top().origin;
        m_head = SteamVR_Render.Top().head;
    }

    // Update is called once per frame
    void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateMovement();
       

    }

    private void HandleHead()
    {
        Vector3 oldposition = m_cameraRig.position;
        Quaternion oldrotation = m_cameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, m_head.rotation.eulerAngles.y, 0.0f);

        m_cameraRig.position = oldposition;
        m_cameraRig.rotation = oldrotation;
    }

    private void CalculateMovement()
    {
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (m_MovePress.GetStateUp(SteamVR_Input_Sources.Any))
            m_Speed = 0;

        if (m_MovePress.state)
        {
            m_Speed += m_MoveValue.axis.y * m_Sensitivity;
            m_Speed = Mathf.Clamp(m_Speed, -m_MaxSpeed, m_MaxSpeed);

            movement += orientation * (m_Speed * Vector3.forward) * Time.deltaTime;
        }

        m_CharacterController.Move(movement);


    }

    private void HandleHeight()
    {
        float headheight = Mathf.Clamp(m_head.localPosition.y, 1, 2);
        m_CharacterController.height = headheight;

        Vector3 newCenter = Vector3.zero;
        newCenter.y = m_CharacterController.height / 2;
        newCenter.y += m_CharacterController.skinWidth;

        newCenter.x = m_head.localPosition.x;
        newCenter.z = m_head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter ;

        m_CharacterController.center = newCenter;

    }
}
