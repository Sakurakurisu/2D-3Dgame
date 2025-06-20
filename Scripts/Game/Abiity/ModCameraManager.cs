using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class ModCameraManager : MonoBehaviour
{   
    public KeyCode keyCode;
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        GameStateManager.GetInstance().Init2DModStatus(new ModeChecker().Is2DModeActive(virtualCamera));

        GameStateManager.GetInstance().OnModeChange += HandleModeChange;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (GameStateManager.GetInstance().CanActivate2DMode)
            {
                if (virtualCamera != null)
                {
                    GetComponent<AudioSource>().Play();
                    GameStateManager.GetInstance().Toggle2DMod();
                }
            }
            else
            {
                WallWarn.Instance.ActivateObject(true);
            }
        }
       
    }

    void HandleModeChange()
    {
        ChangeModCamera();
    }

    void ChangeModCamera()
    {
        if (virtualCamera != null)
        {
            virtualCamera.VirtualCameraGameObject.SetActive(!GameStateManager.GetInstance().Is2DMod);
        }     
    }
}
