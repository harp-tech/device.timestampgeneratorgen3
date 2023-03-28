using Bonsai;
using Bonsai.Harp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Xml.Serialization;

namespace Harp.TimestampGeneratorGen3
{
    /// <summary>
    /// Generates events and processes commands for the TimestampGeneratorGen3 device connected
    /// at the specified serial port.
    /// </summary>
    [Combinator(MethodName = nameof(Generate))]
    [WorkflowElementCategory(ElementCategory.Source)]
    [Description("Generates events and processes commands for the TimestampGeneratorGen3 device.")]
    public partial class Device : Bonsai.Harp.Device, INamedElement
    {
        /// <summary>
        /// Represents the unique identity class of the <see cref="TimestampGeneratorGen3"/> device.
        /// This field is constant.
        /// </summary>
        public const int WhoAmI = 1158;

        /// <summary>
        /// Initializes a new instance of the <see cref="Device"/> class.
        /// </summary>
        public Device() : base(WhoAmI) { }

        string INamedElement.Name => nameof(TimestampGeneratorGen3);

        /// <summary>
        /// Gets a read-only mapping from address to register type.
        /// </summary>
        public static new IReadOnlyDictionary<int, Type> RegisterMap { get; } = new Dictionary<int, Type>
            (Bonsai.Harp.Device.RegisterMap.ToDictionary(entry => entry.Key, entry => entry.Value))
        {
            { 32, typeof(Config) },
            { 33, typeof(DevicesConnected) },
            { 34, typeof(RepeaterStatus) },
            { 35, typeof(BatteryRate) },
            { 36, typeof(Battery) },
            { 37, typeof(BatteryThresholdLow) },
            { 38, typeof(BatteryThresholdHigh) },
            { 39, typeof(BatteryCalibration0) },
            { 40, typeof(BatteryCalibration1) }
        };
    }

    /// <summary>
    /// Represents an operator that groups the sequence of <see cref="TimestampGeneratorGen3"/>" messages by register type.
    /// </summary>
    [Description("Groups the sequence of TimestampGeneratorGen3 messages by register type.")]
    public partial class GroupByRegister : Combinator<HarpMessage, IGroupedObservable<Type, HarpMessage>>
    {
        /// <summary>
        /// Groups an observable sequence of <see cref="TimestampGeneratorGen3"/> messages
        /// by register type.
        /// </summary>
        /// <param name="source">The sequence of Harp device messages.</param>
        /// <returns>
        /// A sequence of observable groups, each of which corresponds to a unique
        /// <see cref="TimestampGeneratorGen3"/> register.
        /// </returns>
        public override IObservable<IGroupedObservable<Type, HarpMessage>> Process(IObservable<HarpMessage> source)
        {
            return source.GroupBy(message => Device.RegisterMap[message.Address]);
        }
    }

    /// <summary>
    /// Represents an operator that filters register-specific messages
    /// reported by the <see cref="TimestampGeneratorGen3"/> device.
    /// </summary>
    /// <seealso cref="Config"/>
    /// <seealso cref="DevicesConnected"/>
    /// <seealso cref="RepeaterStatus"/>
    /// <seealso cref="BatteryRate"/>
    /// <seealso cref="Battery"/>
    /// <seealso cref="BatteryThresholdLow"/>
    /// <seealso cref="BatteryThresholdHigh"/>
    /// <seealso cref="BatteryCalibration0"/>
    /// <seealso cref="BatteryCalibration1"/>
    [XmlInclude(typeof(Config))]
    [XmlInclude(typeof(DevicesConnected))]
    [XmlInclude(typeof(RepeaterStatus))]
    [XmlInclude(typeof(BatteryRate))]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(BatteryThresholdLow))]
    [XmlInclude(typeof(BatteryThresholdHigh))]
    [XmlInclude(typeof(BatteryCalibration0))]
    [XmlInclude(typeof(BatteryCalibration1))]
    [Description("Filters register-specific messages reported by the TimestampGeneratorGen3 device.")]
    public class FilterMessage : FilterMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FilterMessage"/> class.
        /// </summary>
        public FilterMessage()
        {
            Register = new Config();
        }

        string INamedElement.Name
        {
            get => $"{nameof(TimestampGeneratorGen3)}.{GetElementDisplayName(Register)}";
        }
    }

    /// <summary>
    /// Represents an operator which filters and selects specific messages
    /// reported by the TimestampGeneratorGen3 device.
    /// </summary>
    /// <seealso cref="Config"/>
    /// <seealso cref="DevicesConnected"/>
    /// <seealso cref="RepeaterStatus"/>
    /// <seealso cref="BatteryRate"/>
    /// <seealso cref="Battery"/>
    /// <seealso cref="BatteryThresholdLow"/>
    /// <seealso cref="BatteryThresholdHigh"/>
    /// <seealso cref="BatteryCalibration0"/>
    /// <seealso cref="BatteryCalibration1"/>
    [XmlInclude(typeof(Config))]
    [XmlInclude(typeof(DevicesConnected))]
    [XmlInclude(typeof(RepeaterStatus))]
    [XmlInclude(typeof(BatteryRate))]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(BatteryThresholdLow))]
    [XmlInclude(typeof(BatteryThresholdHigh))]
    [XmlInclude(typeof(BatteryCalibration0))]
    [XmlInclude(typeof(BatteryCalibration1))]
    [XmlInclude(typeof(TimestampedConfig))]
    [XmlInclude(typeof(TimestampedDevicesConnected))]
    [XmlInclude(typeof(TimestampedRepeaterStatus))]
    [XmlInclude(typeof(TimestampedBatteryRate))]
    [XmlInclude(typeof(TimestampedBattery))]
    [XmlInclude(typeof(TimestampedBatteryThresholdLow))]
    [XmlInclude(typeof(TimestampedBatteryThresholdHigh))]
    [XmlInclude(typeof(TimestampedBatteryCalibration0))]
    [XmlInclude(typeof(TimestampedBatteryCalibration1))]
    [Description("Filters and selects specific messages reported by the TimestampGeneratorGen3 device.")]
    public partial class Parse : ParseBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parse"/> class.
        /// </summary>
        public Parse()
        {
            Register = new Config();
        }

        string INamedElement.Name => $"{nameof(TimestampGeneratorGen3)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents an operator which formats a sequence of values as specific
    /// TimestampGeneratorGen3 register messages.
    /// </summary>
    /// <seealso cref="Config"/>
    /// <seealso cref="DevicesConnected"/>
    /// <seealso cref="RepeaterStatus"/>
    /// <seealso cref="BatteryRate"/>
    /// <seealso cref="Battery"/>
    /// <seealso cref="BatteryThresholdLow"/>
    /// <seealso cref="BatteryThresholdHigh"/>
    /// <seealso cref="BatteryCalibration0"/>
    /// <seealso cref="BatteryCalibration1"/>
    [XmlInclude(typeof(Config))]
    [XmlInclude(typeof(DevicesConnected))]
    [XmlInclude(typeof(RepeaterStatus))]
    [XmlInclude(typeof(BatteryRate))]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(BatteryThresholdLow))]
    [XmlInclude(typeof(BatteryThresholdHigh))]
    [XmlInclude(typeof(BatteryCalibration0))]
    [XmlInclude(typeof(BatteryCalibration1))]
    [Description("Formats a sequence of values as specific TimestampGeneratorGen3 register messages.")]
    public partial class Format : FormatBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Format"/> class.
        /// </summary>
        public Format()
        {
            Register = new Config();
        }

        string INamedElement.Name => $"{nameof(TimestampGeneratorGen3)}.{GetElementDisplayName(Register)}";
    }

    /// <summary>
    /// Represents a register that specifies the device configuration.
    /// </summary>
    [Description("Specifies the device configuration")]
    public partial class Config
    {
        /// <summary>
        /// Represents the address of the <see cref="Config"/> register. This field is constant.
        /// </summary>
        public const int Address = 32;

        /// <summary>
        /// Represents the payload type of the <see cref="Config"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="Config"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Config"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Config"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Config"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Config"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Config"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Config"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Config register.
    /// </summary>
    /// <seealso cref="Config"/>
    [Description("Filters and selects timestamped messages from the Config register.")]
    public partial class TimestampedConfig
    {
        /// <summary>
        /// Represents the address of the <see cref="Config"/> register. This field is constant.
        /// </summary>
        public const int Address = Config.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Config"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return Config.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that reads whether the port has a device connected to (bitmask).
    /// </summary>
    [Description("Reads whether the port has a device connected to (bitmask)")]
    public partial class DevicesConnected
    {
        /// <summary>
        /// Represents the address of the <see cref="DevicesConnected"/> register. This field is constant.
        /// </summary>
        public const int Address = 33;

        /// <summary>
        /// Represents the payload type of the <see cref="DevicesConnected"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="DevicesConnected"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="DevicesConnected"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="DevicesConnected"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="DevicesConnected"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="DevicesConnected"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="DevicesConnected"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="DevicesConnected"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// DevicesConnected register.
    /// </summary>
    /// <seealso cref="DevicesConnected"/>
    [Description("Filters and selects timestamped messages from the DevicesConnected register.")]
    public partial class TimestampedDevicesConnected
    {
        /// <summary>
        /// Represents the address of the <see cref="DevicesConnected"/> register. This field is constant.
        /// </summary>
        public const int Address = DevicesConnected.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="DevicesConnected"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return DevicesConnected.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that check whether device is a repeater or spreading internal timestamp.
    /// </summary>
    [Description("Check whether device is a repeater or spreading internal timestamp")]
    public partial class RepeaterStatus
    {
        /// <summary>
        /// Represents the address of the <see cref="RepeaterStatus"/> register. This field is constant.
        /// </summary>
        public const int Address = 34;

        /// <summary>
        /// Represents the payload type of the <see cref="RepeaterStatus"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="RepeaterStatus"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="RepeaterStatus"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="RepeaterStatus"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="RepeaterStatus"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="RepeaterStatus"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="RepeaterStatus"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="RepeaterStatus"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// RepeaterStatus register.
    /// </summary>
    /// <seealso cref="RepeaterStatus"/>
    [Description("Filters and selects timestamped messages from the RepeaterStatus register.")]
    public partial class TimestampedRepeaterStatus
    {
        /// <summary>
        /// Represents the address of the <see cref="RepeaterStatus"/> register. This field is constant.
        /// </summary>
        public const int Address = RepeaterStatus.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="RepeaterStatus"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return RepeaterStatus.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that configure how often the battery calue is sent to computer.
    /// </summary>
    [Description("Configure how often the battery calue is sent to computer")]
    public partial class BatteryRate
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryRate"/> register. This field is constant.
        /// </summary>
        public const int Address = 35;

        /// <summary>
        /// Represents the payload type of the <see cref="BatteryRate"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U8;

        /// <summary>
        /// Represents the length of the <see cref="BatteryRate"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="BatteryRate"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static byte GetPayload(HarpMessage message)
        {
            return message.GetPayloadByte();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="BatteryRate"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadByte();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="BatteryRate"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryRate"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="BatteryRate"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryRate"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, byte value)
        {
            return HarpMessage.FromByte(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// BatteryRate register.
    /// </summary>
    /// <seealso cref="BatteryRate"/>
    [Description("Filters and selects timestamped messages from the BatteryRate register.")]
    public partial class TimestampedBatteryRate
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryRate"/> register. This field is constant.
        /// </summary>
        public const int Address = BatteryRate.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="BatteryRate"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<byte> GetPayload(HarpMessage message)
        {
            return BatteryRate.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that reads the current battery charge.
    /// </summary>
    [Description("Reads the current battery charge")]
    public partial class Battery
    {
        /// <summary>
        /// Represents the address of the <see cref="Battery"/> register. This field is constant.
        /// </summary>
        public const int Address = 36;

        /// <summary>
        /// Represents the payload type of the <see cref="Battery"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="Battery"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="Battery"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="Battery"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="Battery"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Battery"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="Battery"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="Battery"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// Battery register.
    /// </summary>
    /// <seealso cref="Battery"/>
    [Description("Filters and selects timestamped messages from the Battery register.")]
    public partial class TimestampedBattery
    {
        /// <summary>
        /// Represents the address of the <see cref="Battery"/> register. This field is constant.
        /// </summary>
        public const int Address = Battery.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="Battery"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return Battery.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies the low threshold from where the battery should start to be charged.
    /// </summary>
    [Description("Specifies the low threshold from where the battery should start to be charged")]
    public partial class BatteryThresholdLow
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryThresholdLow"/> register. This field is constant.
        /// </summary>
        public const int Address = 37;

        /// <summary>
        /// Represents the payload type of the <see cref="BatteryThresholdLow"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="BatteryThresholdLow"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="BatteryThresholdLow"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="BatteryThresholdLow"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="BatteryThresholdLow"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryThresholdLow"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="BatteryThresholdLow"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryThresholdLow"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// BatteryThresholdLow register.
    /// </summary>
    /// <seealso cref="BatteryThresholdLow"/>
    [Description("Filters and selects timestamped messages from the BatteryThresholdLow register.")]
    public partial class TimestampedBatteryThresholdLow
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryThresholdLow"/> register. This field is constant.
        /// </summary>
        public const int Address = BatteryThresholdLow.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="BatteryThresholdLow"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return BatteryThresholdLow.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that specifies the high threshold from where the battery stops being charged.
    /// </summary>
    [Description("Specifies the high threshold from where the battery stops being charged")]
    public partial class BatteryThresholdHigh
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryThresholdHigh"/> register. This field is constant.
        /// </summary>
        public const int Address = 38;

        /// <summary>
        /// Represents the payload type of the <see cref="BatteryThresholdHigh"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.Float;

        /// <summary>
        /// Represents the length of the <see cref="BatteryThresholdHigh"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="BatteryThresholdHigh"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static float GetPayload(HarpMessage message)
        {
            return message.GetPayloadSingle();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="BatteryThresholdHigh"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadSingle();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="BatteryThresholdHigh"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryThresholdHigh"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="BatteryThresholdHigh"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryThresholdHigh"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, float value)
        {
            return HarpMessage.FromSingle(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// BatteryThresholdHigh register.
    /// </summary>
    /// <seealso cref="BatteryThresholdHigh"/>
    [Description("Filters and selects timestamped messages from the BatteryThresholdHigh register.")]
    public partial class TimestampedBatteryThresholdHigh
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryThresholdHigh"/> register. This field is constant.
        /// </summary>
        public const int Address = BatteryThresholdHigh.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="BatteryThresholdHigh"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<float> GetPayload(HarpMessage message)
        {
            return BatteryThresholdHigh.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that manipulates messages from register BatteryCalibration0.
    /// </summary>
    [Description("")]
    public partial class BatteryCalibration0
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryCalibration0"/> register. This field is constant.
        /// </summary>
        public const int Address = 39;

        /// <summary>
        /// Represents the payload type of the <see cref="BatteryCalibration0"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="BatteryCalibration0"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="BatteryCalibration0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="BatteryCalibration0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="BatteryCalibration0"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryCalibration0"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="BatteryCalibration0"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryCalibration0"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// BatteryCalibration0 register.
    /// </summary>
    /// <seealso cref="BatteryCalibration0"/>
    [Description("Filters and selects timestamped messages from the BatteryCalibration0 register.")]
    public partial class TimestampedBatteryCalibration0
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryCalibration0"/> register. This field is constant.
        /// </summary>
        public const int Address = BatteryCalibration0.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="BatteryCalibration0"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return BatteryCalibration0.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents a register that manipulates messages from register BatteryCalibration1.
    /// </summary>
    [Description("")]
    public partial class BatteryCalibration1
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryCalibration1"/> register. This field is constant.
        /// </summary>
        public const int Address = 40;

        /// <summary>
        /// Represents the payload type of the <see cref="BatteryCalibration1"/> register. This field is constant.
        /// </summary>
        public const PayloadType RegisterType = PayloadType.U16;

        /// <summary>
        /// Represents the length of the <see cref="BatteryCalibration1"/> register. This field is constant.
        /// </summary>
        public const int RegisterLength = 1;

        /// <summary>
        /// Returns the payload data for <see cref="BatteryCalibration1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the message payload.</returns>
        public static ushort GetPayload(HarpMessage message)
        {
            return message.GetPayloadUInt16();
        }

        /// <summary>
        /// Returns the timestamped payload data for <see cref="BatteryCalibration1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetTimestampedPayload(HarpMessage message)
        {
            return message.GetTimestampedPayloadUInt16();
        }

        /// <summary>
        /// Returns a Harp message for the <see cref="BatteryCalibration1"/> register.
        /// </summary>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryCalibration1"/> register
        /// with the specified message type and payload.
        /// </returns>
        public static HarpMessage FromPayload(MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, messageType, value);
        }

        /// <summary>
        /// Returns a timestamped Harp message for the <see cref="BatteryCalibration1"/>
        /// register.
        /// </summary>
        /// <param name="timestamp">The timestamp of the message payload, in seconds.</param>
        /// <param name="messageType">The type of the Harp message.</param>
        /// <param name="value">The value to be stored in the message payload.</param>
        /// <returns>
        /// A <see cref="HarpMessage"/> object for the <see cref="BatteryCalibration1"/> register
        /// with the specified message type, timestamp, and payload.
        /// </returns>
        public static HarpMessage FromPayload(double timestamp, MessageType messageType, ushort value)
        {
            return HarpMessage.FromUInt16(Address, timestamp, messageType, value);
        }
    }

    /// <summary>
    /// Provides methods for manipulating timestamped messages from the
    /// BatteryCalibration1 register.
    /// </summary>
    /// <seealso cref="BatteryCalibration1"/>
    [Description("Filters and selects timestamped messages from the BatteryCalibration1 register.")]
    public partial class TimestampedBatteryCalibration1
    {
        /// <summary>
        /// Represents the address of the <see cref="BatteryCalibration1"/> register. This field is constant.
        /// </summary>
        public const int Address = BatteryCalibration1.Address;

        /// <summary>
        /// Returns timestamped payload data for <see cref="BatteryCalibration1"/> register messages.
        /// </summary>
        /// <param name="message">A <see cref="HarpMessage"/> object representing the register message.</param>
        /// <returns>A value representing the timestamped message payload.</returns>
        public static Timestamped<ushort> GetPayload(HarpMessage message)
        {
            return BatteryCalibration1.GetTimestampedPayload(message);
        }
    }

    /// <summary>
    /// Represents an operator which creates standard message payloads for the
    /// TimestampGeneratorGen3 device.
    /// </summary>
    /// <seealso cref="CreateConfigPayload"/>
    /// <seealso cref="CreateDevicesConnectedPayload"/>
    /// <seealso cref="CreateRepeaterStatusPayload"/>
    /// <seealso cref="CreateBatteryRatePayload"/>
    /// <seealso cref="CreateBatteryPayload"/>
    /// <seealso cref="CreateBatteryThresholdLowPayload"/>
    /// <seealso cref="CreateBatteryThresholdHighPayload"/>
    /// <seealso cref="CreateBatteryCalibration0Payload"/>
    /// <seealso cref="CreateBatteryCalibration1Payload"/>
    [XmlInclude(typeof(CreateConfigPayload))]
    [XmlInclude(typeof(CreateDevicesConnectedPayload))]
    [XmlInclude(typeof(CreateRepeaterStatusPayload))]
    [XmlInclude(typeof(CreateBatteryRatePayload))]
    [XmlInclude(typeof(CreateBatteryPayload))]
    [XmlInclude(typeof(CreateBatteryThresholdLowPayload))]
    [XmlInclude(typeof(CreateBatteryThresholdHighPayload))]
    [XmlInclude(typeof(CreateBatteryCalibration0Payload))]
    [XmlInclude(typeof(CreateBatteryCalibration1Payload))]
    [Description("Creates standard message payloads for the TimestampGeneratorGen3 device.")]
    public partial class CreateMessage : CreateMessageBuilder, INamedElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMessage"/> class.
        /// </summary>
        public CreateMessage()
        {
            Payload = new CreateConfigPayload();
        }

        string INamedElement.Name => $"{nameof(TimestampGeneratorGen3)}.{GetElementDisplayName(Payload)}";
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that specifies the device configuration.
    /// </summary>
    [DisplayName("ConfigPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that specifies the device configuration.")]
    public partial class CreateConfigPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that specifies the device configuration.
        /// </summary>
        [Description("The value that specifies the device configuration.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that specifies the device configuration.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that specifies the device configuration.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Config.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that reads whether the port has a device connected to (bitmask).
    /// </summary>
    [DisplayName("DevicesConnectedPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that reads whether the port has a device connected to (bitmask).")]
    public partial class CreateDevicesConnectedPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that reads whether the port has a device connected to (bitmask).
        /// </summary>
        [Description("The value that reads whether the port has a device connected to (bitmask).")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that reads whether the port has a device connected to (bitmask).
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that reads whether the port has a device connected to (bitmask).
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => DevicesConnected.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that check whether device is a repeater or spreading internal timestamp.
    /// </summary>
    [DisplayName("RepeaterStatusPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that check whether device is a repeater or spreading internal timestamp.")]
    public partial class CreateRepeaterStatusPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that check whether device is a repeater or spreading internal timestamp.
        /// </summary>
        [Description("The value that check whether device is a repeater or spreading internal timestamp.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that check whether device is a repeater or spreading internal timestamp.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that check whether device is a repeater or spreading internal timestamp.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => RepeaterStatus.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that configure how often the battery calue is sent to computer.
    /// </summary>
    [DisplayName("BatteryRatePayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that configure how often the battery calue is sent to computer.")]
    public partial class CreateBatteryRatePayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that configure how often the battery calue is sent to computer.
        /// </summary>
        [Description("The value that configure how often the battery calue is sent to computer.")]
        public byte Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that configure how often the battery calue is sent to computer.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that configure how often the battery calue is sent to computer.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => BatteryRate.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that reads the current battery charge.
    /// </summary>
    [DisplayName("BatteryPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that reads the current battery charge.")]
    public partial class CreateBatteryPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that reads the current battery charge.
        /// </summary>
        [Description("The value that reads the current battery charge.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that reads the current battery charge.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that reads the current battery charge.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => Battery.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that specifies the low threshold from where the battery should start to be charged.
    /// </summary>
    [DisplayName("BatteryThresholdLowPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that specifies the low threshold from where the battery should start to be charged.")]
    public partial class CreateBatteryThresholdLowPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that specifies the low threshold from where the battery should start to be charged.
        /// </summary>
        [Description("The value that specifies the low threshold from where the battery should start to be charged.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that specifies the low threshold from where the battery should start to be charged.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that specifies the low threshold from where the battery should start to be charged.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => BatteryThresholdLow.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// that specifies the high threshold from where the battery stops being charged.
    /// </summary>
    [DisplayName("BatteryThresholdHighPayload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads that specifies the high threshold from where the battery stops being charged.")]
    public partial class CreateBatteryThresholdHighPayload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value that specifies the high threshold from where the battery stops being charged.
        /// </summary>
        [Description("The value that specifies the high threshold from where the battery stops being charged.")]
        public float Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// that specifies the high threshold from where the battery stops being charged.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// that specifies the high threshold from where the battery stops being charged.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => BatteryThresholdHigh.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// for register BatteryCalibration0.
    /// </summary>
    [DisplayName("BatteryCalibration0Payload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads for register BatteryCalibration0.")]
    public partial class CreateBatteryCalibration0Payload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value for register BatteryCalibration0.
        /// </summary>
        [Description("The value for register BatteryCalibration0.")]
        public ushort Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// for register BatteryCalibration0.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// for register BatteryCalibration0.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => BatteryCalibration0.FromPayload(MessageType, Value));
        }
    }

    /// <summary>
    /// Represents an operator that creates a sequence of message payloads
    /// for register BatteryCalibration1.
    /// </summary>
    [DisplayName("BatteryCalibration1Payload")]
    [WorkflowElementCategory(ElementCategory.Transform)]
    [Description("Creates a sequence of message payloads for register BatteryCalibration1.")]
    public partial class CreateBatteryCalibration1Payload : HarpCombinator
    {
        /// <summary>
        /// Gets or sets the value for register BatteryCalibration1.
        /// </summary>
        [Description("The value for register BatteryCalibration1.")]
        public ushort Value { get; set; }

        /// <summary>
        /// Creates an observable sequence that contains a single message
        /// for register BatteryCalibration1.
        /// </summary>
        /// <returns>
        /// A sequence containing a single <see cref="HarpMessage"/> object
        /// representing the created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process()
        {
            return Process(Observable.Return(System.Reactive.Unit.Default));
        }

        /// <summary>
        /// Creates an observable sequence of message payloads
        /// for register BatteryCalibration1.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements in the <paramref name="source"/> sequence.
        /// </typeparam>
        /// <param name="source">
        /// The sequence containing the notifications used for emitting message payloads.
        /// </param>
        /// <returns>
        /// A sequence of <see cref="HarpMessage"/> objects representing each
        /// created message payload.
        /// </returns>
        public IObservable<HarpMessage> Process<TSource>(IObservable<TSource> source)
        {
            return source.Select(_ => BatteryCalibration1.FromPayload(MessageType, Value));
        }
    }
}