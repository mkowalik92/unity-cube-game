using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public PlayerMovement movement;
    public GameManager gameManager;

    void OnCollisionEnter(Collision collisionInfo) {
        //Debug.Log(collisionInfo.collider.name.Length);
        if (collisionInfo.collider.tag == "Obstacle") {
            Debug.Log("We hit an obstacle!");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
