export enum HeadRotation {
  RotationMinus90 = 1,
  RotationMinus45,
  AtRest,
  Rotation45,
  Rotation90,
}

export function headRotationDescription(type: HeadRotation): string {
  const descriptions = {
    [HeadRotation.RotationMinus90]: "Rotation to -90º",
    [HeadRotation.RotationMinus45]: "Rotation to -45º",
    [HeadRotation.AtRest]: "In rest 😴",
    [HeadRotation.Rotation45]: "Rotation to 45º",
    [HeadRotation.Rotation90]: "Rotation to 90º",
  };

  return descriptions[type];
}

export function headRotationValues() {
  return [
    { value: HeadRotation.RotationMinus90, name: headRotationDescription(HeadRotation.RotationMinus90) },
    { value: HeadRotation.RotationMinus45, name: headRotationDescription(HeadRotation.RotationMinus45) },
    { value: HeadRotation.AtRest, name: headRotationDescription(HeadRotation.AtRest) },
    { value: HeadRotation.Rotation45, name: headRotationDescription(HeadRotation.Rotation45) },
    { value: HeadRotation.Rotation90, name: headRotationDescription(HeadRotation.Rotation90) },
  ];
}
