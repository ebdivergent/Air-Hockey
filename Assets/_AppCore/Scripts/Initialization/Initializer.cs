using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AppCore
{
    public sealed class Initializer : MonoBehaviour
    {
#if DEBUG
        [SerializeField]
#endif
        bool _logToUI = false;

        [SerializeField] SceneName _sceneToLoad;

        private static bool _wasInitializerUsed = false;

        public static bool initializationComplete { get; private set; }

        [SerializeField] private List<LoadableMonoService> _asyncLoadableServicePrefabs;
        [SerializeField] private List<LoadableMonoService> _orderedLoadableServices;

        private List<ILoadableService> _loadableCoreServices = new List<ILoadableService>
        {
            new CoreServices(),
        };

        private void Start()
        {
            if (InitializedAlreadyCheck())
                return;

            InitApp();
        }

        private bool InitializedAlreadyCheck()
        {
            if (_wasInitializerUsed)
            {
                Destroy(gameObject);
                return true;
            }

            _wasInitializerUsed = true;

            return false;
        }

        private void InitApp()
        {
            Application.targetFrameRate = 60;

            StartCoroutine(LoadServicesRoutine());
        }

        private IEnumerator LoadServicesRoutine()
        {
            foreach (var service in _loadableCoreServices)
                service.StartLoad(this);

            foreach (var service in _loadableCoreServices)
                yield return new WaitUntil(service.IsLoaded);

            foreach (var service in _asyncLoadableServicePrefabs)
                service.StartLoad(this);

            foreach (var service in _asyncLoadableServicePrefabs)
                yield return new WaitUntil(service.IsLoaded);

            foreach (var service in _orderedLoadableServices)
            {
                service.StartLoad(this);
                yield return new WaitUntil(service.IsLoaded);
            }

            OnAllServicesLoaded();

            yield break;
        }

        private void OnAllServicesLoaded()
        {
#if DEBUG && !UNITY_EDITOR
            if (_logToUI)
                UILoggerController.Instance.IsSubscribed = true;
#endif

            SceneManager.Instance.ChangeScene(_sceneToLoad);

            initializationComplete = true;

            Destroy(gameObject);
        }
    }
}
