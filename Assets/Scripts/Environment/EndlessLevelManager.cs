using UnityEngine;

namespace Afterimage.Afterimage
{
    public interface IAfterimageInteractable
    {
        void OnAfterimageTriggered(AfterimagePlayback afterimage);
    }

    public class PressurePlate : MonoBehaviour, IAfterimageInteractable
    {
        [SerializeField] private bool active;
        [SerializeField] private float resetDelay = 1f;

        private float timer;

        public void OnAfterimageTriggered(AfterimagePlayback afterimage)
        {
            active = true;
            timer = resetDelay;
            Debug.Log("Pressure plate activated by afterimage.");
        }

        private void Update()
        {
            if (!active)
            {
                return;
            }

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                active = false;
            }
        }
    }
}
