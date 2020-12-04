namespace MGPhysics
{
    public interface ISystem
    {
        /// <summary>
        /// Method to be called every frame
        /// </summary>
        /// <param name="manager">Component manager to access components</param>
        /// <param name="deltaTime">Time passed between previous and this frame</param>
        void Call(ComponentManager manager, int deltaTime);
    }
}
