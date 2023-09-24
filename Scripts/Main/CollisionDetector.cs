using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
  // OnCollisionEnterは衝突が発生した際に呼び出されます
  [SerializeField] private GameObject flags_manager;
  [SerializeField] private GameObject spiral;
  [SerializeField] private GameObject window_title;
  [SerializeField] private GameObject window_description;
  void Update()
  {
    if (flags_manager.GetComponent<TestFlags>().getFlagString("game_section") == "result")
    {

    }
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    // 衝突した物体の情報を取得
    GameObject otherObject = collision.gameObject;
    Debug.Log("Collision detected with " + otherObject.name);

    // 衝突した物体に特定のタグがある場合の処理
    if (otherObject.CompareTag("Floor"))
    {
      // 衝突時に実行したい処理をここに書く
      flags_manager.GetComponent<TestFlags>().setFlagString("game_section", "result");
      int score = (int)GetComponent<Transform>().position.x * 4;
      GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
      spiral.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
      GetComponent<CollisionDetector>().enabled = false;
      window_title.GetComponent<Text>().text = "タップしてリセット";
      window_description.GetComponent<Text>().text = "距離:" + score.ToString() + "cm";
      // naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
      // 0.5秒後にnaichilab.RankingLoader.Instance.SendScoreAndShowRanking(score)を実行する
      Invoke("ShowRanking", 0.5f);
    }
  }
  void ShowRanking()
  {
    naichilab.RankingLoader.Instance.SendScoreAndShowRanking((int)GetComponent<Transform>().position.x * 4);
  }
}
