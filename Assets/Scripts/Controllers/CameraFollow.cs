using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform target; // Drag your player here
    public Vector3 offset = new Vector3(0, 5, -10); // The distance from the player

    void LateUpdate() 
    {
        // Move the camera to the player's position plus the offset
        transform.position = target.position + offset;

        // Keep the camera pointed at the player
        transform.LookAt(target);
    }

    void HandleInput()
    {
        // Touch (mobile)
        if (Input.touchCount == 2)
        {
            // Pinch-to-zoom: cancel any active pan while two fingers are down
            _panFingerId = -1;

            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            Vector2 prevT0 = t0.position - t0.deltaPosition;
            Vector2 prevT1 = t1.position - t1.deltaPosition;

            float prevMag = (prevT0 - prevT1).magnitude;
            float currMag = (t0.position - t1.position).magnitude;
            float delta = prevMag - currMag;

            _distance = Mathf.Clamp(_distance + delta * zoomSpeed, minDistance, maxDistance);
            return;
        }

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began && _panFingerId == -1)
            {
                if (touch.position.x > Screen.width * 0.5f)
                {
                    _panFingerId = touch.fingerId;
                    _lastInputPos = touch.position;
                }
            }
            else if (touch.fingerId == _panFingerId)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    _yaw += (touch.position.x - _lastInputPos.x) * panSpeed;
                    _lastInputPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    _panFingerId = -1;
                }
            }
        }

        if (Input.touchCount > 0) return;

        // Mouse scroll wheel zoom (editor / PC)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
            _distance = Mathf.Clamp(_distance - scroll * 10f, minDistance, maxDistance);

        // Mouse right-click drag to pan
        if (Input.GetMouseButtonDown(1))
        {
            _lastInputPos = Input.mousePosition;
            _isPanning = true;
        }
        else if (Input.GetMouseButton(1) && _isPanning)
        {
            _yaw += (Input.mousePosition.x - _lastInputPos.x) * panSpeed;
            _lastInputPos = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            _isPanning = false;
        }
    }
}