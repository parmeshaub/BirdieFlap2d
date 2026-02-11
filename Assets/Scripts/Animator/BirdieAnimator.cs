using UnityEngine;

public class BirdieAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string triggerGameStart = "GameStart";
    private string triggerFlap = "Flap";
    private string triggerDeath = "Death";    

    private void Start() {
        
    }

    private void OnEnable() {
        GameManager.OnGameStart += StartGame;
        BirdieController.OnJump += JumpAnimation;
        BirdieController.OnPlayerDeath += DeathAnimation;
    }
    private void OnDisable() {
        GameManager.OnGameStart -= StartGame;
        BirdieController.OnJump -= JumpAnimation;
        BirdieController.OnPlayerDeath -= DeathAnimation;
    }

    private void StartGame() {
        animator.SetTrigger(triggerGameStart);
    }
    
    private void JumpAnimation() {
        animator.SetTrigger(triggerFlap);
    }

    private void DeathAnimation() {
        animator.SetTrigger(triggerDeath);
    }
}
