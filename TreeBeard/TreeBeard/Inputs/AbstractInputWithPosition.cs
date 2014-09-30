
namespace TreeBeard.Inputs
{
    public abstract class AbstractInputWithPosition<T> : AbstractInput
    {
        private T _position;
        private bool _isPositionInitialized;

        /// <summary>
        /// Checks if current position has been initialized
        /// </summary>
        protected bool IsPositionInitialized()
        {
            return _isPositionInitialized;
        }

        /// <summary>
        /// Clears current position initialized flag
        /// Note that this does not actually clear the current value.
        /// </summary>
        protected void ClearPosition()
        {
            _isPositionInitialized = false;
        }

        /// <summary>
        /// Initialize current position.  Uses default value if no value currently stored
        /// </summary>
        protected void InitPosition(T defaultValue)
        {
            if (KeyStore.Exists(Alias))
            {
                _position = KeyStore.Get<T>(Alias);
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
        protected void SetPosition(T value)
        {
            _position = value;
            KeyStore.Insert<T>(Alias, value);
        }

        /// <summary>
        /// Get current position
        /// </summary>
        protected T GetPosition()
        {
            return _position;
        }
    }
}
