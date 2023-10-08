using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public float smoothSpeed = 0.125f; // カメラの移動スムーズさ
    public float maxDistance = 3.0f; // プレイヤーからの最大距離

    private Vector3 initialOffset; // カメラの初期オフセット
    private Vector3 targetPosition; // カメラの目標位置

    void Start()
    {
        initialOffset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if(player != null && Time.timeScale == 1)
        {
            // プレイヤーとマウスカーソルの中心位置を計算
            Vector3 playerPosition = player.position;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 centerPosition = (playerPosition + mousePosition) / 2f;

            // カメラの目標位置を計算
            Vector3 desiredPosition = centerPosition + initialOffset;

            // プレイヤーとカメラの距離を制限
            float distance = Vector3.Distance(playerPosition, desiredPosition);
            if (distance > maxDistance)
            {
                Vector3 direction = (desiredPosition - playerPosition).normalized;
                desiredPosition = playerPosition + direction * maxDistance;
            }

            // カメラの位置をスムーズに移動
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}