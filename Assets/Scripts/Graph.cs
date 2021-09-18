using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    GameObject pointPrefab;
    [SerializeField, Range(0, 50)]
    int resolution = 32;
    GameObject[] points;

    void Awake()
    {
        float step = 1f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;

        points = new GameObject[resolution];

        for (int i = 0; i < resolution; i++)
        {
            GameObject pointObject = points[i] = Instantiate<GameObject>(pointPrefab);
            position.x = (i * step - .5f) * 2;
            // position.y = Mathf.Pow(position.x, 3) * 4;
            pointObject.transform.localScale = scale;
            pointObject.transform.localPosition = position;
            pointObject.transform.SetParent(transform, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform pointTransform = points[i].transform;
            Vector3 position = pointTransform.localPosition;
            // position.y = Mathf.Pow(position.x, 3);
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            pointTransform.localPosition = position;
        }
    }
}
