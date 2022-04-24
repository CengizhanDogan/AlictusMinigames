using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private ControllerManager controllerManager;
    private RagdollController ragdollController;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        controllerManager = GetComponentInChildren<ControllerManager>();
        ragdollController = GetComponentInChildren<RagdollController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Destroy(playerMovement.rb);
            playerMovement.forwardSpeed = 1f;
            ragdollController.RagdollControl(true);
            controllerManager.EnableControllers();
        }
    }
}
