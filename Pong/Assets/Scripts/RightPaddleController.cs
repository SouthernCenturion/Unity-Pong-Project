using UnityEngine;
using Unity.Netcode;

public class RightPaddleController : PaddleController
{
    protected override float GetInputAxis()
    {
        if (IsOwner)
        {
            return Input.GetAxis("RightPaddle");
        }
    }
}