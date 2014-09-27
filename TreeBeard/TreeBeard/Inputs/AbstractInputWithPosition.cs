using TreeBeard.Utils;

namespace TreeBeard.Inputs
{
    public abstract class AbstractInputWithPosition<T> : AbstractInput
    {
        private T _position;
        private bool _isPositionInitialized;

        /// <summary>
        /// Checks if current position has been initialized
        /// </summary>
        public bool IsPositionInitialized()
        {
            return _isPositionInitialized;
        }

        /// <summary>
        /// Clears current position initialized flag
        /// Note that this does not actually clear the current value.
        /// </summary>
        public void ClearPosition()
        {
            _isPositionInitialized = false;
        }

        /// <summary>
        /// Initialize current position.  Uses default value if no value currently stored
        /// </summary>
        public void InitPosition(T defaultValue)
        {
            if (KeyStore.Exists(Id))
            {
                _position = KeyStore.Get<T>(Id);
            }
            else
            {
                SetPosition(defaultValue);
            }
            _isPositionInitialized = true;
        }

        /// <summary>
        /// Set current position
        /// </summary>
        public void SetPosition(T value)
        {
            _position = value;
            KeyStore.Insert<T>(Id, value);
        }

        /// <summary>
        /// Get current position
        /// </summary>
        public T GetPosition()
        {
            return _position;
        }
    }
}
