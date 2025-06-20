using UnityEngine;

public class CharacterStateChecker : MonoBehaviour
{
    public LayerMask groundLayer;
    public GameObject checkerPoint;

    GroundChecker groundChecker;

    ModeChecker modeChecker;

    void Start()
    {
        groundChecker = new GroundChecker();
        modeChecker = new ModeChecker();
    }

    void Update()
    {       
        GameStateManager.GetInstance().UpdateGroundedStatus(groundChecker.IsGround(this.gameObject, groundLayer));
        GameStateManager.GetInstance().UpdateActivate2DMode(modeChecker.CanActivate2DMode(checkerPoint, groundLayer));
    }
}
