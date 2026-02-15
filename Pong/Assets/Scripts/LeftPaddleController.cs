using UnityEngine;
using Unity.Netcode;

public class LeftPaddleController : PaddleController
{
    protected override float GetInputAxis()
    {
        if (IsOwner)
        {
            return Input.GetAxis("LeftPaddle");
        }
    }
}