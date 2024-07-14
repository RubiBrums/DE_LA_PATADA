using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConejoNPC : MonoBehaviour
{
    public Animator Conejo;
    public GameObject player; // Referencia al objeto del jugador
    private CharacterController playerController; // Referencia al script del controlador del jugador
    private Rigidbody2D playerRigidbody; // Referencia al Rigidbody2D del jugador
    private Animator playerAnimator; // Referencia al Animator del jugador
    private int playerVisitCount = 0;
    private bool isInTrigger = false;
    private bool isDialogueActive = false;
    private bool hasTriggeredFinalDialogue = false;

    private void Start()
    {
        Conejo = GetComponent<Animator>();
        playerController = player.GetComponent<CharacterController>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E) && isDialogueActive)
        {
            playerVisitCount++;
            HandleDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = true;

            if (playerVisitCount == 0 || playerVisitCount == 4)
            {
                playerVisitCount++;
                HandleDialogue();
            }
            else if (playerVisitCount >= 4 && hasTriggeredFinalDialogue)
            {
                HandleDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInTrigger = false;
            isDialogueActive = false;
            Conejo.SetTrigger("Tremble");

            if (playerVisitCount >= 4)
            {
                hasTriggeredFinalDialogue = true;
                playerController.enabled = true; // Permite que el jugador se mueva nuevamente
            }
        }
    }

    private void HandleDialogue()
    {
        switch (playerVisitCount)
        {
            case 1:
                StartDialogue("Dialogo_01");
                break;
            case 2:
                StartDialogue("Dialogo_02");
                break;
            case 3:
                StartDialogue("Dialogo_03");
                break;
            case 4:
                StartDialogue("Dialogo_04");
                break;
            case 5:
                StartDialogue("Dialogo_05");
                break;
            default:
                Conejo.SetTrigger("Tremble");
                break;
        }
    }

    private void StartDialogue(string triggerName)
    {
        Conejo.SetTrigger(triggerName);
        isDialogueActive = true;

        if (playerVisitCount == 1)
        {
            // Restringe el movimiento del jugador y detén su velocidad
            playerController.enabled = false;
            playerRigidbody.velocity = Vector2.zero; // Detén el movimiento del jugador
            playerAnimator.SetBool("IsWalking", false); // Detén la animación de caminar
        }
        else if (playerVisitCount == 4)
        {
            // Habilita el movimiento del jugador después del cuarto diálogo
            playerController.enabled = true;
            isDialogueActive = false;
        }
    }
}
