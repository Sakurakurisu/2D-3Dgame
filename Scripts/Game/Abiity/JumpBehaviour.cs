public class JumpBehaviour : MonoBehaviour
{
    // アニメーター
    public Animator animator;
    // ジャンプ力
    public float jumpForce;
    // 空中制御力
    public float airControlForce;
    // ジャンプキー
    public KeyCode jumpKey;
    // 落下時の力
    public float fallForce;
    // 地面判定用レイヤー
    public LayerMask groundLayer;

    AudioSource audioSource;
    // ジャンプ音
    public AudioClip jumpSound;

    Rigidbody rb;
    // ジャンプフラグ
    bool shouldJump = false;
    // 上昇中フラグ
    bool isAscending = false;

    // 壁判定
    public bool isWall = false;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ジャンプキーが押され、かつ地面にいる場合
        if (Input.GetKeyDown(jumpKey) && GameStateManager.GetInstance().IsGrounded)
        {
            shouldJump = true;
        }

        // 上昇中から下降に転じた時、かつ地面にいない場合
        if (isAscending && rb.velocity.y <= 0 && !GameStateManager.GetInstance().IsGrounded)
        {
            rb.AddForce(Vector3.down * fallForce, ForceMode.Impulse);
            isAscending = false;
        }
    }

    void FixedUpdate()
    {
        // ジャンプ処理
        if (shouldJump)
        {
            audioSource.PlayOneShot(jumpSound);
            Jump();

            animator.SetBool("IsJump", true);
            animator.SetBool("IsGrounded", false);

            shouldJump = false;
        }

        // 空中移動処理（壁にいない場合）
        if (!GameStateManager.GetInstance().IsGrounded && isWall == false)
        {
            AirMove();
        }

        // 地面にいる場合のアニメーション制御
        if (GameStateManager.GetInstance().IsGrounded)
        {
            animator.SetBool("IsJump", false);
            animator.SetBool("IsGrounded", GameStateManager.GetInstance().IsGrounded);
        }
    }

    void Jump()
    {
        // ジャンプ時に速度をリセット
        rb.velocity = new Vector3(0, 0, 0);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        GameStateManager.GetInstance().UpdateGroundedStatus(false);
        isAscending = true;
    }

    void AirMove()
    {
        // 空中での移動入力取得
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 airMovement = new Vector3(horizontalInput, 0f, verticalInput) * airControlForce;
        rb.velocity = new Vector3(airMovement.x * airControlForce, rb.velocity.y, airMovement.z * airControlForce);
    }
}