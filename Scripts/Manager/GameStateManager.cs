public class GameStateManager : SingletonAutoMono<GameStateManager>
    {
        public bool isGrounded;
        public bool is2DMod;
        public bool canActivate2DMode;
    
        public bool IsGrounded { get; private set; }
        public bool Is2DMod { get; private set; }
        public bool CanActivate2DMode { get; private set; }
    
        public event Action OnModeChange;
    
        GameObject[] objectsWithTag;
        string colliderTag = "2DCollider";
    
        void Start()
        {
            Is2DMod = false;
            // 2DColliderタグを持つ全てのオブジェクトを取得
            objectsWithTag = GameObject.FindGameObjectsWithTag(colliderTag);
            Set2DCollidersActive(Is2DMod);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // シーンがロードされた時、再度2DColliderタグのオブジェクトを取得
            objectsWithTag = GameObject.FindGameObjectsWithTag(colliderTag);
            Set2DCollidersActive(Is2DMod);
        }
    
        public void UpdateGroundedStatus(bool status)
        {
            IsGrounded = status;
    
            isGrounded = IsGrounded;
        }
    
        public void Init2DModStatus(bool status)
        {
            Is2DMod = status;
    
            is2DMod = Is2DMod;
        }
    
        public void UpdateActivate2DMode(bool status)
        {
            CanActivate2DMode = status;
            canActivate2DMode = CanActivate2DMode;
        }
    
        public void Toggle2DMod()
        {
            OnModeChange?.Invoke();
            // 2DモードのON/OFFを切り替える
            Is2DMod = !Is2DMod;
    
            is2DMod = Is2DMod;
        }
    
        public void Set2DCollidersActive(bool isTrue)
        {
            // 2DColliderタグを持つ全てのオブジェクトのアクティブ状態を切り替える
            foreach (GameObject obj in objectsWithTag)
            {
                obj.SetActive(isTrue);
            }
        }
    
        void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }