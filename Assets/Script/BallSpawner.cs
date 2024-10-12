using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;  // Meta XR SDK用のインポート

public class BallSpawner : MonoBehaviour
{
     // 生成するプレハブ
    public GameObject prefab;

    // カメラ（目に相当するもの）
    public GameObject mainCamera;

    // プレハブを生成する距離（目の前の距離）
    public float spawnDistance = 1f;

    // プレハブの移動速度
    public float moveSpeed = 5f;

    // どのコントローラーのトリガーを使用するか（LTouch = 左手、RTouch = 右手）
    public OVRInput.Controller controller;

    void Update()
    {
        // トリガーの押下を監視（OVRInput.Axis1D.PrimaryIndexTriggerはトリガーの入力値を取得）
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, controller))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        // プレハブを生成
        GameObject spawnedPrefab = SpawnPrefab();

        StartCoroutine(MoveForward(spawnedPrefab));
    }

    GameObject SpawnPrefab()
    {
        // カメラの位置と向きからプレハブを生成する位置を計算
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;

        // プレハブを指定された位置に生成し、その参照を返す
        return Instantiate(prefab, spawnPosition, mainCamera.transform.rotation);
    }

    IEnumerator MoveForward(GameObject prefabInstance)
    {
        // プレハブが生成されてから前方に進み続ける
        while (prefabInstance != null)
        {
            // プレハブをカメラの向きに従って前方に移動させる
            prefabInstance.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // 1フレーム待機
            yield return null;
        }
    }
    
}
