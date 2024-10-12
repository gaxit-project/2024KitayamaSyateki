using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : MonoBehaviour
{
    // 色を変更する対象のオブジェクトのマテリアル
    private Renderer objRenderer;

    // 接触した際に変更する色
    public Color newColor = Color.red;
    public Color ato = Color.red;

    void Start()
    {
        // このオブジェクトのRendererを取得
        objRenderer = GetComponent<Renderer>();
        objRenderer.material.color = newColor;
    }

    void OnCollisionEnter(Collision collision)
    {
        // 他のオブジェクトに接触したときに色を変更
        Debug.Log("衝突");
        objRenderer.material.color = ato;

        // 5秒後にシーンをリロードする
        //Invoke("ReloadScene", 5f);
    }

    // シーンをリロードするメソッド
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
