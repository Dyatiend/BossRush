using UnityEngine;
using UnityEngine.UI;

namespace GameControllers
{
    public class HealthSliderHUD : MonoBehaviour
    {
        public string watchingTag;
        private Health health;
        private Slider slider;
        private bool isActive = false;

        // Start is called before the first frame update
        void Start()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(watchingTag);
            if (objects.Length > 0 && objects[0].GetComponent<Health>() != null)
            {
                health = objects[0].GetComponent<Health>();
                slider = gameObject.GetComponent<Slider>();
                
                slider.maxValue = health.maxHealhPoints;
                slider.value = health.healthPoints;
                slider.minValue = 0;
                
                isActive = true;
            }
            else
            {
                gameObject.SetActive(false);
                isActive = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isActive)
            {
                slider.value = health.healthPoints;
            }
        }
    }
}