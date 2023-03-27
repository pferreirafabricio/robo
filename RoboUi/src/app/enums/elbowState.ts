export enum ElbowState {
  AtRest = 1,
  SlightlyContracted,
  Contracted,
  StronglyContracted
}

export function elbowStateDescription(type: ElbowState): string {
  const descriptions = {
    [ElbowState.SlightlyContracted]: "Slightly contracted",
    [ElbowState.AtRest]: "In rest 😴",
    [ElbowState.Contracted]: "Contracted",
    [ElbowState.StronglyContracted]: "Strongly contracted",
  };

  return descriptions[type];
}

export function elbowValues() {
  return [
    { value: ElbowState.AtRest, name: elbowStateDescription(ElbowState.AtRest) },
    { value: ElbowState.SlightlyContracted, name: elbowStateDescription(ElbowState.SlightlyContracted) },
    { value: ElbowState.Contracted, name: elbowStateDescription(ElbowState.Contracted) },
    { value: ElbowState.StronglyContracted, name: elbowStateDescription(ElbowState.StronglyContracted) },
  ];
}
