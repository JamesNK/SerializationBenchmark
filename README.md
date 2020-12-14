# SerializationBenchmarks

Compare serialization to a byte buffer for different packages and options;

|                            Method |       Mean |    Error |    StdDev |     Median |       Gen 0 |      Gen 1 | Gen 2 |  Allocated |
|---------------------------------- |-----------:|---------:|----------:|-----------:|------------:|-----------:|------:|-----------:|
|        MessagePack_SerializePlain |   428.3 ms |  8.53 ms |  23.64 ms |   425.1 ms |   2000.0000 |          - |     - |    9.61 MB |
|   MessagePack_SerializeCompressed |   667.2 ms | 12.46 ms |  28.87 ms |   661.9 ms |   2000.0000 |          - |     - |    9.61 MB |
|      MessagePack_SerializePickled |   966.4 ms | 19.30 ms |  36.73 ms |   964.5 ms |  18000.0000 |          - |     - |   71.95 MB |
|           Protobuf_SerializePlain | 1,550.0 ms | 42.94 ms | 121.11 ms | 1,501.3 ms |  11000.0000 |          - |     - |   44.25 MB |
|         Protobuf_SerializePickled | 1,746.3 ms | 92.04 ms | 268.47 ms | 1,639.5 ms |  27000.0000 |          - |     - |  109.94 MB |
|     SystemTextJson_SerializePlain |   706.4 ms | 14.00 ms |  28.59 ms |   708.0 ms |  56000.0000 |          - |     - |  228.04 MB |
|   SystemTextJson_SerializePickled | 1,189.5 ms | 20.85 ms |  34.26 ms | 1,179.4 ms |  23000.0000 |          - |     - |   93.61 MB |
|         Newtonsoft_SerializePlain | 1,536.2 ms | 29.59 ms |  59.09 ms | 1,516.7 ms | 288000.0000 | 38000.0000 |     - | 1156.16 MB |
|       Newtonsoft_SerializePickled | 2,180.6 ms | 43.57 ms |  86.00 ms | 2,157.2 ms | 307000.0000 | 25000.0000 |     - | 1230.24 MB |
|      MessagePack_DeserializePlain |   506.9 ms | 10.00 ms |  21.96 ms |   502.3 ms | 113000.0000 |          - |     - |  454.41 MB |
| MessagePack_DeserializeCompressed |   525.5 ms | 10.35 ms |  16.12 ms |   524.9 ms | 113000.0000 |          - |     - |  454.41 MB |
|    MessagePack_DeserializePickled |   560.9 ms | 11.05 ms |  16.55 ms |   558.2 ms | 140000.0000 | 20000.0000 |     - |  560.84 MB |
|         Protobuf_DeserializePlain |   667.0 ms | 13.13 ms |  14.05 ms |   662.6 ms | 121000.0000 |  2000.0000 |     - |  485.08 MB |
|       Protobuf_DeserializePickled |   731.2 ms | 14.43 ms |  27.45 ms |   731.8 ms | 149000.0000 | 24000.0000 |     - |  597.31 MB |
|   SystemTextJson_DeserializePlain | 1,526.6 ms | 13.82 ms |  11.54 ms | 1,527.9 ms | 125000.0000 |          - |     - |  501.25 MB |
| SystemTextJson_DeserializePickled | 1,643.8 ms | 20.20 ms |  17.91 ms | 1,643.1 ms | 177000.0000 | 25000.0000 |     - |  709.53 MB |
|       Newtonsoft_DeserializePlain | 2,658.0 ms | 35.56 ms |  33.27 ms | 2,662.1 ms | 256000.0000 |          - |     - | 1025.77 MB |
|     Newtonsoft_DeserializePickled | 2,778.4 ms | 55.52 ms |  57.01 ms | 2,771.3 ms | 307000.0000 | 61000.0000 |     - | 1234.13 MB |

Serialized data sizes for the different options:

_msgpack_plain         : 11135 bytes
_msgpack_comp          : 7033 bytes
_msgpack_pickled       : 6498 bytes
_protobuf_plain        : 11742 bytes
_protobuf_pickled      : 6863 bytes
_systemtextjson_plain  : 21812 bytes
_systemtextjson_pickled: 7760 bytes
_newtonsoft_plain      : 21807 bytes
_newtonsoft_pickled    : 7754 bytes
