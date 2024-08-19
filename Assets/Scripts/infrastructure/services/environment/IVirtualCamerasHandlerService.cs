using System;
using System.Collections.Generic;
using Cinemachine;

namespace infrastructure.services.environment
{
  public interface IVirtualCamerasHandlerService : IService
  {
    void AddVirtualCameras(Dictionary<Type, CinemachineVirtualCamera> virtualCameraByType,
                           CinemachineVirtualCamera startCamera);

    void SetActive<T>();
  }
}