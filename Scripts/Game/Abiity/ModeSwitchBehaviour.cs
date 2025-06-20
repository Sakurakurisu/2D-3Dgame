public class ModeSwitchBehaviour : MonoBehaviour
{
    public LayerMask groundLayer;  // 地面レイヤー

    string colliderTag = "2DCollider"; // 2Dコライダーのタグ

    void Start()
    {
        // モード切替イベントにハンドラを登録
        GameStateManager.GetInstance().OnModeChange += HandleModeChange;
    }

    void HandleModeChange()
    {
        // 2Dモード状態に応じて2Dコライダーの有効/無効を切り替える
        GameStateManager.GetInstance().Set2DCollidersActive(!GameStateManager.GetInstance().Is2DMod);
    }

    private void Update()
    {
        SnapTo3DPosition();
    }

    void SnapTo3DPosition()
    {
        RaycastHit hitInfo;
        // 下方向にレイキャストして地面を検出
        bool isOnColliderGround = Physics.Raycast(transform.position, Vector3.down, out hitInfo, 5.0f, groundLayer);
        if (isOnColliderGround && hitInfo.collider.tag == colliderTag)
        {
            // 3D空間のZ座標にスナップ
            GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, transform.position.y, hitInfo.transform.parent.position.z));
        }
    }

    void OnDestroy()
    {
        // イベント登録解除
        GameStateManager.GetInstance().OnModeChange -= HandleModeChange;
    }
}