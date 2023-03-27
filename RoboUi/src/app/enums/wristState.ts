export enum WristState {
  RotationToMinus90 = 1,
  RotationToMinus45,
  AtRest,
  RotationTo45,
  RotationTo90,
  RotationTo135,
  RotationTo180,
}

export function wristStateDescription(type: WristState): string {
  const descriptions = {
    [WristState.RotationToMinus90]: "Rotation to -90º",
    [WristState.RotationToMinus45]: "Rotation to -45º",
    [WristState.AtRest]: "In rest 😴",
    [WristState.RotationTo45]: "Rotation to 45º",
    [WristState.RotationTo90]: "Rotation to 90º",
    [WristState.RotationTo135]: "Rotation to 135º",
    [WristState.RotationTo180]: "Rotation to 180º",
  };

  return descriptions[type];
}

export function wristValues() {
  return [
    { value: WristState.RotationToMinus90, name: wristStateDescription(WristState.RotationToMinus90) },
    { value: WristState.RotationToMinus45, name: wristStateDescription(WristState.RotationToMinus45) },
    { value: WristState.AtRest, name: wristStateDescription(WristState.AtRest) },
    { value: WristState.RotationTo45, name: wristStateDescription(WristState.RotationTo45) },
    { value: WristState.RotationTo90, name: wristStateDescription(WristState.RotationTo90) },
    { value: WristState.RotationTo135, name: wristStateDescription(WristState.RotationTo135) },
    { value: WristState.RotationTo180, name: wristStateDescription(WristState.RotationTo180) },
  ];
}
