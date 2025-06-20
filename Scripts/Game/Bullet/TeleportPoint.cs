public class TeleportPoint : BulletBase, IModeChangeResponder
    {
        public LayerMask groundLayer;
        public float teleportDistance;
        public Transform teleportPosition;
    
        GameObject chara; // キャラクターのGameObject
        bool canTeleport = false; // テレポート可能かどうか
        bool canCancel = false;   // キャンセル可能かどうか
    
        new void Start()
        {
            base.Start();
    
            GameStateManager.GetInstance().OnModeChange += HandleModeChange;
            chara = GameObject.Find("Character"); // キャラクターを探す
        }
    
        new void Update()
        {
            base.Update();
    
            // Eキーでテレポート
            if (Input.GetKeyDown(KeyCode.E) && canTeleport)
            {
                if(IsOverDistance()) // 距離オーバー判定
                {
                    TeleportWarn.Instance.ActivateObject(true); // 警告を表示
                }
                else
                {
                    chara.gameObject.SetActive(false); // 一旦非表示
                    chara.transform.position = teleportPosition.position; // テレポート
                    chara.gameObject.SetActive(true); // 再表示
    
                    GameObject.Find("TeleportSound").GetComponent<AudioSource>().Play(); // サウンド再生
                    Destroy(gameObject); // テレポートポイントを削除
                }
            }
            // Fキーでキャンセル
            else if (Input.GetKeyDown(KeyCode.F) && canCancel)
            {
                Destroy(gameObject); // テレポートポイントを削除
            }
        }
    
        // 距離が制限を超えているか判定
        bool IsOverDistance()
        {
            float distance = Vector3.Distance(chara.transform.position, transform.position);
            return distance > teleportDistance;
        }
    
        new void OnDestroy()
        {
            base.OnDestroy();
            GameStateManager.GetInstance().OnModeChange -= HandleModeChange;
        }
    
        // ポータルに何かが入った時の処理
        void OnTriggerEnter(Collider other)
        {
            if(other.tag != "Player")
            {
                // 位置を固定
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                Transform portalBlue = this.transform.Find("Portal blue");
    
                if (portalBlue != null)
                {
                    portalBlue.gameObject.SetActive(true); // ポータルを表示
                }
                // 2Dモードで有効か判定
                canTeleport = true && new ModeChecker().CanActivate2DMode(this.gameObject, groundLayer);
                canCancel = true;
            }
        }
    
        // モード変更時の処理
        public void HandleModeChange()
        {
            StartCoroutine(DelayedHandleModeChange());
        }
    
        // モード変更後に位置を調整
        IEnumerator DelayedHandleModeChange()
        {
            yield return null;
            GetComponent<Rigidbody>().MovePosition(new Vector3(this.transform.position.x, this.transform.position.y, chara.transform.position.z));
        }
    }