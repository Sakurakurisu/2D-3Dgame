public class LaunchBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public GameObject lunchPosition; // 発射位置
    public KeyCode launchKey; // 発射キー

    AudioSource audioSource; // オーディオソース
    public AudioClip lunchSound; // 発射音

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>(); // オーディオソースを取得
    }

    void Update()
    {
        if (Input.GetKeyDown(launchKey)) // 発射キーが押されたか
        {
            Launch();
        }       
    }

    void Launch()
    {       
        BulletBase bulletBase = bulletPrefab.GetComponent<BulletBase>(); // 弾の情報を取得
        if (!bulletBase.IsBulletMax()) // 弾数が上限に達していないか
        {
            GameObject bullet = Instantiate(bulletPrefab, lunchPosition.transform.position, lunchPosition.transform.rotation); // 弾を生成
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            if (rb != null)
            {
                audioSource.PlayOneShot(lunchSound); // 発射音を再生
                rb.AddForce(transform.forward * bulletBase.launchForce, ForceMode.Impulse); // 弾に力を加える
            }

            bullet.GetComponent<BulletBase>().SetLaunchPosition(lunchPosition.transform.position); // 発射位置を設定
        }        
    } 
}