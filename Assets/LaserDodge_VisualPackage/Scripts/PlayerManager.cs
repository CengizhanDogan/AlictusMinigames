using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private ControllerManager controllerManager;
    private RagdollController ragdollController;
    private void Start()
    {
        controllerManager = GetComponentInChildren<ControllerManager>();
        ragdollController = GetComponentInChildren<RagdollController>();
    }
    public void StartControl(PlayerMovement _playerMovement)
    {
        _playerMovement.forwardSpeed = 1f;
        ragdollController.RagdollControl(true);
        controllerManager.EnableControllers();
    }
    public void StopControl(PlayerMovement _playerMovement)
    {
        _playerMovement.forwardSpeed = 3f;
        //ragdollController.ResetTransform();
        ragdollController.RagdollControl(false);
        controllerManager.DisableControllers();
    }
}
