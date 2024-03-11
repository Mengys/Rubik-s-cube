using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePiece : MonoBehaviour
{
    [SerializeField] private GameObject _bluePlane, _greenPlane, _redPlane, _orangePlane, _whitePlane, _yellowPlane;

    public enum PiecePosition{
        Core,
        Center,
        Edge,
        Corner,
    }

    public PiecePosition _piecePosition;
    
    public void EnablePlanes(int cubeSize)
    {
        int counter = 0;
        Vector3 localPosition = transform.localPosition;
        if (localPosition.x == (cubeSize - 1) / 2f){
            _redPlane.SetActive(true);
            counter++;
        }
        else if (localPosition.x == -(cubeSize - 1) / 2f){
            _orangePlane.SetActive(true);
            counter++;
        }
            
        if (localPosition.y == (cubeSize - 1) / 2f){
            counter++;
            _bluePlane.SetActive(true);
        }
            
        else if (localPosition.y == -(cubeSize - 1) / 2f){
            counter++;
            _greenPlane.SetActive(true);
        }
            
        if (localPosition.z == (cubeSize - 1) / 2f){
            counter++;
            _yellowPlane.SetActive(true);
        }
            
        else if (localPosition.z == -(cubeSize - 1) / 2f){
            counter++;
            _whitePlane.SetActive(true);
        }
        
        if (counter == 3)
            _piecePosition = PiecePosition.Corner;
        else if(counter == 2)
            _piecePosition = PiecePosition.Edge;
        else if(counter == 1)
            _piecePosition = PiecePosition.Center;
        else _piecePosition = PiecePosition.Core;
    }
}
