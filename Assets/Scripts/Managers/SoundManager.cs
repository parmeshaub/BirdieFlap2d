using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coinAudio;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip bumpSound;

    private void OnEnable() {
        PipeScript.OnScorePoint += PlayCoinSound;
        BirdieController.OnPlayerDeath += PlayDeathSound;
        BirdieController.OnJump += PlayJumpSound;
    }

    private void OnDisable() {
        PipeScript.OnScorePoint -= PlayCoinSound;
        BirdieController.OnPlayerDeath -= PlayDeathSound;
        BirdieController.OnJump -= PlayJumpSound;
    }

    private void PlayCoinSound() {
        audioSource.PlayOneShot(coinAudio);
    }

    private void PlayDeathSound() {
        audioSource.PlayOneShot(deathSound);
        audioSource.PlayOneShot(bumpSound);
    }

    private void PlayJumpSound() {
        audioSource.PlayOneShot(jumpSound);
    }
}
