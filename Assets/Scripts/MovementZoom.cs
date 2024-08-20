using UnityEngine;
using Cinemachine;
public class MovementZoom : MonoBehaviour
{
    // Movement based Scroll Wheel Zoom.

    public Transform parentObject;
    public float zoomLevel;
    public float sensitivity = 1;
    public float speed = 30;
    public float maxZoom = 30;
    public float minZoom = -30;
    float zoomPosition;

    //[SerializeField]
    //private CinemachineVirtualCamera cinemachineVirtualCamera;
    //private Vector3 followOffset;
    //[SerializeField]
    //private float followOffsetMin = 5f;
    //[SerializeField]
    //private float followOffsetMax = 50f;

    //private void Awake()
    //{
    //    followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    //}
    void FixedUpdate()
    {
        zoomLevel += Input.mouseScrollDelta.y * sensitivity;
        zoomLevel = Mathf.Clamp(zoomLevel, minZoom, maxZoom);
        zoomPosition = Mathf.MoveTowards(zoomPosition, zoomLevel, speed * Time.deltaTime);
        transform.position = parentObject.position + (transform.forward * zoomPosition);

        //followOffset = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
        //Vector3 zoomDir = followOffset.normalized;
        //if (Input.mouseScrollDelta.y > 0)
        //{
        //    followOffset += zoomDir;
        //}
        //if (Input.mouseScrollDelta.y < 0)
        //{
        //    followOffset -= zoomDir;
        //}

        //if(followOffset.magnitude < followOffsetMin)
        //{
        //    followOffset = zoomDir * followOffsetMin;
        //}
        //if(followOffset.magnitude > followOffsetMax)
        //{
        //    followOffset = zoomDir * followOffsetMax;
        //}

        //cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset =
        //    Vector3.Lerp(cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset, followOffset, Time.deltaTime);
    }
}