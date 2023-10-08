using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // カスタムカーソルとして使用するテクスチャ
    public Vector2 hotSpot = Vector2.zero; // カーソルのホットスポット（カーソルの位置と実際のアクションが起こる位置）の初期値

    void Start()
    {
        // カスタムカーソルを設定
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

     void Update()
    {
        // マウスのカーソル位置を取得
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = transform.position.z; // オブジェクトのz座標を維持

        // オブジェクトをカーソル位置に移動
        transform.position = cursorPosition;
    }

}
