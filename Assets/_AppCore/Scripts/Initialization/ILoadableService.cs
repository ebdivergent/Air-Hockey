using UnityEngine;

namespace AppCore
{
    public abstract class LoadableMonoService : MonoBehaviour, ILoadableService
    {
        public abstract void StartLoad(MonoBehaviour caller);

        public abstract bool IsLoaded();
    };

    public interface ILoadableService
    {
        void StartLoad(MonoBehaviour monoBehaviour);
        bool IsLoaded();
    }
}