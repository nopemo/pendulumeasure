using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFollowingCamera : MonoBehaviour
{
  [SerializeField] Transform measure_tr; // プレイヤーのTransform
  [SerializeField] Vector3 init_camera_pos = new Vector3(0, 0, -100f); // カメラの初期位置位置
  Vector3 init_floor_pos; // 床の初期位置
  [SerializeField] GameObject flags_manager;
  [SerializeField] Transform floor_tr;
  // use prefab
  [SerializeField] private GameObject bg_prefab;
  [SerializeField] private GameObject wall_prefab;
  private Vector2 current_pos;
  private Dictionary<Vector2, GameObject> bg_dict = new Dictionary<Vector2, GameObject>();

  void Awake()
  {
    init_floor_pos = floor_tr.position;
    current_pos = AreaPosition((Vector2)measure_tr.position);
    InitBackGround();
  }
  void LateUpdate()
  {
    UpdateBackGround();
    if (flags_manager.GetComponent<TestFlags>().getFlag("detach"))
    {
      Vector3 measure_pos = measure_tr.position; // プレイヤーの位置
      Vector3 camera_pos = transform.position; // カメラの位置

      // 滑らかにプレイヤーの場所に追従
      camera_pos = Vector3.Lerp(transform.position, measure_pos + init_camera_pos, 3.0f * Time.deltaTime);

      // カメラの位置を制限
      camera_pos.y = Mathf.Max(camera_pos.y, init_camera_pos.y);
      camera_pos.z = init_camera_pos.z;
      transform.position = camera_pos;
      floor_tr.position = new Vector3(camera_pos.x, init_floor_pos.y, init_floor_pos.z);
    }
  }
  Vector2 AreaPosition(Vector2 pos)
  {
    Vector2 area_pos = new Vector2();
    area_pos.x = Mathf.Floor((pos.x + 50f) / 100f);
    area_pos.y = Mathf.Floor((pos.y + 25f) / 100f);
    return area_pos;
  }
  void UpdateBackGround()
  {
    Vector2 temp_pos = AreaPosition((Vector2)measure_tr.position);
    if (current_pos != temp_pos)
    {
      // 画面外の背景を削除
      Dictionary<Vector2, GameObject> temp_dict = new Dictionary<Vector2, GameObject>(bg_dict);
      foreach (KeyValuePair<Vector2, GameObject> pair in temp_dict)
      {
        if (Mathf.Abs(pair.Key.x - temp_pos.x) > 1 || Mathf.Abs(pair.Key.y - temp_pos.y) > 1)
        {
          Destroy(pair.Value);
          bg_dict.Remove(pair.Key);
        }
      }
      // 画面内の背景を生成
      for (int i = -1; i < 2; i++)
      {
        for (int j = -1; j < 2; j++)
        {
          Vector2 pos = new Vector2(temp_pos.x + i, temp_pos.y + j);
          if (!bg_dict.ContainsKey(pos) && pos.y >= 0)
          {
            GameObject bg;
            if (pos.y == 0)
            {
              bg = Instantiate(bg_prefab, new Vector3(pos.x * 100f, pos.y * 100f, 0), Quaternion.identity);
              bg.GetComponent<TestBG>().ChangeColorUsingOddEven(pos);
            }
            else
            {
              bg = Instantiate(wall_prefab, new Vector3(pos.x * 100f, pos.y * 100f + 25f, 0), Quaternion.identity);
              bg.GetComponent<TestBG>().ChangeColorUsingOddEven(pos);
            }
            bg_dict.Add(pos, bg);
          }
        }
      }
      current_pos = temp_pos;
    }
  }
  void InitBackGround()
  {
    Vector2 temp_pos = AreaPosition((Vector2)measure_tr.position);
    // 画面内の背景を生成
    for (int i = -1; i < 2; i++)
    {
      for (int j = -1; j < 2; j++)
      {
        Vector2 pos = new Vector2(temp_pos.x + i, temp_pos.y + j);
        if (!bg_dict.ContainsKey(pos) && pos.y >= 0)
        {
          GameObject bg;
          if (pos.y == 0)
          {
            bg = Instantiate(bg_prefab, new Vector3(pos.x * 100f, pos.y * 100f, 0), Quaternion.identity);
            bg.GetComponent<TestBG>().ChangeColorUsingOddEven(pos);
          }
          else
          {
            bg = Instantiate(wall_prefab, new Vector3(pos.x * 100f, pos.y * 100f + 25f, 0), Quaternion.identity);
            bg.GetComponent<TestBG>().ChangeColorUsingOddEven(pos);
          }
          bg_dict.Add(pos, bg);
        }
      }
    }
    current_pos = temp_pos;
  }
}
