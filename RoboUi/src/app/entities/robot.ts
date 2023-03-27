import { ElbowState } from './../enums/elbowState';
import { WristState } from './../enums/wristState';
import { HeadInclination } from './../enums/headInclination';
import { HeadRotation } from './../enums/headRotation';

export type Robot = {
  id: number,
  headRotation: HeadRotation,
  headInclination: HeadInclination,
  leftElbow: ElbowState,
  leftWrist: WristState,
  rightElbow: ElbowState,
  rightWrist: WristState,
}
