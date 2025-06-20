using UnityEngine;

public class DeadLineBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<SceneChanger>().ChangeScene("Game Over");
        }
    }
}
