using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    //Array or List of Cells
    public static Cell[,] board = new Cell[7,7];
    public static List<Figure> whiteFigures = new List<Figure>();
    public static List<Figure> blackFigures = new List<Figure>();

    public static void Move(Cell first, Cell second)
    {
        if(first.figure == null)
        {
            return;
        }
        if(second.figure == null)
        {
            if(DriverV2.AnimationON)
            {
                //Implement transform.Move()
            }
            else
            {
                first.figure.transform.position = second.transform.position;
                second.figure = first.figure;
                first.figure = null;
            }
        }
        else if(second.figure.transform.GetComponent<MeshRenderer>().material.color != first.figure.transform.GetComponent<MeshRenderer>().material.color)
        {
            if(DriverV2.AnimationON)
            {
                //Implement transform.Move()
            }
            else
            {
                second.figure.Die();
                first.figure.transform.position = second.transform.position;
                second.figure = first.figure;
                first.figure = null;
            }
        }//else if(checked)
        else
        {
            DriverV2.selected = null;
            return;
        }
        DriverV2.selected = null;
    }
}
