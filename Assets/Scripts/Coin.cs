using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }


        if(collider.gameObject.name != "Player") {
            return;
        }

        GameManager.inst.IcrementScore();
        
        Destroy(gameObject);
    }
}
