using UnityEngine;

public class FlashAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string triggerDeath = "OnDeath";

    private void OnEnable() {
        BirdieController.OnPlayerDeath += PlayFlash;
    }
    private void OnDisable() {
        BirdieController.OnPlayerDeath -= PlayFlash;
    }

    private void PlayFlash() {
        animator.SetTrigger(triggerDeath);
    }
}
