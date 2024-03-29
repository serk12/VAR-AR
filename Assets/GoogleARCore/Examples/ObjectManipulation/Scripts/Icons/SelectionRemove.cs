
namespace GoogleARCore.Examples.ObjectManipulation
{
    using GoogleARCore.Examples.ObjectManipulationInternal;
    using UnityEngine;

    public class SelectionRemove : Manipulator
    {
        private GameObject SelectedObject;

        /// <summary>
        /// The Unity's Start method.
        /// </summary>
        protected void Start()
        {
        }

        /// <summary>
        /// The Unity's Update method.
        /// </summary>
        protected override void Update()
        {
        }

        /// <summary>
        /// Returns true if the manipulation can be started for the given gesture.
        /// </summary>
        /// <param name="gesture">The current gesture.</param>
        /// <returns>True if the manipulation can be started.</returns>
        protected override bool CanStartManipulationForGesture(TapGesture gesture)
        {
            if(gesture.TapObject == gameObject) return true;
            else return false;
        }

        /// <summary>
        /// Function called when the manipulation is started.
        /// </summary>
        /// <param name="gesture">The current gesture.</param>
        protected override void OnStartManipulation(TapGesture gesture)
        {
             Destroy(SelectedObject);
        }

        public void setTarget(GameObject target)
        {
            SelectedObject = target;
        }


    }
}
