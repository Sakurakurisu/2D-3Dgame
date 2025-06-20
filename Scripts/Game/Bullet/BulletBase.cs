public class BulletBase : MonoBehaviour
    {
        public static int currentBullets = 0; // 現在の弾数
    
        public float launchForce; // 発射力
        public float maxDistance; // 最大距離
        public int maxBullets;    // 弾の最大数
    
        protected Vector3 launchPosition; // 発射位置
    
        protected void Start()
        {
            currentBullets++;
        }
    
        protected void Update()
        {
            float distanceMoved = Vector3.Distance(launchPosition, transform.position); // 移動距離を計算
            if (distanceMoved > maxDistance) Destroy(gameObject); // 最大距離を超えたら削除
        }
    
        protected void OnDestroy()
        {
            currentBullets--;
        }
    
        public bool IsBulletMax()
        {
            return currentBullets >= maxBullets;
        }
    
        public void SetLaunchPosition(Vector3 position)
        {
            launchPosition = position; 
        }
    }