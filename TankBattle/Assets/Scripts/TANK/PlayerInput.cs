using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    //camera
    [SerializeField]
    private Camera mainCamera;

    //sử dụng unityEvent
    public UnityEvent OnShoot = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();


    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        if (GameManager.instance.ispause == false)
        {
            GetBodyMovement();// tank di chuyển
            GetTurretMovement();// trục pháo di chuyển
            GetShooting();//tank bắn
        }

    }

    private void GetShooting()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            // kiểm tra xem có ai đang nghe sự kiện này hay k ?
            OnShoot?.Invoke();//gọi hàm nào đó sau khoảng tg nào đó
        }

    }

    private void GetTurretMovement()
    {
        OnMoveTurret?.Invoke(GetMousePositon());
    }


    private Vector2 GetMousePositon()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;//chỉnh cho cam gần mặt phẳng
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);//rồi zoom đến điểm cần nhìn , giúp nhìn rõ tank
        return mouseWorldPosition;
    }

    private void GetBodyMovement()
    {
        Vector2 movementVecter = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVecter.normalized);//giúp có thể di chuyển hướng chéo đc (WD Cùng lúc )
    }
}
