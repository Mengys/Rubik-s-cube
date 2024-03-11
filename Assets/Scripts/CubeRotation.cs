using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 0.1f;

    private Vector2 _point1, _point2;

    void Update()
    {
        CubeRotate();
    }

    private void CubeRotate()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _point1 = Input.mousePosition;
            Cursor.visible = false;
        }

        if (Input.GetMouseButton(2))
        {
            _point2 = Input.mousePosition;

            float dx = (_point2.x - _point1.x) * _rotateSpeed;
            float dy = (_point2.y - _point1.y) * _rotateSpeed;

            // if (transform.rotation.eulerAngles.x < 30f || transform.rotation.eulerAngles.x > 330f)
            // {
            //     transform.RotateAround(Vector3.zero, transform.up, -dx);
            // }

            // if (transform.rotation.eulerAngles.y < 30f || transform.rotation.eulerAngles.y > 330f)
            // {
            //     transform.RotateAround(Vector3.zero, transform.right, dy);
            // }


            float angle1 = 360f;
            Vector3 verticalRotation = Vector3.up;
            if (Vector3.Angle(transform.up, Vector3.up) < angle1)
            {
                angle1 = Vector3.Angle(transform.up, Vector3.up);
                verticalRotation = transform.up;
            }
            if (Vector3.Angle(-transform.up, Vector3.up) < angle1)
            {
                angle1 = Vector3.Angle(-transform.up, Vector3.up);
                verticalRotation = -transform.up;
            }
            if (Vector3.Angle(transform.forward, Vector3.up) < angle1)
            {
                angle1 = Vector3.Angle(transform.forward, Vector3.up);
                verticalRotation = transform.forward;
            }
            if (Vector3.Angle(-transform.forward, Vector3.up) < angle1)
            {
                angle1 = Vector3.Angle(-transform.forward, Vector3.up);
                verticalRotation = -transform.forward;
            }
            if (Vector3.Angle(transform.right, Vector3.up) < angle1)
            {
                angle1 = Vector3.Angle(transform.right, Vector3.up);
                verticalRotation = transform.right;
            }
            if (Vector3.Angle(-transform.right, Vector3.up) < angle1)
            {
                angle1 = Vector3.Angle(-transform.right, Vector3.up);
                verticalRotation = -transform.right;
            }

            float angle2 = 360f;
            Vector3 horizontalRotation = Vector3.right;
            if (Vector3.Angle(transform.up, Vector3.right) < angle2)
            {
                angle2 = Vector3.Angle(transform.up, Vector3.right);
                horizontalRotation = transform.up;
            }
            if (Vector3.Angle(-transform.up, Vector3.right) < angle2)
            {
                angle2 = Vector3.Angle(-transform.up, Vector3.right);
                horizontalRotation = -transform.up;
            }
            if (Vector3.Angle(transform.forward, Vector3.right) < angle2)
            {
                angle2 = Vector3.Angle(transform.forward, Vector3.right);
                horizontalRotation = transform.forward;
            }
            if (Vector3.Angle(-transform.forward, Vector3.right) < angle2)
            {
                angle2 = Vector3.Angle(-transform.forward, Vector3.right);
                horizontalRotation = -transform.forward;
            }
            if (Vector3.Angle(transform.right, Vector3.right) < angle2)
            {
                angle2 = Vector3.Angle(transform.right, Vector3.right);
                horizontalRotation = transform.right;
            }
            if (Vector3.Angle(-transform.right, Vector3.right) < angle2)
            {
                angle2 = Vector3.Angle(-transform.right, Vector3.right);
                horizontalRotation = -transform.right;
            }

            transform.RotateAround(Vector3.zero, verticalRotation, -dx);
            transform.RotateAround(Vector3.zero, horizontalRotation, dy);
        }

        _point1 = _point2;

        if (Input.GetMouseButtonUp(2))
        {
            Cursor.visible = true;
        }
    }
}
