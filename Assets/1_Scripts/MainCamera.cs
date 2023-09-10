using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject Target;               // 카메라가 따라다닐 타겟

    private float offsetX = 0.0f;
    private float offsetY = 0.0f;
    private float offsetZ = -10.0f;

    public float CameraSpeed = 10.0f;
    Vector3 TargetPos;

    void FixedUpdate()
    {
        // 타겟의 x, y, z 좌표에 카메라의 좌표를 더하여 카메라의 위치를 결정
        TargetPos = new Vector3(
            Target.transform.position.x + offsetX,
            Target.transform.position.y + offsetY,
            Target.transform.position.z + offsetZ
            );

        // 카메라의 움직임을 부드럽게 하는 함수(Lerp)
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
    }
}
