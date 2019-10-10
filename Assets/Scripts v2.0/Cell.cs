using UnityEngine;

public class Cell : MonoBehaviour
{
    Color test = Color.cyan;
    Color startColor;

    public Figure figure = null;

    private void OnMouseDown()
    {
        if (DriverV2.selected != null)
        {
            DriverV2.selected.ReleaseColor();
            BoardManager.Move(DriverV2.selected, this);
        }
        DriverV2.selected = this;
        MeshRenderer mr = GetComponent<MeshRenderer>();
        startColor = mr.material.color;
        mr.material.color = test;
    }

    public void ReleaseColor()
    {
        GetComponent<MeshRenderer>().material.color = startColor;
    }
}
