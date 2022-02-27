using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Rotation : MonoBehaviour
{
    public float rotSpeed = 1f;

    private Transform parent;
    float cubeHalf = 0.5f;

    bool turning = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            TurnToX(1);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            TurnToX(-1);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            TurnToZ(1);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            TurnToZ(-1);
        }
    }

    void TurnToX(int right)
    {
        if (turning) return;
        turning = true;
        DestroyParent();
        GameObject go = new GameObject("Pivot_parent");
        parent = go.transform;
        parent.position = new Vector3(transform.position.x + cubeHalf * right, transform.position.y + -cubeHalf, transform.position.z);
        this.transform.SetParent(parent);
        parent.DORotate(new Vector3(0f, 0f, -90f * right), 0.3f)
            .SetEase(Ease.Linear)
            .OnComplete(() => turning = false);
    }
    void TurnToZ(int forward)
    {
        if (turning) return;
        turning = true;
        DestroyParent();
        GameObject go = new GameObject("Pivot_parent");
        parent = go.transform;
        parent.position = new Vector3(transform.position.x, transform.position.y + -cubeHalf, transform.position.z + cubeHalf * forward);
        this.transform.SetParent(parent);
        parent.DORotate(new Vector3(90f * forward, 0f, 0f), 0.3f)
            .SetEase(Ease.Linear)
            .OnComplete(() => turning = false);
    }

    void DestroyParent()
    {
        if (parent)
        {
            this.transform.SetParent(null);
            Destroy(parent.gameObject);
        }
    }
}
