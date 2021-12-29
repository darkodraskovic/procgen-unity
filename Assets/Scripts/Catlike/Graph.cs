using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    GameObject pointPrefab;
    [SerializeField, Range(0, 64)]
    int resolution = 32;
    [SerializeField]
    FunctionLibrary.FunctionName function;
    GameObject[] points;

    void Awake()
    {
        float step = 1f / resolution;
        Vector3 position = Vector3.zero;
        Vector3 scale = Vector3.one * step;

        points = new GameObject[resolution * resolution];

        for (int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            // Each time we finish a row we have to reset x back to zero
            if (x == resolution)
            {
                x = 0;
                // Increment z when we move on to the next row
                z++;
            }

            GameObject pointObject = points[i] = Instantiate<GameObject>(pointPrefab);
            position.x = (x * step - .5f) * 2;
            position.z = (z * step - .5f) * 2;
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
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        for (int i = 0; i < points.Length; i++)
        {
            Transform pointTransform = points[i].transform;
            Vector3 position = pointTransform.localPosition;
            position.y = f(position.x, position.z, Time.time);
            pointTransform.localPosition = position;
        }
    }
}
