export enum HeadInclination {
  Up = 1,
  AtRest,
  Down,
}

export function headInclinationDescription(type: HeadInclination): string {
  const descriptions = {
    [HeadInclination.Up]: "To top",
    [HeadInclination.AtRest]: "In rest 😴",
    [HeadInclination.Down]: "To down",
  };

  return descriptions[type];
}

export function headInclinationValues() {
  return [
    { value: HeadInclination.Up, name: headInclinationDescription(HeadInclination.Up) },
    { value: HeadInclination.AtRest, name: headInclinationDescription(HeadInclination.AtRest) },
    { value: HeadInclination.Down, name: headInclinationDescription(HeadInclination.Down) },
  ];
}
