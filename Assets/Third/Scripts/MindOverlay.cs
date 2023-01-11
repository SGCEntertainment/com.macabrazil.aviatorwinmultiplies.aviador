using UnityEngine;

public class MindOverlay : MonoBehaviour
{
    const float pointSpeed = 450.0f;

    Transform Point;
    Transform x0,x1;

    private void Start() => CacheComponents();
    private void Update() => MovePoint();

    void CacheComponents()
    {
        x0 = GameObject.Find("x0").transform;
        x1 = GameObject.Find("x1").transform;
        Point = GameObject.Find("point").transform;

        Point.parent.gameObject.SetActive(false);
    }

    private void MovePoint()
    {
        if(!Point.gameObject.activeInHierarchy)
        {
            return;
        }

        Point.Translate(pointSpeed * Time.deltaTime * Vector2.right);
        if (Point.position.x > x1.position.x)
        {
            Point.position = new Vector2(x0.position.x, Point.position.y);
        }
    }
}