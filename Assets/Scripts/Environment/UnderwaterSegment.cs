using Afterimage.Audio;
using Afterimage.Progression;
using UnityEngine;

namespace Afterimage.Collectibles
{
    public class MemoryFragment : MonoBehaviour
    {
        [SerializeField] private string fragmentId = "fragment_01";
        [SerializeField] private string storyMessage = "A fragment of a forgotten dive.";
        [SerializeField] private AudioClip pickupClip;
        [SerializeField] private ParticleSystem pickupParticles;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            if (SaveManager.Instance != null)
            {
                SaveManager.Instance.AddMemoryFragment(fragmentId);
            }

            Debug.Log(storyMessage);

            if (pickupParticles != null)
            {
                pickupParticles.Play();
            }

            if (pickupClip != null && AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySfx(pickupClip);
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
