using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SimBridger.Main;

// Wire format: 65 little-endian floats, in declared order. SimHub & SimXperience are
// Windows-only (x86/x64), so MemoryMarshal's native byte order matches the receiver.
[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct SimXperienceTelemetry
{
    [SimXperienceChannel("total_time")] public float TotalTime;
    [SimXperienceChannel("paused")] public float Paused;
    [SimXperienceChannel("yaw")] public float Yaw;
    [SimXperienceChannel("pitch")] public float Pitch;
    [SimXperienceChannel("roll")] public float Roll;
    [SimXperienceChannel("yaw_velocity")] public float YawVelocity;
    [SimXperienceChannel("pitch_velocity")] public float PitchVelocity;
    [SimXperienceChannel("roll_velocity")] public float RollVelocity;
    [SimXperienceChannel("yaw_acceleration")] public float YawAcceleration;
    [SimXperienceChannel("pitch_acceleration")] public float PitchAcceleration;
    [SimXperienceChannel("roll_acceleration")] public float RollAcceleration;
    [SimXperienceChannel("position_x")] public float PositionX;
    [SimXperienceChannel("position_y")] public float PositionY;
    [SimXperienceChannel("position_z")] public float PositionZ;
    [SimXperienceChannel("local_velocity_x")] public float LocalVelocityX;
    [SimXperienceChannel("local_velocity_y")] public float LocalVelocityY;
    [SimXperienceChannel("local_velocity_z")] public float LocalVelocityZ;
    [SimXperienceChannel("gforce_lateral")] public float GForceLateral;
    [SimXperienceChannel("gforce_longitudinal")] public float GForceLongitudinal;
    [SimXperienceChannel("gforce_vertical")] public float GForceVertical;
    [SimXperienceChannel("speed")] public float Speed;
    [SimXperienceChannel("suspension_position_bl", 1000.0f)] public float SuspensionPositionBL;
    [SimXperienceChannel("suspension_position_br", 1000.0f)] public float SuspensionPositionBR;
    [SimXperienceChannel("suspension_position_fl", 1000.0f)] public float SuspensionPositionFL;
    [SimXperienceChannel("suspension_position_fr", 1000.0f)] public float SuspensionPositionFR;
    [SimXperienceChannel("suspension_velocity_bl", 1000.0f)] public float SuspensionVelocityBL;
    [SimXperienceChannel("suspension_velocity_br", 1000.0f)] public float SuspensionVelocityBR;
    [SimXperienceChannel("suspension_velocity_fl", 1000.0f)] public float SuspensionVelocityFL;
    [SimXperienceChannel("suspension_velocity_fr", 1000.0f)] public float SuspensionVelocityFR;
    [SimXperienceChannel("suspension_acceleration_bl", 1000.0f)] public float SuspensionAccelerationBL;
    [SimXperienceChannel("suspension_acceleration_br", 1000.0f)] public float SuspensionAccelerationBR;
    [SimXperienceChannel("suspension_acceleration_fl", 1000.0f)] public float SuspensionAccelerationFL;
    [SimXperienceChannel("suspension_acceleration_fr", 1000.0f)] public float SuspensionAccelerationFR;
    [SimXperienceChannel("wheel_patch_speed_bl")] public float WheelPatchSpeedBL;
    [SimXperienceChannel("wheel_patch_speed_br")] public float WheelPatchSpeedBR;
    [SimXperienceChannel("wheel_patch_speed_fl")] public float WheelPatchSpeedFL;
    [SimXperienceChannel("wheel_patch_speed_fr")] public float WheelPatchSpeedFR;
    [SimXperienceChannel("throttle_input")] public float ThrottleInput;
    [SimXperienceChannel("steering_input")] public float SteeringInput;
    [SimXperienceChannel("brake_input")] public float BrakeInput;
    [SimXperienceChannel("clutch_input")] public float ClutchInput;
    [SimXperienceChannel("gear")] public float Gear;
    [SimXperienceChannel("max_gears")] public float MaxGears;
    [SimXperienceChannel("engine_rate")] public float EngineRate;
    [SimXperienceChannel("race_position")] public float RacePosition;
    [SimXperienceChannel("race_sector")] public float RaceSector;
    [SimXperienceChannel("sector_time_1")] public float SectorTime1;
    [SimXperienceChannel("sector_time_2")] public float SectorTime2;
    [SimXperienceChannel("brake_temp_bl")] public float BrakeTempBL;
    [SimXperienceChannel("brake_temp_br")] public float BrakeTempBR;
    [SimXperienceChannel("brake_temp_fl")] public float BrakeTempFL;
    [SimXperienceChannel("brake_temp_fr")] public float BrakeTempFR;
    [SimXperienceChannel("tyre_pressure_bl")] public float TyrePressureBL;
    [SimXperienceChannel("tyre_pressure_br")] public float TyrePressureBR;
    [SimXperienceChannel("tyre_pressure_fl")] public float TyrePressureFL;
    [SimXperienceChannel("tyre_pressure_fr")] public float TyrePressureFR;
    [SimXperienceChannel("lap")] public float Lap;
    [SimXperienceChannel("laps_completed")] public float LapsCompleted;
    [SimXperienceChannel("total_laps")] public float TotalLaps;
    [SimXperienceChannel("lap_time")] public float LapTime;
    [SimXperienceChannel("lap_distance")] public float LapDistance;
    [SimXperienceChannel("track_length")] public float TrackLength;
    [SimXperienceChannel("last_lap_time")] public float LastLapTime;
    [SimXperienceChannel("max_rpm")] public float MaxRpm;
    [SimXperienceChannel("idle_rpm")] public float IdleRpm;

    public static int Size => Unsafe.SizeOf<SimXperienceTelemetry>();

    public byte[] ToByteArray()
    {
        byte[] result = new byte[Size];
        MemoryMarshal.Write(result, in this);
        return result;
    }

    public static SimXperienceTelemetry FromByteArray(ReadOnlySpan<byte> bytes)
    {
        if (bytes.Length < Size)
            throw new ArgumentException(
                $"Buffer too small: expected {Size} bytes, got {bytes.Length}.",
                nameof(bytes));
        return MemoryMarshal.Read<SimXperienceTelemetry>(bytes);
    }
}
