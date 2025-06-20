using Cinemachine;
using UnityEngine;

public class ModeChecker
{
    public bool Is2DModeActive(CinemachineVirtualCamera virtualCamera)
    {
        return virtualCamera.VirtualCameraGameObject.activeSelf;
    }

    public bool CanActivate2DMode(GameObject obj, LayerMask groundLayer)
    {
        RaycastHit hitInfo;

        return !Physics.Raycast(obj.transform.position, Vector3.forward, out hitInfo, groundLayer) && 
            !Physics.Raycast(obj.transform.position, Vector3.back, out hitInfo, groundLayer);
    }
}
