using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehaviour : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Win");
    }
}
