using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        CollectObject(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectObject(other.gameObject);
    }

    private void CollectObject(GameObject collectible)
    {
        Target target = collectible.GetComponent<Target>();
        Malus malus = collectible.GetComponent<Malus>();
        JumpCollectible jumpCollectible = collectible.GetComponent<JumpCollectible>();

        if (target != null)
        {
            target.PlaySoundBonus();
            ScoreManager.AddScore(1);
            Destroy(collectible);
        }
        else if (malus != null)
        {
            malus.PlaySoundMalus();
            ScoreManager.AddScore(-1);
            Destroy(collectible);
        }
        else if (jumpCollectible != null)
        {
            PlayerJump.AddJump();
            Destroy(collectible);
        }
    }
}