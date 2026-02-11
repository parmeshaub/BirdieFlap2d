using UnityEngine;

public class PointAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private string triggerPoint = "GainPoint";

    private void OnEnable() {
        PipeScript.OnScorePoint += PlayPointAnimation;
    }
    private void OnDisable() {
        PipeScript.OnScorePoint -= PlayPointAnimation;
    }

    private void PlayPointAnimation() {
        animator.SetTrigger(triggerPoint);
    }
}
