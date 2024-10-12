using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrefabSpawner : MonoBehaviour, IPointerClickHandler
{
    // 生成するプレハブ
    public GameObject prefab;

    // カメラ（目に相当するもの）
    public Camera mainCamera;

    // プレハブを生成する間隔（秒）
    public float spawnInterval = 2f;

    // プレハブを生成する距離（目の前の距離）
    public float spawnDistance = 1f;

    // プレハブの移動速度
    public float moveSpeed = 5f;

    void Start()
    {
        // 定期的にプレハブを生成するコルーチンを開始
        //StartCoroutine(SpawnPrefabPeriodically());
    }

    IEnumerator SpawnPrefabPeriodically()
    {
        while (true)
        {
            // プレハブを生成
            GameObject spawnedPrefab = SpawnPrefab();

            // プレハブを前方に移動させるコルーチンを開始
            StartCoroutine(MoveForward(spawnedPrefab));

            // 次の生成までの時間を待つ
            yield return new WaitForSeconds(spawnInterval);
        }
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

    public void OnPointerClick(PointerEventData eventData)
    {
        // プレハブを生成
        GameObject spawnedPrefab = SpawnPrefab();

        StartCoroutine(MoveForward(spawnedPrefab));
    }
}
