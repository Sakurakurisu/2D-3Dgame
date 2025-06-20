using UnityEngine;

public class GroundChecker
{
    public bool IsGround(GameObject obj,LayerMask groundLayer)
    {
        var raycastALL = Physics.OverlapBox(obj.transform.position, new Vector3(0.3f, 0.03f, 0.2f), Quaternion.identity, groundLayer);

        return raycastALL.Length > 0 ? true : false;
    }

}
