using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SimBridger.RbrNgp;

// NGP UDP telemetry packet. Layout per Plugins/NGP/sdk/rbr.telemetry.data.TelemetryData.h
// (#pragma pack(push, 1)). Default endpoint 127.0.0.1:6776, configurable via
// udpTelemetryEndpoints in RichardBurnsRally.ini. Field order mirrors the C++ struct
// hierarchy TelemetryData → Stage / Control / Car → Motion / Engine / Suspension →
// Damper / Wheel → BrakeDisk / Tire → TireSegment[8] in declaration order. Integer
// fields (gear, indices, helperSpringIsActive, totalSteps, currentSegment) are typed
// per the SDK header — do not change them to float.
[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct NgpTelemetry
{
    // --- TelemetryData ---
    [NgpChannel("totalSteps")] public uint TotalSteps;

    // --- Stage ---
    [NgpChannel("stage.index")] public int StageIndex;
    [NgpChannel("stage.progress")] public float StageProgress;
    [NgpChannel("stage.raceTime")] public float StageRaceTime;
    [NgpChannel("stage.driveLineLocation")] public float StageDriveLineLocation;
    [NgpChannel("stage.distanceToEnd")] public float StageDistanceToEnd;

    // --- Control ---
    [NgpChannel("control.steering")] public float ControlSteering;
    [NgpChannel("control.throttle")] public float ControlThrottle;
    [NgpChannel("control.brake")] public float ControlBrake;
    [NgpChannel("control.handbrake")] public float ControlHandbrake;
    [NgpChannel("control.clutch")] public float ControlClutch;
    [NgpChannel("control.gear")] public int ControlGear;
    [NgpChannel("control.footbrakePressure")] public float ControlFootbrakePressure;
    [NgpChannel("control.handbrakePressure")] public float ControlHandbrakePressure;

    // --- Car ---
    [NgpChannel("car.index")] public int CarIndex;
    [NgpChannel("car.speed")] public float CarSpeed;
    [NgpChannel("car.positionX")] public float CarPositionX;
    [NgpChannel("car.positionY")] public float CarPositionY;
    [NgpChannel("car.positionZ")] public float CarPositionZ;
    [NgpChannel("car.roll")] public float CarRoll;
    [NgpChannel("car.pitch")] public float CarPitch;
    [NgpChannel("car.yaw")] public float CarYaw;

    // --- Car.velocities (Motion) ---
    [NgpChannel("car.velocities.surge")] public float CarVelocitySurge;
    [NgpChannel("car.velocities.sway")] public float CarVelocitySway;
    [NgpChannel("car.velocities.heave")] public float CarVelocityHeave;
    [NgpChannel("car.velocities.roll")] public float CarVelocityRoll;
    [NgpChannel("car.velocities.pitch")] public float CarVelocityPitch;
    [NgpChannel("car.velocities.yaw")] public float CarVelocityYaw;

    // --- Car.accelerations (Motion) ---
    [NgpChannel("car.accelerations.surge")] public float CarAccelerationSurge;
    [NgpChannel("car.accelerations.sway")] public float CarAccelerationSway;
    [NgpChannel("car.accelerations.heave")] public float CarAccelerationHeave;
    [NgpChannel("car.accelerations.roll")] public float CarAccelerationRoll;
    [NgpChannel("car.accelerations.pitch")] public float CarAccelerationPitch;
    [NgpChannel("car.accelerations.yaw")] public float CarAccelerationYaw;

    // --- Car.engine ---
    [NgpChannel("car.engine.rpm")] public float EngineRpm;
    [NgpChannel("car.engine.radiatorCoolantTemperature")] public float EngineRadiatorCoolantTemperature;
    [NgpChannel("car.engine.engineCoolantTemperature")] public float EngineCoolantTemperature;
    [NgpChannel("car.engine.engineTemperature")] public float EngineTemperature;

    // --- Car.suspensionLF ---
    [NgpChannel("car.suspensionLF.springDeflection")] public float LFSpringDeflection;
    [NgpChannel("car.suspensionLF.rollbarForce")] public float LFRollbarForce;
    [NgpChannel("car.suspensionLF.springForce")] public float LFSpringForce;
    [NgpChannel("car.suspensionLF.damperForce")] public float LFDamperForce;
    [NgpChannel("car.suspensionLF.strutForce")] public float LFStrutForce;
    [NgpChannel("car.suspensionLF.helperSpringIsActive")] public int LFHelperSpringIsActive;
    [NgpChannel("car.suspensionLF.damper.damage")] public float LFDamperDamage;
    [NgpChannel("car.suspensionLF.damper.pistonVelocity")] public float LFDamperPistonVelocity;
    [NgpChannel("car.suspensionLF.wheel.brakeDisk.layerTemperature")] public float LFBrakeDiskLayerTemperature;
    [NgpChannel("car.suspensionLF.wheel.brakeDisk.temperature")] public float LFBrakeDiskTemperature;
    [NgpChannel("car.suspensionLF.wheel.brakeDisk.wear")] public float LFBrakeDiskWear;
    [NgpChannel("car.suspensionLF.wheel.tire.pressure")] public float LFTirePressure;
    [NgpChannel("car.suspensionLF.wheel.tire.temperature")] public float LFTireTemperature;
    [NgpChannel("car.suspensionLF.wheel.tire.carcassTemperature")] public float LFTireCarcassTemperature;
    [NgpChannel("car.suspensionLF.wheel.tire.treadTemperature")] public float LFTireTreadTemperature;
    [NgpChannel("car.suspensionLF.wheel.tire.currentSegment")] public uint LFTireCurrentSegment;
    [NgpChannel("car.suspensionLF.wheel.tire.segment0.temperature")] public float LFTireSegment0Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment0.wear")] public float LFTireSegment0Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment1.temperature")] public float LFTireSegment1Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment1.wear")] public float LFTireSegment1Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment2.temperature")] public float LFTireSegment2Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment2.wear")] public float LFTireSegment2Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment3.temperature")] public float LFTireSegment3Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment3.wear")] public float LFTireSegment3Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment4.temperature")] public float LFTireSegment4Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment4.wear")] public float LFTireSegment4Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment5.temperature")] public float LFTireSegment5Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment5.wear")] public float LFTireSegment5Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment6.temperature")] public float LFTireSegment6Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment6.wear")] public float LFTireSegment6Wear;
    [NgpChannel("car.suspensionLF.wheel.tire.segment7.temperature")] public float LFTireSegment7Temperature;
    [NgpChannel("car.suspensionLF.wheel.tire.segment7.wear")] public float LFTireSegment7Wear;

    // --- Car.suspensionRF ---
    [NgpChannel("car.suspensionRF.springDeflection")] public float RFSpringDeflection;
    [NgpChannel("car.suspensionRF.rollbarForce")] public float RFRollbarForce;
    [NgpChannel("car.suspensionRF.springForce")] public float RFSpringForce;
    [NgpChannel("car.suspensionRF.damperForce")] public float RFDamperForce;
    [NgpChannel("car.suspensionRF.strutForce")] public float RFStrutForce;
    [NgpChannel("car.suspensionRF.helperSpringIsActive")] public int RFHelperSpringIsActive;
    [NgpChannel("car.suspensionRF.damper.damage")] public float RFDamperDamage;
    [NgpChannel("car.suspensionRF.damper.pistonVelocity")] public float RFDamperPistonVelocity;
    [NgpChannel("car.suspensionRF.wheel.brakeDisk.layerTemperature")] public float RFBrakeDiskLayerTemperature;
    [NgpChannel("car.suspensionRF.wheel.brakeDisk.temperature")] public float RFBrakeDiskTemperature;
    [NgpChannel("car.suspensionRF.wheel.brakeDisk.wear")] public float RFBrakeDiskWear;
    [NgpChannel("car.suspensionRF.wheel.tire.pressure")] public float RFTirePressure;
    [NgpChannel("car.suspensionRF.wheel.tire.temperature")] public float RFTireTemperature;
    [NgpChannel("car.suspensionRF.wheel.tire.carcassTemperature")] public float RFTireCarcassTemperature;
    [NgpChannel("car.suspensionRF.wheel.tire.treadTemperature")] public float RFTireTreadTemperature;
    [NgpChannel("car.suspensionRF.wheel.tire.currentSegment")] public uint RFTireCurrentSegment;
    [NgpChannel("car.suspensionRF.wheel.tire.segment0.temperature")] public float RFTireSegment0Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment0.wear")] public float RFTireSegment0Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment1.temperature")] public float RFTireSegment1Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment1.wear")] public float RFTireSegment1Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment2.temperature")] public float RFTireSegment2Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment2.wear")] public float RFTireSegment2Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment3.temperature")] public float RFTireSegment3Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment3.wear")] public float RFTireSegment3Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment4.temperature")] public float RFTireSegment4Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment4.wear")] public float RFTireSegment4Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment5.temperature")] public float RFTireSegment5Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment5.wear")] public float RFTireSegment5Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment6.temperature")] public float RFTireSegment6Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment6.wear")] public float RFTireSegment6Wear;
    [NgpChannel("car.suspensionRF.wheel.tire.segment7.temperature")] public float RFTireSegment7Temperature;
    [NgpChannel("car.suspensionRF.wheel.tire.segment7.wear")] public float RFTireSegment7Wear;

    // --- Car.suspensionLB ---
    [NgpChannel("car.suspensionLB.springDeflection")] public float LBSpringDeflection;
    [NgpChannel("car.suspensionLB.rollbarForce")] public float LBRollbarForce;
    [NgpChannel("car.suspensionLB.springForce")] public float LBSpringForce;
    [NgpChannel("car.suspensionLB.damperForce")] public float LBDamperForce;
    [NgpChannel("car.suspensionLB.strutForce")] public float LBStrutForce;
    [NgpChannel("car.suspensionLB.helperSpringIsActive")] public int LBHelperSpringIsActive;
    [NgpChannel("car.suspensionLB.damper.damage")] public float LBDamperDamage;
    [NgpChannel("car.suspensionLB.damper.pistonVelocity")] public float LBDamperPistonVelocity;
    [NgpChannel("car.suspensionLB.wheel.brakeDisk.layerTemperature")] public float LBBrakeDiskLayerTemperature;
    [NgpChannel("car.suspensionLB.wheel.brakeDisk.temperature")] public float LBBrakeDiskTemperature;
    [NgpChannel("car.suspensionLB.wheel.brakeDisk.wear")] public float LBBrakeDiskWear;
    [NgpChannel("car.suspensionLB.wheel.tire.pressure")] public float LBTirePressure;
    [NgpChannel("car.suspensionLB.wheel.tire.temperature")] public float LBTireTemperature;
    [NgpChannel("car.suspensionLB.wheel.tire.carcassTemperature")] public float LBTireCarcassTemperature;
    [NgpChannel("car.suspensionLB.wheel.tire.treadTemperature")] public float LBTireTreadTemperature;
    [NgpChannel("car.suspensionLB.wheel.tire.currentSegment")] public uint LBTireCurrentSegment;
    [NgpChannel("car.suspensionLB.wheel.tire.segment0.temperature")] public float LBTireSegment0Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment0.wear")] public float LBTireSegment0Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment1.temperature")] public float LBTireSegment1Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment1.wear")] public float LBTireSegment1Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment2.temperature")] public float LBTireSegment2Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment2.wear")] public float LBTireSegment2Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment3.temperature")] public float LBTireSegment3Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment3.wear")] public float LBTireSegment3Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment4.temperature")] public float LBTireSegment4Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment4.wear")] public float LBTireSegment4Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment5.temperature")] public float LBTireSegment5Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment5.wear")] public float LBTireSegment5Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment6.temperature")] public float LBTireSegment6Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment6.wear")] public float LBTireSegment6Wear;
    [NgpChannel("car.suspensionLB.wheel.tire.segment7.temperature")] public float LBTireSegment7Temperature;
    [NgpChannel("car.suspensionLB.wheel.tire.segment7.wear")] public float LBTireSegment7Wear;

    // --- Car.suspensionRB ---
    [NgpChannel("car.suspensionRB.springDeflection")] public float RBSpringDeflection;
    [NgpChannel("car.suspensionRB.rollbarForce")] public float RBRollbarForce;
    [NgpChannel("car.suspensionRB.springForce")] public float RBSpringForce;
    [NgpChannel("car.suspensionRB.damperForce")] public float RBDamperForce;
    [NgpChannel("car.suspensionRB.strutForce")] public float RBStrutForce;
    [NgpChannel("car.suspensionRB.helperSpringIsActive")] public int RBHelperSpringIsActive;
    [NgpChannel("car.suspensionRB.damper.damage")] public float RBDamperDamage;
    [NgpChannel("car.suspensionRB.damper.pistonVelocity")] public float RBDamperPistonVelocity;
    [NgpChannel("car.suspensionRB.wheel.brakeDisk.layerTemperature")] public float RBBrakeDiskLayerTemperature;
    [NgpChannel("car.suspensionRB.wheel.brakeDisk.temperature")] public float RBBrakeDiskTemperature;
    [NgpChannel("car.suspensionRB.wheel.brakeDisk.wear")] public float RBBrakeDiskWear;
    [NgpChannel("car.suspensionRB.wheel.tire.pressure")] public float RBTirePressure;
    [NgpChannel("car.suspensionRB.wheel.tire.temperature")] public float RBTireTemperature;
    [NgpChannel("car.suspensionRB.wheel.tire.carcassTemperature")] public float RBTireCarcassTemperature;
    [NgpChannel("car.suspensionRB.wheel.tire.treadTemperature")] public float RBTireTreadTemperature;
    [NgpChannel("car.suspensionRB.wheel.tire.currentSegment")] public uint RBTireCurrentSegment;
    [NgpChannel("car.suspensionRB.wheel.tire.segment0.temperature")] public float RBTireSegment0Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment0.wear")] public float RBTireSegment0Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment1.temperature")] public float RBTireSegment1Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment1.wear")] public float RBTireSegment1Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment2.temperature")] public float RBTireSegment2Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment2.wear")] public float RBTireSegment2Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment3.temperature")] public float RBTireSegment3Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment3.wear")] public float RBTireSegment3Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment4.temperature")] public float RBTireSegment4Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment4.wear")] public float RBTireSegment4Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment5.temperature")] public float RBTireSegment5Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment5.wear")] public float RBTireSegment5Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment6.temperature")] public float RBTireSegment6Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment6.wear")] public float RBTireSegment6Wear;
    [NgpChannel("car.suspensionRB.wheel.tire.segment7.temperature")] public float RBTireSegment7Temperature;
    [NgpChannel("car.suspensionRB.wheel.tire.segment7.wear")] public float RBTireSegment7Wear;

    public static int Size => Unsafe.SizeOf<NgpTelemetry>();

    public static NgpTelemetry FromByteArray(ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < Size)
            throw new ArgumentException(
                $"Buffer too small: expected {Size} bytes, got {bytes.Length}.",
                nameof(bytes));
        return MemoryMarshal.Read<NgpTelemetry>(bytes);
    }
}
