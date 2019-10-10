using UnityEngine;

public class DriverV2 : MonoBehaviour
{
    //prefabs list;
    public Transform Pawn;
    public Transform Rook;
    public Transform Knight;
    public Transform Bishop;
    public Transform Queen;
    public Transform King;
    public Transform Quad;

    public static Cell selected = null;

    public static bool AnimationON = false;
    public static bool whiteTurn = true;

    Vector3 scaleVector = new Vector3(0.2f, 0.2f, 0.2f);

    void Spawn(Transform prefab, Color color, Vector3 position, FigureType type)
    {
        Transform instance = Instantiate(prefab, position, Quaternion.identity, this.transform);
        instance.localScale = scaleVector;
        instance.gameObject.GetComponent<MeshRenderer>().material.color = color;
        Figure addedF = instance.gameObject.AddComponent<Figure>();
        addedF.AssignTypeBehaviour(type);
        //Add to BoardManager
        BoardManager.board[(int)position.x, (int)position.z].figure = addedF;
        if (color == Color.black)
        {
            instance.localRotation = Quaternion.Euler(0f, 180f, 0f);
            BoardManager.blackFigures.Add(addedF);
        }
        else
        {
            BoardManager.whiteFigures.Add(addedF);
        }
    }

    void Spawn(Transform prefab, Color color, ChessCoord position, FigureType type)
    {
        Transform instance = Instantiate(prefab, CoordinatesConverter.ChessToVector(position), Quaternion.identity, this.transform);
        instance.localScale = scaleVector;
        instance.gameObject.GetComponent<MeshRenderer>().material.color = color;
        Figure addedF = instance.gameObject.AddComponent<Figure>();
        addedF.AssignTypeBehaviour(type);
        //Add to BoardManager
        BoardManager.board[(int)CoordinatesConverter.ChessToVector(position).x, (int)CoordinatesConverter.ChessToVector(position).z].figure = addedF;
        if (color == Color.black)
        {
            instance.localRotation = Quaternion.Euler(0f, 180f, 0f);
            BoardManager.blackFigures.Add(addedF);
        }
        else
        {
            BoardManager.whiteFigures.Add(addedF);
        }
    }

    void Spawn(Transform quad, Color color, Vector3 position)
    {
        //SpawnQuad
        Transform instance = Instantiate(quad, position, Quaternion.Euler(90f, 0f, 0f), this.transform);
        instance.gameObject.GetComponent<MeshRenderer>().material.color = color;
        //Add Cell Item
        instance.gameObject.AddComponent<Cell>();
        //Add to BoardManager
        BoardManager.board[(int)position.x, (int)position.y] = instance.transform.GetComponent<Cell>();
    }

    void SpawnPieces()
    {
        //White & Black Pawns
        for(int i=1; i<9; i++)
        {
            Spawn(Pawn, Color.white, new Vector3(i, 0f, 2f), FigureType.Pawn);
            Spawn(Pawn, Color.black, new Vector3(i, 0f, 7f), FigureType.Pawn);
        }
        //White & Black Rooks
        Spawn(Rook, Color.white, new Vector3(1f, 0f, 1f), FigureType.Rook);
        Spawn(Rook, Color.white, new Vector3(8f, 0f, 1f), FigureType.Rook);
        Spawn(Rook, Color.black, new Vector3(1f, 0f, 8f), FigureType.Rook);
        Spawn(Rook, Color.black, new Vector3(8f, 0f, 8f), FigureType.Rook);
        //White & Black Knights
        Spawn(Knight, Color.white, new Vector3(2f, 0f, 1f), FigureType.Knight);
        Spawn(Knight, Color.white, new Vector3(7f, 0f, 1f), FigureType.Knight);
        Spawn(Knight, Color.black, new Vector3(2f, 0f, 8f), FigureType.Knight);
        Spawn(Knight, Color.black, new Vector3(7f, 0f, 8f), FigureType.Knight);
        //White & Black Bishops
        Spawn(Bishop, Color.white, new Vector3(3f, 0f, 1f), FigureType.Bishop);
        Spawn(Bishop, Color.white, new Vector3(6f, 0f, 1f), FigureType.Bishop);
        Spawn(Bishop, Color.black, new Vector3(3f, 0f, 8f), FigureType.Bishop);
        Spawn(Bishop, Color.black, new Vector3(6f, 0f, 8f), FigureType.Bishop);
        //White & Black Queens
        Spawn(Queen, Color.white, new Vector3(4f, 0f, 1f), FigureType.Queen);
        Spawn(Queen, Color.black, new Vector3(4f, 0f, 8f), FigureType.Queen);
        //White & Black Kings
        Spawn(King, Color.white, new Vector3(5f, 0f, 1f), FigureType.King);
        Spawn(King, Color.black, new Vector3(5f, 0f, 8f), FigureType.King);
    }

    void SpawnCells()
    {
        bool toggle = true;
        for(int i = 1; i < 9; i++)
        {
            for (int j = 1; j < 9; j++)
            {
                if(toggle)
                {
                    Spawn(Quad, Color.black, new Vector3(i, 0, j));
                }
                else
                {
                    Spawn(Quad, Color.white, new Vector3(i, 0, j));
                }
                toggle = !toggle;
            }
            toggle = !toggle;
        }
    }

    private void Start()
    {
        SpawnCells();
        SpawnPieces();
    }
}
