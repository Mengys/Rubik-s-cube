using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] private GameObject _cubePiecePref;
    [SerializeField] private float _rotateSpeed = 3f;
    private int _size = 3;

    private List<GameObject> _cubePieces;
    private bool _canRotate;

    private enum RotationDirection
    {
        Clockwise,
        Counterclockwise,
    }

    // for 3x3x3 rotations only
    private List<GameObject> _blueSide
    {
        get
        {
            return _cubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == 1);
        }
    }
    private List<GameObject> _greenSide
    {
        get
        {
            return _cubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.y) == -1);
        }
    }
    private List<GameObject> _redSide
    {
        get
        {
            return _cubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == 1);
        }
    }
    private List<GameObject> _orangeSide
    {
        get
        {
            return _cubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.x) == -1);
        }
    }
    private List<GameObject> _yellowSide
    {
        get
        {
            return _cubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == 1);
        }
    }
    private List<GameObject> _whiteSide
    {
        get
        {
            return _cubePieces.FindAll(x => Mathf.Round(x.transform.localPosition.z) == -1);
        }
    }

    private void Start()
    {
        CreateCube();
        _canRotate = true;
    }

    private void Update()
    {
        if(_canRotate)
            CheckInput();
    }

    private void CreateCube()
    {
        _cubePieces = new List<GameObject>();
        for (int x = 0; x < _size; x++)
            for (int y = 0; y < _size; y++)
                for (int z = 0; z < _size; z++)
                {
                    GameObject piece = Instantiate(_cubePiecePref, transform, false);
                    _cubePieces.Add(piece);
                    piece.transform.localPosition = new Vector3(x - (_size - 1) / 2f, y - (_size - 1) / 2f, z - (_size - 1) / 2f);
                    piece.GetComponent<CubePiece>().EnablePlanes(_size);
                }
    }

    private void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Rotate(_blueSide, RotationDirection.Counterclockwise));
            else
                StartCoroutine(Rotate(_blueSide, RotationDirection.Clockwise));
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {   
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Rotate(_greenSide, RotationDirection.Clockwise));
            else
                StartCoroutine(Rotate(_greenSide, RotationDirection.Counterclockwise));
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Rotate(_redSide, RotationDirection.Counterclockwise));
            else
                StartCoroutine(Rotate(_redSide, RotationDirection.Clockwise));
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Rotate(_orangeSide, RotationDirection.Clockwise));
            else
                StartCoroutine(Rotate(_orangeSide, RotationDirection.Counterclockwise));
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {   
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Rotate(_yellowSide, RotationDirection.Counterclockwise));
            else
                StartCoroutine(Rotate(_yellowSide, RotationDirection.Clockwise));
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Rotate(_whiteSide, RotationDirection.Clockwise));
            else
                StartCoroutine(Rotate(_whiteSide, RotationDirection.Counterclockwise));
        }
    }

    IEnumerator Rotate(List<GameObject> pieces, RotationDirection rotationDirection)
    {
        _canRotate = false;
        float angle = 0f;
        
        GameObject centerPiece = null;
        foreach(GameObject piece in pieces)
        {
            if (piece.GetComponent<CubePiece>()._piecePosition == CubePiece.PiecePosition.Center)
                centerPiece = piece;
        }

        while(angle < 90f)
        {
            float rotationAngle = angle + _rotateSpeed > 90 ? 90 - angle : _rotateSpeed;
            foreach (GameObject piece in pieces)
            {
                piece.transform.RotateAround(Vector3.zero, centerPiece.transform.position * (((int)rotationDirection) - 0.5f) * 2, rotationAngle);
            }

            angle += rotationAngle;
            yield return null;
        }
        _canRotate = true;
    }
}
