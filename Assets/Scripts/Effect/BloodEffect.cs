using UnityEngine;

public class BloodEffect : MonoBehaviour, IEffect
{
    public float destroyTimeout = 5F;
    public GameObject boodParticle;

    public void PlayEffect()
    {
        GameObject bloodGameObject = Instantiate(boodParticle, transform.position, Quaternion.identity);
        Destroy(bloodGameObject, destroyTimeout);
    }
}
