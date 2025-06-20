using UnityEngine;

public class WallChecker : MonoBehaviour
{
    public GameObject chara;

    void Update()
    {
        if(GameStateManager.GetInstance().IsGrounded)
        {
            chara.GetComponent<JumpBehaviour>().isWall = false;
        }
        
    }



    void OnTriggerEnter(Collider other)
    {
        if(!GameStateManager.GetInstance().IsGrounded) chara.GetComponent<JumpBehaviour>().isWall = true;
        else chara.GetComponent<JumpBehaviour>().isWall = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (!GameStateManager.GetInstance().IsGrounded) chara.GetComponent<JumpBehaviour>().isWall = true;
        else chara.GetComponent<JumpBehaviour>().isWall = false;
    }


    private void OnTriggerExit(Collider other)
    {
        if (!GameStateManager.GetInstance().IsGrounded) chara.GetComponent<JumpBehaviour>().isWall = false;
        else chara.GetComponent<JumpBehaviour>().isWall = false;
    }
}
