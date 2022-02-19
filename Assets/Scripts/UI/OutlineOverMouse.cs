using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineOverMouse : MonoBehaviour
{
    private Outline outline;

    private void OutlineOnMouse()
    {
        outline.OutlineColor = Color.white;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }

    void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void OnMouseOver()
    {
        OutlineOnMouse();
    }

    private void OnMouseExit()
    {
        outline.OutlineMode = Outline.Mode.SilhouetteOnly;
    }
}
