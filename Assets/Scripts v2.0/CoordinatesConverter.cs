using UnityEngine;

public class CoordinatesConverter : MonoBehaviour
{
    public static bool LegalCheck(ChessCoord coordinates)
    {
        if(LetterCheck(coordinates.coord) && (coordinates.coord.Length == 2))
        {
            return true;
        }
        return false;
    }

    public static bool LetterCheck(string test)
    {
        if ((test[0] != 'a') && (test[0] != 'b') && (test[0] != 'c') && (test[0] != 'd') && (test[0] != 'e') && (test[0] != 'f') && (test[0] != 'g') && (test[0] != 'h'))
        {
            return false;
        }
        return true;
    }

    public static Vector3 ChessToVector(ChessCoord coordinates)
    {
        int horizontalScale = 0;
        int verticalScale = (int)coordinates.coord[1];
        switch(coordinates.coord[0])
        {
            case 'a':
                horizontalScale = 1;
                break;
            case 'b':
                horizontalScale = 2;
                break;
            case 'c':
                horizontalScale = 3;
                break;
            case 'd':
                horizontalScale = 4;
                break;
            case 'e':
                horizontalScale = 5;
                break;
            case 'f':
                horizontalScale = 6;
                break;
            case 'g':
                horizontalScale = 7;
                break;
            case 'h':
                horizontalScale = 8;
                break;
        }
        Vector3 createdVector = new Vector3(horizontalScale, 0f, verticalScale);
        return createdVector;
    }

    public static ChessCoord VectorToChess(Vector3 input)
    {
        string firstChar = "";
        switch(input.x)
        {
            case 1:
                firstChar = "a";
                break;
            case 2:
                firstChar = "b";
                break;
            case 3:
                firstChar = "c";
                break;
            case 4:
                firstChar = "d";
                break;
            case 5:
                firstChar = "e";
                break;
            case 6:
                firstChar = "f";
                break;
            case 7:
                firstChar = "g";
                break;
            case 8:
                firstChar = "h";
                break;
        }
        string coords = firstChar + input.z.ToString();
        return new ChessCoord(coords);
    }
}
