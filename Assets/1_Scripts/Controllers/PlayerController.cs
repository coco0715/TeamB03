using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallOnMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallOnLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnFire" + value.ToString());
    }

    //CallOn..Event() 빨간줄 오류떠서 추가한 코드입니다 .. 왜 추가하는지는 이해 못했습니다 ,,필요없거나 틀렸다면 말씀부탁드립니다 (-하림 )
    private void CallOnMoveEvent(Vector2 moveInput)
    {
        // 이동 속도를 설정합니다.
        float moveSpeed = 5.0f;

        // 움직임 벡터에 속도를 곱해 이동 벡터를 생성합니다.
        Vector3 moveDirection = new Vector3(moveInput.x, 0.0f, moveInput.y) * moveSpeed * Time.deltaTime;

        // 현재 위치에 이동 벡터를 더합니다.
        transform.Translate(moveDirection);
    }

    private void CallOnLookEvent(Vector2 newAim)
    {
        // 시선 각도를 계산합니다.
        float lookAngle = Mathf.Atan2(newAim.y, newAim.x) * Mathf.Rad2Deg;

        // 캐릭터의 회전을 시선 각도로 설정합니다.
        transform.rotation = Quaternion.Euler(0, lookAngle, 0);
    }
}
