public class MoveBehaviour : MonoBehaviour
    {
        public Animator animator; // アニメーター
        public float moveSpeed;   // 移動速度
    
        Rigidbody rb;
    
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
    
        void FixedUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");    
    
            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput); // 移動ベクトル
    
            bool isMoving = movement.magnitude > 0.1f; // 動いているかどうか
    
            if (GameStateManager.GetInstance().IsGrounded) // 地面にいるか
            {
                rb.velocity = new Vector3(movement.x * moveSpeed, rb.velocity.y, movement.z * moveSpeed); // 速度を設定
                if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
                {
                    // 横方向の入力が大きい場合、向きを変更
                    rb.rotation = horizontalInput > 0 ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, -90, 0);
                }
                else if (Mathf.Abs(verticalInput) > 0)
                {
                    // 縦方向の入力がある場合、向きを変更
                    rb.rotation = verticalInput > 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
                }
    
                animator.SetBool("IsRunning", isMoving); // アニメーションの切り替え
            }
            else
            {
                animator.SetBool("IsRunning", false); // 走っていない状態
            }
        }
    }