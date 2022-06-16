using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    public LineRenderer Rope;

    public Transform A;
    public Transform B;

    public int Segments=10;

    public float Length = 10f;

    void Update()
    {

        DrawRope();
    }
    private void DrawRope() 
    {
        Rope.positionCount = 2;
        Rope.SetPosition(0, A.position);
        Rope.SetPosition(1, B.position);

        float interpolant = Vector3.Distance(A.position, B.position) / Length;

        float offset = Mathf.Lerp(Length / 2f, 0f, interpolant);

        Vector3 aDown = A.position + Vector3.down * offset;
        Vector3 bDown = B.position + Vector3.down * offset;

        Rope.positionCount = Segments + 1;

        for (int i = 0; i < Segments; i++)
        {
            Rope.SetPosition(i, Bezier.GetPoint(A.position, aDown, bDown, B.position, (float)i / Segments));
        }
    }
}
