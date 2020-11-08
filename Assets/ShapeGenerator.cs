using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    [SerializeField] float symmetry = 1.0f;

    [SerializeField] float n1;
    [SerializeField] float n2;
    [SerializeField] float n3;

    [SerializeField] float xScale = 1.0f;
    [SerializeField] float yScale = 1.0f;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 360;

        InvokeRepeating("RecalculateSuperShape", 1.0f, 0.5f);
    }

    void RecalculateSuperShape()
    {
        int index = 0;
        for (float angle = 0.0f; angle < 360.0f; angle += 1.0f)
        {
            Vector3 v = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

            v *= SuperShapeValue(angle * Mathf.Deg2Rad);

            lineRenderer.SetPosition(index, v);
            index++;
        }
    }

    float SuperShapeValue(float _angle)
    {
        return Mathf.Pow(
            Mathf.Pow(Mathf.Abs((1 / xScale) * Mathf.Cos( ( symmetry / 4.0f ) * _angle ) ), n2) +
            Mathf.Pow(Mathf.Abs((1 / yScale) * Mathf.Sin( ( symmetry / 4.0f ) * _angle ) ), n3),
                1 / n1);
    }

}