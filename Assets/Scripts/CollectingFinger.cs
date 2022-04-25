using UnityEngine;

public class CollectingFinger : MonoBehaviour
{
    public AudioSource coinFX;

    private void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
        this.gameObject.SetActive(false);
    }
}
