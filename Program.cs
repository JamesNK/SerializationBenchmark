using System;
using System.Buffers;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SerializationBenchmark
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        const int Iterations = 10000;

        private static readonly ArrayBufferWriter<byte> _msgpack_plain;
        private static readonly ArrayBufferWriter<byte> _msgpack_comp;
        private static readonly byte[] _msgpack_pickled;
        private static readonly ArrayBufferWriter<byte> _protobuf_plain;
        private static readonly byte[] _protobuf_pickled;
        private static readonly byte[] _systemtextjson_plain;
        private static readonly byte[] _systemtextjson_pickled;
        private static readonly byte[] _newtonsoft_plain;
        private static readonly byte[] _newtonsoft_pickled;

        static Benchmarks()
        {
            var r = new Random();
            foreach (var l in TestData.TestValue.Licenses)
            {
                foreach (var sp in l.ServicePlans)
                {
                    sp.Count = r.Next();
                }
            }

            _msgpack_plain = Serializers.MessagePack_SerializePlain(TestData.TestValue);
            _msgpack_comp = Serializers.MessagePack_SerializeCompressed(TestData.TestValue);
            _msgpack_pickled = Serializers.MessagePack_SerializePickled(TestData.TestValue);
            _protobuf_plain = Serializers.Protobuf_SerializePlain(TestData.TestValue);
            _protobuf_pickled = Serializers.Protobuf_SerializePickled(TestData.TestValue);
            _systemtextjson_plain = Serializers.SystemTextJson_SerializePlain(TestData.TestValue);
            _systemtextjson_pickled = Serializers.SystemTextJson_SerializePickled(TestData.TestValue);
            _newtonsoft_plain = Serializers.Newtonsoft_SerializePlain(TestData.TestValue);
            _newtonsoft_pickled = Serializers.Newtonsoft_SerializePickled(TestData.TestValue);

            Console.WriteLine($"_msgpack_plain         : {_msgpack_plain.WrittenCount} bytes");
            Console.WriteLine($"_msgpack_comp          : {_msgpack_comp.WrittenCount} bytes");
            Console.WriteLine($"_msgpack_pickled       : {_msgpack_pickled.Length} bytes");
            Console.WriteLine($"_protobuf_plain        : {_protobuf_plain.WrittenCount} bytes");
            Console.WriteLine($"_protobuf_pickled      : {_protobuf_pickled.Length} bytes");
            Console.WriteLine($"_systemtextjson_plain  : {_systemtextjson_plain.Length} bytes");
            Console.WriteLine($"_systemtextjson_pickled: {_systemtextjson_pickled.Length} bytes");
            Console.WriteLine($"_newtonsoft_plain      : {_newtonsoft_plain.Length} bytes");
            Console.WriteLine($"_newtonsoft_pickled    : {_newtonsoft_pickled.Length} bytes");
        }

        [Benchmark]
        public void MessagePack_SerializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var br = Serializers.MessagePack_SerializePlain(TestData.TestValue);
                Serializers.Return(br);
            }
        }

        [Benchmark]
        public void MessagePack_SerializeCompressed()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var br = Serializers.MessagePack_SerializeCompressed(TestData.TestValue);
                Serializers.Return(br);
            }
        }

        [Benchmark]
        public void MessagePack_SerializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.MessagePack_SerializePickled(TestData.TestValue);
            }
        }

        [Benchmark]
        public void Protobuf_SerializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                var br = Serializers.Protobuf_SerializePlain(TestData.TestValue);
                Serializers.Return(br);
            }
        }

        [Benchmark]
        public void Protobuf_SerializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Protobuf_SerializePickled(TestData.TestValue);
            }
        }

        [Benchmark]
        public void SystemTextJson_SerializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.SystemTextJson_SerializePlain(TestData.TestValue);
            }
        }

        [Benchmark]
        public void SystemTextJson_SerializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.SystemTextJson_SerializePickled(TestData.TestValue);
            }
        }

        [Benchmark]
        public void Newtonsoft_SerializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Newtonsoft_SerializePlain(TestData.TestValue);
            }
        }

        [Benchmark]
        public void Newtonsoft_SerializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Newtonsoft_SerializePickled(TestData.TestValue);
            }
        }

        [Benchmark]
        public void MessagePack_DeserializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.MessagePack_DeserialzePlain<UserLicensesResponse>(_msgpack_plain.WrittenMemory);
            }
        }

        [Benchmark]
        public void MessagePack_DeserializeCompressed()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.MessagePack_DeserializeCompressed<UserLicensesResponse>(_msgpack_comp.WrittenMemory);
            }
        }

        [Benchmark]
        public void MessagePack_DeserializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.MessagePack_DeserializePickled<UserLicensesResponse>(_msgpack_pickled);
            }
        }

        [Benchmark]
        public void Protobuf_DeserializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Protobuf_DeserializePlain<UserLicensesResponse>(_protobuf_plain.WrittenSpan);
            }
        }

        [Benchmark]
        public void Protobuf_DeserializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Protobuf_DeserializePicked<UserLicensesResponse>(_protobuf_pickled);
            }
        }

        [Benchmark]
        public void SystemTextJson_DeserializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.SystemTextJson_DeserializePlain<UserLicensesResponse>(_systemtextjson_plain);
            }
        }

        [Benchmark]
        public void SystemTextJson_DeserializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.SystemTextJson_DeserializedPickled<UserLicensesResponse>(_systemtextjson_pickled);
            }
        }

        [Benchmark]
        public void Newtonsoft_DeserializePlain()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Newtonsoft_DeserializePlain<UserLicensesResponse>(_newtonsoft_plain);
            }
        }

        [Benchmark]
        public void Newtonsoft_DeserializePickled()
        {
            for (int i = 0; i < Iterations; i++)
            {
                _ = Serializers.Newtonsoft_DeserializedPickled<UserLicensesResponse>(_newtonsoft_pickled);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
//            var b = new Benchmarks();
//            b.Protobuf_DeserializePickled();

            _ = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
