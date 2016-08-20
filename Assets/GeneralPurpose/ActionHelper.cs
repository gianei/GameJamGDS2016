using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Library.Helpers
{
    public class ActionHelper : MonoBehaviour {

        private static MonoBehaviour monoBehaviour = null;
        public static MonoBehaviour mono
        {
            get 
            {
                if (!monoBehaviour)
                {
                    monoBehaviour =
                        (new GameObject("ActionHelper_Routiner", typeof (ActionHelper))).GetComponent<ActionHelper>();
                    DontDestroyOnLoad(monoBehaviour);
                }

                return monoBehaviour;
            }
        }

        public static void PerformNextFrameAction(UnityAction action)
        {
            mono.StartCoroutine(ActionNextFrameCoroutine(action));
        }

        public static void PerformDelayedAction(float delay, UnityAction action)
        {
            mono.StartCoroutine(ActionDelayCoroutine(delay,action));
        }

        private static IEnumerator ActionNextFrameCoroutine(UnityAction action)
        {
            yield return null;

            if(action != null)
                action.Invoke();
        }

        private static IEnumerator ActionDelayCoroutine(float delay, UnityAction action)
        {
            yield return new WaitForSeconds(Time.timeScale * delay);

            if(action != null)
                action.Invoke();
        }
    }
}
