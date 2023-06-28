using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private UIcontroller _UIController;
    public bool isSwipeToMainMenu;
    public bool isSwipeToPreviousScene;
    [SerializeField] RectTransform scrollPanelRect;


    private void Awake()
    {
        _UIController = GameObject.Find("GameManager").GetComponent<UIcontroller>();
    }
    private void Update()
    {
        SwipeTomainMenu();
        SwipeTopreviousScene();
    }

    // ����� ��� �������� � ������� ����    
    void SwipeTomainMenu()
    {
        if (Input.touchCount > 0 && isSwipeToMainMenu == true)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - touchStartPosition;

                if (swipeDelta.x > 0f) // ��������� ����� ������
                {
                    UnityEngine.Debug.Log("swipping");
                    _UIController.ReturnToMainMenu();
                }
            }
        }
    }


    // ����� ��� �������� �� ���������� �����
    void SwipeTopreviousScene()
    {
        if (Input.touchCount > 0 && isSwipeToPreviousScene == true)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipeDelta = touch.position - touchStartPosition;

                if (swipeDelta.x > 0f) // ��������� ����� ������
                {
                    _UIController.ReturnToPreviousScene();
                }
            }
        }
    }
}
