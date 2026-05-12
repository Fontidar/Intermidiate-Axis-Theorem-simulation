using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]

public class Graficator : Graphic
{
    [SerializeField] private FloatVariable variableToGraph;

    [SerializeField] private int maxDataShown = 100;
    [SerializeField] private float minValue = 0f;
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private float lineWith = 2f;
    [SerializeField] private float timeInterval = 0.05f;

    private List<float> data = new List<float>();

    private float timer;

    // 1. Obliga a Unity a usar el material por defecto de la UI (limpia artefactos visuales)
    public override Material defaultMaterial => Canvas.GetDefaultCanvasMaterial();

    // 2. Le dice a Unity que use una textura blanca pura (evita el aura negra/sombra)
    public override Texture mainTexture => Texture2D.whiteTexture;

    private void Update()
    { 
        timer += Time.deltaTime;

        if (timer >= timeInterval)
        {
            timer = 0f;

            data.Add(variableToGraph.Value);

            while (data.Count > maxDataShown)
            {
                data.RemoveAt(0);
            }
            SetAllDirty();
        }

    }


    protected override void OnPopulateMesh(VertexHelper vh)
    {

        if (data.Count < 2) return;

        vh.Clear();
        Rect rect = rectTransform.rect;

        float withStep = rect.width / 100;
        float x = rect.xMax;

        Vector2 viejo=new Vector2(rect.xMax,0);

        for (int i = 0; i < data.Count; i++)
        {
            float normalized = Mathf.InverseLerp(minValue, maxValue, data[i]);
            float y = rect.yMin + (normalized * rect.height);

            Vector2 n = new Vector2(x, y);
            x -= withStep;

            if (i > 0) DrawLine(n, viejo, vh);
            viejo = n;
        }
    }
  
    private void DrawLine(Vector2 puntoA, Vector2 puntoB, VertexHelper vh)
    {
        Vector2 direction = (puntoB - puntoA).normalized;
        Vector2 normal = new Vector2(-direction.y, direction.x) * (lineWith * 0.5f);

        UIVertex vertex = UIVertex.simpleVert;
        vertex.color = color;

        int indexActual = vh.currentVertCount;

        vertex.position = puntoA + normal; vh.AddVert(vertex);
        vertex.position = puntoB + normal; vh.AddVert(vertex);
        vertex.position = puntoB - normal; vh.AddVert(vertex);
        vertex.position = puntoA - normal; vh.AddVert(vertex);

        vh.AddTriangle(indexActual, indexActual + 1, indexActual + 2);
        vh.AddTriangle(indexActual, indexActual + 2, indexActual + 3);
    }

}