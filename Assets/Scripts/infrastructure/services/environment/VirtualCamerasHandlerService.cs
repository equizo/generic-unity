using System;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

namespace infrastructure.services.environment
{
  public class VirtualCamerasHandlerService : IVirtualCamerasHandlerService
  {
    private CinemachineVirtualCamera _activeVirtualCameraGameObject;
    private Dictionary<Type, CinemachineVirtualCamera> _virtualCameraByType;

    public void AddVirtualCameras(Dictionary<Type, CinemachineVirtualCamera> virtualCameraByType,
                                  CinemachineVirtualCamera startCamera)
    {
      _virtualCameraByType = virtualCameraByType;
      _activeVirtualCameraGameObject = startCamera;
    }

    public void SetActive<T>()
    {
      _activeVirtualCameraGameObject.gameObject.SetActive(false);

      _activeVirtualCameraGameObject =
        _virtualCameraByType.FirstOrDefault(pair => pair.Key == typeof(T)).Value;

      if (_activeVirtualCameraGameObject == null) {
        Debug.LogError($"{typeof(T)} is not found in {nameof(_virtualCameraByType)}");
        _activeVirtualCameraGameObject = _virtualCameraByType.First().Value;
      }

      _activeVirtualCameraGameObject.gameObject.SetActive(true);
    }
  }
}