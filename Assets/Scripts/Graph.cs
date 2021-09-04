using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    [SerializeField, Range(0, 50)]
    int resolution = 10;

    void Awake()
    {
        float step = 1f / resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = i * step - .5f;
            position.y = position.x * position.x;
            point.localScale = Vector3.one * step;
            point.localPosition = position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
