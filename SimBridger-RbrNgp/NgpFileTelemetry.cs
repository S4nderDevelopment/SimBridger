namespace SimBridger.RbrNgp;

// NGP file/TSV recording channel inventory, derived from Plugins/NGP/Telemetry.ini
// parameter set [NGP]. Channels are written to .ld (MoTeC i2 binary) and .tsv
// (tab-separated) by the in-game Telemetry Recorder. The .ld binary layout is the
// proprietary MoTeC i2 container — NOT documented in the NGP SDK — so consumers
// must parse the TSV header or use a third-party MoTeC i2 reader. Do not attempt
// MemoryMarshal.Read against this type. For the live UDP wire format see NgpTelemetry.
internal struct NgpFileTelemetry
{
    // --- Global channels ---
    [NgpChannel("totalSteps")] public float TotalSteps;
    [NgpChannel("progress")] public float Progress;
    [NgpChannel("raceTime")] public float RaceTime;
    // utcSystemTime is recorded only in the file format (added in NGP 7.3.775,
    // 2024-03-07). The .ld binary encoding is not documented in the SDK — when a
    // TSV/.ld parser is built, populate this from the parsed text/MoTeC channel
    // directly. Not relevant to the live UDP wire (see NgpTelemetry).
    [NgpChannel("utcSystemTime")] public long UtcSystemTimeRaw;
    [NgpChannel("speed")] public float Speed;
    [NgpChannel("engineRotation")] public float EngineRotation;
    [NgpChannel("gear")] public float Gear;
    [NgpChannel("driveLineLocation")] public float DriveLineLocation;
    [NgpChannel("travelDistance")] public float TravelDistance;
    [NgpChannel("distanceToEnd")] public float DistanceToEnd;
    [NgpChannel("stage")] public float Stage;
    [NgpChannel("car")] public float Car;
    [NgpChannel("steering")] public float Steering;
    [NgpChannel("throttle")] public float Throttle;
    [NgpChannel("brake")] public float Brake;
    [NgpChannel("handbrake")] public float Handbrake;
    [NgpChannel("clutch")] public float Clutch;
    [NgpChannel("footbrakePressure")] public float FootbrakePressure;
    [NgpChannel("handbrakePressure")] public float HandbrakePressure;
    [NgpChannel("radiatorCoolantHeatState.temperature")] public float RadiatorCoolantTemperature;
    [NgpChannel("engineCoolantHeatState.temperature")] public float EngineCoolantTemperature;
    [NgpChannel("engineTemperature")] public float EngineTemperature;
    [NgpChannel("position.x")] public float PositionX;
    [NgpChannel("position.y")] public float PositionY;
    [NgpChannel("position.z")] public float PositionZ;
    [NgpChannel("vecRelativeLinearVelocity.x")] public float RelativeLinearVelocityX;
    [NgpChannel("vecRelativeLinearVelocity.y")] public float RelativeLinearVelocityY;
    [NgpChannel("vecRelativeLinearVelocity.z")] public float RelativeLinearVelocityZ;
    [NgpChannel("vecRelativeAngularVelocity.x")] public float RelativeAngularVelocityX;
    [NgpChannel("vecRelativeAngularVelocity.y")] public float RelativeAngularVelocityY;
    [NgpChannel("vecRelativeAngularVelocity.z")] public float RelativeAngularVelocityZ;
    [NgpChannel("vecRelativeLinearAcceleration.x")] public float RelativeLinearAccelerationX;
    [NgpChannel("vecRelativeLinearAcceleration.y")] public float RelativeLinearAccelerationY;
    [NgpChannel("vecRelativeLinearAcceleration.z")] public float RelativeLinearAccelerationZ;
    [NgpChannel("vecRelativeAngularAcceleration.x")] public float RelativeAngularAccelerationX;
    [NgpChannel("vecRelativeAngularAcceleration.y")] public float RelativeAngularAccelerationY;
    [NgpChannel("vecRelativeAngularAcceleration.z")] public float RelativeAngularAccelerationZ;
    [NgpChannel("vecLinearVelocityCar.x")] public float LinearVelocityCarX;
    [NgpChannel("vecLinearVelocityCar.y")] public float LinearVelocityCarY;
    [NgpChannel("vecLinearVelocityCar.z")] public float LinearVelocityCarZ;
    [NgpChannel("vecAngularVelocityCar.x")] public float AngularVelocityCarX;
    [NgpChannel("vecAngularVelocityCar.y")] public float AngularVelocityCarY;
    [NgpChannel("vecAngularVelocityCar.z")] public float AngularVelocityCarZ;
    [NgpChannel("vecLinearAccelerationCar.x")] public float LinearAccelerationCarX;
    [NgpChannel("vecLinearAccelerationCar.y")] public float LinearAccelerationCarY;
    [NgpChannel("vecLinearAccelerationCar.z")] public float LinearAccelerationCarZ;
    [NgpChannel("vecAngularAccelerationCar.x")] public float AngularAccelerationCarX;
    [NgpChannel("vecAngularAccelerationCar.y")] public float AngularAccelerationCarY;
    [NgpChannel("vecAngularAccelerationCar.z")] public float AngularAccelerationCarZ;
    [NgpChannel("roll")] public float Roll;
    [NgpChannel("pitch")] public float Pitch;
    [NgpChannel("yaw")] public float Yaw;
    [NgpChannel("vecAvgLinearAccelerationCar.x")] public float AvgLinearAccelerationCarX;
    [NgpChannel("vecAvgLinearAccelerationCar.y")] public float AvgLinearAccelerationCarY;
    [NgpChannel("vecAvgLinearAccelerationCar.z")] public float AvgLinearAccelerationCarZ;
    [NgpChannel("vecAvgAngularAccelerationCar.x")] public float AvgAngularAccelerationCarX;
    [NgpChannel("vecAvgAngularAccelerationCar.y")] public float AvgAngularAccelerationCarY;
    [NgpChannel("vecAvgAngularAccelerationCar.z")] public float AvgAngularAccelerationCarZ;

    // --- Left-front wheel ---
    [NgpChannel("LF.brakeDiskLayerTemp")] public float LFBrakeDiskLayerTemp;
    [NgpChannel("LF.brakeDiskTemp")] public float LFBrakeDiskTemp;
    [NgpChannel("LF.brakeWear")] public float LFBrakeWear;
    [NgpChannel("LF.deflection")] public float LFDeflection;
    [NgpChannel("LF.deflectionVelocity")] public float LFDeflectionVelocity;
    [NgpChannel("LF.innerBumpDeflectionVelocity")] public float LFInnerBumpDeflectionVelocity;
    [NgpChannel("LF.outerBumpDeflectionVelocity")] public float LFOuterBumpDeflectionVelocity;
    [NgpChannel("LF.temperature")] public float LFTemperature;
    [NgpChannel("LF.pressure")] public float LFPressure;
    [NgpChannel("LF.segmentData[0].temperature")] public float LFSegmentTemperature0;
    [NgpChannel("LF.segmentData[1].temperature")] public float LFSegmentTemperature1;
    [NgpChannel("LF.segmentData[2].temperature")] public float LFSegmentTemperature2;
    [NgpChannel("LF.segmentData[3].temperature")] public float LFSegmentTemperature3;
    [NgpChannel("LF.segmentData[4].temperature")] public float LFSegmentTemperature4;
    [NgpChannel("LF.segmentData[5].temperature")] public float LFSegmentTemperature5;
    [NgpChannel("LF.segmentData[6].temperature")] public float LFSegmentTemperature6;
    [NgpChannel("LF.segmentData[7].temperature")] public float LFSegmentTemperature7;
    [NgpChannel("LF.treadTemperature")] public float LFTreadTemperature;
    [NgpChannel("LF.tyreTemperature")] public float LFTyreTemperature;
    [NgpChannel("LF.currentTyreSegment")] public float LFCurrentTyreSegment;
    [NgpChannel("LF.rollbarForce")] public float LFRollbarForce;
    [NgpChannel("LF.springForce")] public float LFSpringForce;
    [NgpChannel("LF.dampingForce")] public float LFDampingForce;
    [NgpChannel("LF.strutForce")] public float LFStrutForce;
    [NgpChannel("LF.helperSpringActive")] public float LFHelperSpringActive;
    [NgpChannel("LF.wear[0]")] public float LFWear0;
    [NgpChannel("LF.wear[1]")] public float LFWear1;
    [NgpChannel("LF.wear[2]")] public float LFWear2;
    [NgpChannel("LF.wear[3]")] public float LFWear3;
    [NgpChannel("LF.wear[4]")] public float LFWear4;
    [NgpChannel("LF.wear[5]")] public float LFWear5;
    [NgpChannel("LF.wear[6]")] public float LFWear6;
    [NgpChannel("LF.wear[7]")] public float LFWear7;

    // --- Right-front wheel ---
    [NgpChannel("RF.brakeDiskLayerTemp")] public float RFBrakeDiskLayerTemp;
    [NgpChannel("RF.brakeDiskTemp")] public float RFBrakeDiskTemp;
    [NgpChannel("RF.brakeWear")] public float RFBrakeWear;
    [NgpChannel("RF.deflection")] public float RFDeflection;
    [NgpChannel("RF.deflectionVelocity")] public float RFDeflectionVelocity;
    [NgpChannel("RF.innerBumpDeflectionVelocity")] public float RFInnerBumpDeflectionVelocity;
    [NgpChannel("RF.outerBumpDeflectionVelocity")] public float RFOuterBumpDeflectionVelocity;
    [NgpChannel("RF.temperature")] public float RFTemperature;
    [NgpChannel("RF.pressure")] public float RFPressure;
    [NgpChannel("RF.segmentData[0].temperature")] public float RFSegmentTemperature0;
    [NgpChannel("RF.segmentData[1].temperature")] public float RFSegmentTemperature1;
    [NgpChannel("RF.segmentData[2].temperature")] public float RFSegmentTemperature2;
    [NgpChannel("RF.segmentData[3].temperature")] public float RFSegmentTemperature3;
    [NgpChannel("RF.segmentData[4].temperature")] public float RFSegmentTemperature4;
    [NgpChannel("RF.segmentData[5].temperature")] public float RFSegmentTemperature5;
    [NgpChannel("RF.segmentData[6].temperature")] public float RFSegmentTemperature6;
    [NgpChannel("RF.segmentData[7].temperature")] public float RFSegmentTemperature7;
    [NgpChannel("RF.treadTemperature")] public float RFTreadTemperature;
    [NgpChannel("RF.tyreTemperature")] public float RFTyreTemperature;
    [NgpChannel("RF.currentTyreSegment")] public float RFCurrentTyreSegment;
    [NgpChannel("RF.rollbarForce")] public float RFRollbarForce;
    [NgpChannel("RF.springForce")] public float RFSpringForce;
    [NgpChannel("RF.dampingForce")] public float RFDampingForce;
    [NgpChannel("RF.strutForce")] public float RFStrutForce;
    [NgpChannel("RF.helperSpringActive")] public float RFHelperSpringActive;
    [NgpChannel("RF.wear[0]")] public float RFWear0;
    [NgpChannel("RF.wear[1]")] public float RFWear1;
    [NgpChannel("RF.wear[2]")] public float RFWear2;
    [NgpChannel("RF.wear[3]")] public float RFWear3;
    [NgpChannel("RF.wear[4]")] public float RFWear4;
    [NgpChannel("RF.wear[5]")] public float RFWear5;
    [NgpChannel("RF.wear[6]")] public float RFWear6;
    [NgpChannel("RF.wear[7]")] public float RFWear7;

    // --- Left-back wheel ---
    [NgpChannel("LB.brakeDiskLayerTemp")] public float LBBrakeDiskLayerTemp;
    [NgpChannel("LB.brakeDiskTemp")] public float LBBrakeDiskTemp;
    [NgpChannel("LB.brakeWear")] public float LBBrakeWear;
    [NgpChannel("LB.deflection")] public float LBDeflection;
    [NgpChannel("LB.deflectionVelocity")] public float LBDeflectionVelocity;
    [NgpChannel("LB.innerBumpDeflectionVelocity")] public float LBInnerBumpDeflectionVelocity;
    [NgpChannel("LB.outerBumpDeflectionVelocity")] public float LBOuterBumpDeflectionVelocity;
    [NgpChannel("LB.temperature")] public float LBTemperature;
    [NgpChannel("LB.pressure")] public float LBPressure;
    [NgpChannel("LB.segmentData[0].temperature")] public float LBSegmentTemperature0;
    [NgpChannel("LB.segmentData[1].temperature")] public float LBSegmentTemperature1;
    [NgpChannel("LB.segmentData[2].temperature")] public float LBSegmentTemperature2;
    [NgpChannel("LB.segmentData[3].temperature")] public float LBSegmentTemperature3;
    [NgpChannel("LB.segmentData[4].temperature")] public float LBSegmentTemperature4;
    [NgpChannel("LB.segmentData[5].temperature")] public float LBSegmentTemperature5;
    [NgpChannel("LB.segmentData[6].temperature")] public float LBSegmentTemperature6;
    [NgpChannel("LB.segmentData[7].temperature")] public float LBSegmentTemperature7;
    [NgpChannel("LB.treadTemperature")] public float LBTreadTemperature;
    [NgpChannel("LB.tyreTemperature")] public float LBTyreTemperature;
    [NgpChannel("LB.currentTyreSegment")] public float LBCurrentTyreSegment;
    [NgpChannel("LB.rollbarForce")] public float LBRollbarForce;
    [NgpChannel("LB.springForce")] public float LBSpringForce;
    [NgpChannel("LB.dampingForce")] public float LBDampingForce;
    [NgpChannel("LB.strutForce")] public float LBStrutForce;
    [NgpChannel("LB.helperSpringActive")] public float LBHelperSpringActive;
    [NgpChannel("LB.wear[0]")] public float LBWear0;
    [NgpChannel("LB.wear[1]")] public float LBWear1;
    [NgpChannel("LB.wear[2]")] public float LBWear2;
    [NgpChannel("LB.wear[3]")] public float LBWear3;
    [NgpChannel("LB.wear[4]")] public float LBWear4;
    [NgpChannel("LB.wear[5]")] public float LBWear5;
    [NgpChannel("LB.wear[6]")] public float LBWear6;
    [NgpChannel("LB.wear[7]")] public float LBWear7;

    // --- Right-back wheel ---
    [NgpChannel("RB.brakeDiskLayerTemp")] public float RBBrakeDiskLayerTemp;
    [NgpChannel("RB.brakeDiskTemp")] public float RBBrakeDiskTemp;
    [NgpChannel("RB.brakeWear")] public float RBBrakeWear;
    [NgpChannel("RB.deflection")] public float RBDeflection;
    [NgpChannel("RB.deflectionVelocity")] public float RBDeflectionVelocity;
    [NgpChannel("RB.innerBumpDeflectionVelocity")] public float RBInnerBumpDeflectionVelocity;
    [NgpChannel("RB.outerBumpDeflectionVelocity")] public float RBOuterBumpDeflectionVelocity;
    [NgpChannel("RB.temperature")] public float RBTemperature;
    [NgpChannel("RB.pressure")] public float RBPressure;
    [NgpChannel("RB.segmentData[0].temperature")] public float RBSegmentTemperature0;
    [NgpChannel("RB.segmentData[1].temperature")] public float RBSegmentTemperature1;
    [NgpChannel("RB.segmentData[2].temperature")] public float RBSegmentTemperature2;
    [NgpChannel("RB.segmentData[3].temperature")] public float RBSegmentTemperature3;
    [NgpChannel("RB.segmentData[4].temperature")] public float RBSegmentTemperature4;
    [NgpChannel("RB.segmentData[5].temperature")] public float RBSegmentTemperature5;
    [NgpChannel("RB.segmentData[6].temperature")] public float RBSegmentTemperature6;
    [NgpChannel("RB.segmentData[7].temperature")] public float RBSegmentTemperature7;
    [NgpChannel("RB.treadTemperature")] public float RBTreadTemperature;
    [NgpChannel("RB.tyreTemperature")] public float RBTyreTemperature;
    [NgpChannel("RB.currentTyreSegment")] public float RBCurrentTyreSegment;
    [NgpChannel("RB.rollbarForce")] public float RBRollbarForce;
    [NgpChannel("RB.springForce")] public float RBSpringForce;
    [NgpChannel("RB.dampingForce")] public float RBDampingForce;
    [NgpChannel("RB.strutForce")] public float RBStrutForce;
    [NgpChannel("RB.helperSpringActive")] public float RBHelperSpringActive;
    [NgpChannel("RB.wear[0]")] public float RBWear0;
    [NgpChannel("RB.wear[1]")] public float RBWear1;
    [NgpChannel("RB.wear[2]")] public float RBWear2;
    [NgpChannel("RB.wear[3]")] public float RBWear3;
    [NgpChannel("RB.wear[4]")] public float RBWear4;
    [NgpChannel("RB.wear[5]")] public float RBWear5;
    [NgpChannel("RB.wear[6]")] public float RBWear6;
    [NgpChannel("RB.wear[7]")] public float RBWear7;
}
