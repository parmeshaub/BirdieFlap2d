using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField] private float pipeSpeed;

    private void Update() {
        MovePipe();
        DeletePipeIfExceedX();
    }

    private void MovePipe() {
        Vector3 newPosition = new Vector3(this.transform.position.x - pipeSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        this.transform.position = newPosition;
    }

    private void DeletePipeIfExceedX() {
        if(this.transform.position.x < -13) {
            Destroy(this.gameObject);
        }
    }
}
