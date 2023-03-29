using Bonsai.Harp;
using System.Threading.Tasks;

namespace Harp.TimestampGeneratorGen3
{
    /// <inheritdoc/>
    public partial class Device
    {
        /// <summary>
        /// Initializes a new instance of the asynchronous API to configure and interface
        /// with TimestampGeneratorGen3 devices on the specified serial port.
        /// </summary>
        /// <param name="portName">
        /// The name of the serial port used to communicate with the Harp device.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous initialization operation. The value of
        /// the <see cref="Task{TResult}.Result"/> parameter contains a new instance of
        /// the <see cref="AsyncDevice"/> class.
        /// </returns>
        public static async Task<AsyncDevice> CreateAsync(string portName)
        {
            var device = new AsyncDevice(portName);
            var whoAmI = await device.ReadWhoAmIAsync();
            if (whoAmI != Device.WhoAmI)
            {
                var errorMessage = string.Format(
                    "The device ID {1} on {0} was unexpected. Check whether a TimestampGeneratorGen3 device is connected to the specified serial port.",
                    portName, whoAmI);
                throw new HarpException(errorMessage);
            }

            return device;
        }
    }

    /// <summary>
    /// Represents an asynchronous API to configure and interface with TimestampGeneratorGen3 devices.
    /// </summary>
    public partial class AsyncDevice : Bonsai.Harp.AsyncDevice
    {
        internal AsyncDevice(string portName)
            : base(portName)
        {
        }

        /// <summary>
        /// Asynchronously reads the contents of the Config register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ConfigurationFlags> ReadConfigAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Config.Address));
            return Config.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Config register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ConfigurationFlags>> ReadTimestampedConfigAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(Config.Address));
            return Config.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the Config register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteConfigAsync(ConfigurationFlags value)
        {
            var request = Config.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the DevicesConnected register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<byte> ReadDevicesConnectedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DevicesConnected.Address));
            return DevicesConnected.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the DevicesConnected register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<byte>> ReadTimestampedDevicesConnectedAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(DevicesConnected.Address));
            return DevicesConnected.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the RepeaterStatus register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<RepeaterFlags> ReadRepeaterStatusAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(RepeaterStatus.Address));
            return RepeaterStatus.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the RepeaterStatus register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<RepeaterFlags>> ReadTimestampedRepeaterStatusAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(RepeaterStatus.Address));
            return RepeaterStatus.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the RepeaterStatus register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteRepeaterStatusAsync(RepeaterFlags value)
        {
            var request = RepeaterStatus.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the BatteryRate register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<BatteryRateConfiguration> ReadBatteryRateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(BatteryRate.Address));
            return BatteryRate.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the BatteryRate register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<BatteryRateConfiguration>> ReadTimestampedBatteryRateAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadByte(BatteryRate.Address));
            return BatteryRate.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the BatteryRate register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteBatteryRateAsync(BatteryRateConfiguration value)
        {
            var request = BatteryRate.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the Battery register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadBatteryAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Battery.Address));
            return Battery.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the Battery register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedBatteryAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(Battery.Address));
            return Battery.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the contents of the BatteryThresholdLow register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadBatteryThresholdLowAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(BatteryThresholdLow.Address));
            return BatteryThresholdLow.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the BatteryThresholdLow register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedBatteryThresholdLowAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(BatteryThresholdLow.Address));
            return BatteryThresholdLow.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the BatteryThresholdLow register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteBatteryThresholdLowAsync(float value)
        {
            var request = BatteryThresholdLow.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the BatteryThresholdHigh register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<float> ReadBatteryThresholdHighAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(BatteryThresholdHigh.Address));
            return BatteryThresholdHigh.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the BatteryThresholdHigh register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<float>> ReadTimestampedBatteryThresholdHighAsync()
        {
            var reply = await CommandAsync(HarpCommand.ReadSingle(BatteryThresholdHigh.Address));
            return BatteryThresholdHigh.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the BatteryThresholdHigh register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteBatteryThresholdHighAsync(float value)
        {
            var request = BatteryThresholdHigh.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the BatteryCalibration0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadBatteryCalibration0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(BatteryCalibration0.Address));
            return BatteryCalibration0.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the BatteryCalibration0 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedBatteryCalibration0Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(BatteryCalibration0.Address));
            return BatteryCalibration0.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the BatteryCalibration0 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteBatteryCalibration0Async(ushort value)
        {
            var request = BatteryCalibration0.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }

        /// <summary>
        /// Asynchronously reads the contents of the BatteryCalibration1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the register payload.
        /// </returns>
        public async Task<ushort> ReadBatteryCalibration1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(BatteryCalibration1.Address));
            return BatteryCalibration1.GetPayload(reply);
        }

        /// <summary>
        /// Asynchronously reads the timestamped contents of the BatteryCalibration1 register.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous read operation. The <see cref="Task{TResult}.Result"/>
        /// property contains the timestamped register payload.
        /// </returns>
        public async Task<Timestamped<ushort>> ReadTimestampedBatteryCalibration1Async()
        {
            var reply = await CommandAsync(HarpCommand.ReadUInt16(BatteryCalibration1.Address));
            return BatteryCalibration1.GetTimestampedPayload(reply);
        }

        /// <summary>
        /// Asynchronously writes a value to the BatteryCalibration1 register.
        /// </summary>
        /// <param name="value">The value to be stored in the register.</param>
        /// <returns>The task object representing the asynchronous write operation.</returns>
        public async Task WriteBatteryCalibration1Async(ushort value)
        {
            var request = BatteryCalibration1.FromPayload(MessageType.Write, value);
            await CommandAsync(request);
        }
    }
}
