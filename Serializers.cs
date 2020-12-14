using Google.Protobuf;
using K4os.Compression.LZ4;
using MessagePack;
using Newtonsoft.Json;
using System;
using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings;
using System.Text.Json;

namespace SerializationBenchmark
{
    internal static class Serializers
    {
        private static readonly BufferWriterPool<byte> _pool = new();

        private static readonly MessagePackSerializerOptions _options = MessagePackSerializerOptions.Standard
            .WithOmitAssemblyVersion(true);

        private static readonly MessagePackSerializerOptions _compressingOptions = MessagePackSerializerOptions.Standard
            .WithOmitAssemblyVersion(true)
            .WithCompression(MessagePackCompression.Lz4BlockArray);

        public static ArrayBufferWriter<byte> MessagePack_SerializePlain<T>(T data)
        {
            var br = _pool.Rent();
            MessagePackSerializer.Serialize(br, data);
            return br;
        }

        public static T MessagePack_DeserialzePlain<T>(ReadOnlyMemory<byte> data)
        {
            return MessagePackSerializer.Deserialize<T>(data, _options);
        }

        public static byte[] MessagePack_SerializePickled<T>(T data)
        {
            var br = _pool.Rent();
            MessagePackSerializer.Serialize(br, data, _options);
            var result = LZ4Pickler.Pickle(br.WrittenSpan);
            _pool.Return(br);

            return result;
        }

        public static T MessagePack_DeserializePickled<T>(ReadOnlySpan<byte> data)
        {
            return MessagePackSerializer.Deserialize<T>(LZ4Pickler.Unpickle(data), _options);
        }

        public static ArrayBufferWriter<byte> MessagePack_SerializeCompressed<T>(T data)
        {
            var br = _pool.Rent();
            MessagePackSerializer.Serialize(br, data, _compressingOptions);
            return br;
        }

        public static T MessagePack_DeserializeCompressed<T>(ReadOnlyMemory<byte> data)
        {
            return MessagePackSerializer.Deserialize<T>(data, _compressingOptions);
        }

        public static ArrayBufferWriter<byte> Protobuf_SerializePlain<T>(T data)
        {
            var br = _pool.Rent();
            ProtoBuf.Serializer.Serialize(br, data);
            return br;
        }

        public static T Protobuf_DeserializePlain<T>(ReadOnlySpan<byte> data)
        {
            return ProtoBuf.Serializer.Deserialize<T>(data);
        }

        public static byte[] Protobuf_SerializePickled<T>(T data)
        {
            var br = _pool.Rent();
            ProtoBuf.Serializer.Serialize(br, data);
            var result = LZ4Pickler.Pickle(br.WrittenSpan);
            _pool.Return(br);

            return result;
        }

        public static T Protobuf_DeserializePicked<T>(ReadOnlySpan<byte> data)
        {
            return ProtoBuf.Serializer.Deserialize<T>(new ReadOnlyMemory<byte>(LZ4Pickler.Unpickle(data)));
        }

        public static byte[] SystemTextJson_SerializePlain<T>(T data)
        {
            return System.Text.Json.JsonSerializer.SerializeToUtf8Bytes<T>(data);
        }

        public static T SystemTextJson_DeserializePlain<T>(ReadOnlySpan<byte> data)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(data);
        }

        public static byte[] SystemTextJson_SerializePickled<T>(T data)
        {
            var br = _pool.Rent();
            System.Text.Json.JsonSerializer.Serialize(new Utf8JsonWriter(br), data);
            var result = LZ4Pickler.Pickle(br.WrittenSpan);
            _pool.Return(br);

            return result;
        }

        public static T SystemTextJson_DeserializedPickled<T>(ReadOnlySpan<byte> data)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(LZ4Pickler.Unpickle(data));
        }

        public static byte[] Newtonsoft_SerializePlain<T>(T data)
        {
            return UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }

        public static T Newtonsoft_DeserializePlain<T>(ReadOnlySpan<byte> data)
        {
            return JsonConvert.DeserializeObject<T>(UTF8Encoding.UTF8.GetString(data));
        }

        public static byte[] Newtonsoft_SerializePickled<T>(T data)
        {
            return LZ4Pickler.Pickle(UTF8Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
        }

        public static T Newtonsoft_DeserializedPickled<T>(ReadOnlySpan<byte> data)
        {
            return JsonConvert.DeserializeObject<T>(UTF8Encoding.UTF8.GetString(LZ4Pickler.Unpickle(data)));
        }

        public static ArrayBufferWriter<byte> GoogleProtobuf_SerializePlain<T>(T data) where T : IBufferMessage
        {
            var br = _pool.Rent();
            data.WriteTo(br);
            return br;
        }

        public static T GoogleProtobuf_DeserializePlain<T>(ReadOnlyMemory<byte> data, MessageParser<T> messageParser) where T : IMessage<T>
        {
            return messageParser.ParseFrom(new ReadOnlySequence<byte>(data));
        }

        public static byte[] GoogleProtobuf_SerializePickled<T>(T data) where T : IBufferMessage
        {
            var br = _pool.Rent();
            data.WriteTo(br);
            var result = LZ4Pickler.Pickle(br.WrittenSpan);
            _pool.Return(br);

            return result;
        }

        public static T GoogleProtobuf_DeserializePicked<T>(ReadOnlySpan<byte> data, MessageParser<T> messageParser) where T : IMessage<T>
        {
            return messageParser.ParseFrom(new ReadOnlySequence<byte>(LZ4Pickler.Unpickle(data)));
        }

        public static void Return(ArrayBufferWriter<byte> writer)
        {
            _pool.Return(writer);
        }
    }
}
