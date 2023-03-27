import { ArmNames } from './../enums/armNames';
import { Robot } from './../entities/robot';
import { Component } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { WristState, wristStateDescription, wristValues } from './../enums/wristState';
import { ElbowState, elbowStateDescription, elbowValues } from './../enums/elbowState';
import { HeadInclination, headInclinationDescription, headInclinationValues } from './../enums/headInclination';
import { HeadRotation, headRotationDescription, headRotationValues } from './../enums/headRotation';

@Component({
  selector: 'app-robo',
  templateUrl: './robo.component.html',
  styleUrls: ['./robo.component.css'],
})
export class RoboComponent {
  readonly apiURL: string;
  public robotId: number;
  public loading: boolean;
  public robot: Robot;
  public wristValues;
  public elbowValues;
  public headInclinationValues;
  public headRotationValues;
  public errorMessages;

  constructor(private http: HttpClient) {
    this.robotId = 0;
    this.loading = false;
    this.errorMessages = { rotateHead: '', inclineHead: '', rightElbow: '', leftElbow: '', leftWrist: '', rightWrist: '' };
    this.robot = {} as Robot;
    this.apiURL = "http://localhost:5182/api/robot/";

    this.wristValues = wristValues();
    this.elbowValues = elbowValues();
    this.headInclinationValues = headInclinationValues();
    this.headRotationValues = headRotationValues();
  }

  ngOnInit() {
    this.getRobot();
  }

  getRobot() {
    this.loading = true;

    this.http.get<Robot>(`${this.apiURL}GetById/${this.robotId}`)
      .subscribe(response => {
        if (!response) this.createRobot();

        this.robot = response || {};

        this.loading = false;
      });
  }

  createRobot() {
    this.loading = true;

    this.http.post<number>(`${this.apiURL}Create`, {})
      .subscribe((data: number) => {
        this.robotId = data;
        this.getRobot();

        this.loading = false;
      })
  }

  rotateHead() {
    this.loading = true;
    this.errorMessages.rotateHead = '';

    this.http.post<string>(`${this.apiURL}RotateHead`, {
      id: this.robotId,
      rotation: this.robot.headRotation,
    })
      .subscribe(
        (data: string) => {
          this.loading = false;

          this.getRobot();
        },
        (response: HttpErrorResponse) => {
          this.loading = false;

          this.errorMessages.rotateHead = response.error;
        },
      );
  }

  inclineHead() {
    this.loading = true;

    this.http.post<string>(`${this.apiURL}InclineHead`, {
      id: this.robotId,
      inclination: this.robot.headInclination,
    })
      .subscribe(
        (data: string) => {
          this.loading = false;

          this.getRobot();
        },
        (response: HttpErrorResponse) => {
          this.loading = false;

          this.errorMessages.inclineHead = response.error;
        },
      );
  }

  rotateArmElbow(armName: string) {
    this.loading = true;

    const isLeft = armName == ArmNames.LEFT;

    if (isLeft) this.errorMessages.leftElbow = '';
    else this.errorMessages.rightElbow = '';

    this.http.post<string>(`${this.apiURL}RotateArmElbow`, {
      id: this.robotId,
      armName,
      state: isLeft ? this.robot.leftElbow : this.robot.rightElbow
    })
      .subscribe(
        (data: string) => {
          this.loading = false;

          this.getRobot();
        },
        (response: HttpErrorResponse) => {
          this.loading = false;

          if (isLeft) {
            this.errorMessages.leftElbow = response.error;
            return;
          }

          this.errorMessages.rightElbow = response.error;
        },
      );
  }

  rotateArmWrist(armName: string) {
    this.loading = true;

    const isLeft = armName == ArmNames.LEFT;

    if (isLeft) this.errorMessages.leftWrist = '';
    else this.errorMessages.rightWrist = '';

    this.http.post<string>(`${this.apiURL}RotateArmWrist`, {
      id: this.robotId,
      armName,
      state: isLeft ? this.robot.leftWrist : this.robot.rightWrist
    })
      .subscribe(
        (data: string) => {
          this.loading = false;

          this.getRobot();
        },
        (response: HttpErrorResponse) => {
          this.loading = false;

          if (isLeft) {
            this.errorMessages.leftWrist = response.error;
            return;
          }

          this.errorMessages.rightWrist = response.error;
        },
      );
  }

  headRotationDescription(type: HeadRotation | undefined) {
    if (!type) return "";

    return headRotationDescription(type);
  }

  headInclinationDescription(type: HeadInclination | undefined) {
    if (!type) return "";

    return headInclinationDescription(type);
  }

  elbowStateDescription(type: ElbowState | undefined) {
    if (!type) return "";

    return elbowStateDescription(type);
  }

  wristStateDescription(type: WristState | undefined) {
    if (!type) return "";

    return wristStateDescription(type);
  }
}
