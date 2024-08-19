using Cinemachine;
using UnityEngine;

namespace infrastructure.services.environment
{
  public class SceneEnvironment : MonoBehaviour, ISceneEnvironment
  {
    [field: SerializeField] public CinemachineVirtualCamera EquipmentVirtualCamera { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera BoxingVirtualCamera    { get; private set; }
    [field: SerializeField] public CinemachineVirtualCamera AbilitiesVirtualCamera { get; private set; }
  }
}