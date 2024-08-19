using Cinemachine;

namespace infrastructure.services.environment
{
  public interface ISceneEnvironment
  {
    CinemachineVirtualCamera EquipmentVirtualCamera { get; }
    CinemachineVirtualCamera BoxingVirtualCamera    { get; }
    CinemachineVirtualCamera AbilitiesVirtualCamera { get; }
  }
}