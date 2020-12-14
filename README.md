# SerializationBenchmark

Compare serialization to a byte buffer for different packages and options.

|                            Method |       Mean |    Error |    StdDev |       Gen 0 |      Gen 1 | Gen 2 |  Allocated |
|---------------------------------- |-----------:|---------:|----------:|------------:|-----------:|------:|-----------:|
|        MessagePack_SerializePlain |   292.1 ms |  5.40 ms |   6.21 ms |   2000.0000 |          - |     - |    9.61 MB |
|   MessagePack_SerializeCompressed |   492.8 ms |  7.35 ms |  10.06 ms |   2000.0000 |          - |     - |    9.61 MB |
|      MessagePack_SerializePickled |   751.7 ms | 14.62 ms |  29.87 ms |  19000.0000 |          - |     - |   76.52 MB |
|        ProtobufNet_SerializePlain | 1,056.8 ms | 19.53 ms |  19.19 ms |  11000.0000 |          - |     - |   44.25 MB |
|      ProtobufNet_SerializePickled | 1,641.1 ms | 30.66 ms |  28.67 ms |  28000.0000 |          - |     - |  114.67 MB |
|           Protobuf_SerializePlain |   484.8 ms |  6.40 ms |   5.67 ms |   3000.0000 |          - |     - |   13.73 MB |
|         Protobuf_SerializePickled |   966.9 ms | 17.26 ms |  26.87 ms |  20000.0000 |          - |     - |    82.4 MB |
|     SystemTextJson_SerializePlain |   803.1 ms | 15.89 ms |  28.24 ms |  56000.0000 |          - |     - |  226.82 MB |
|   SystemTextJson_SerializePickled | 1,417.1 ms | 18.51 ms |  15.45 ms |  24000.0000 |          - |     - |   99.49 MB |
|         Newtonsoft_SerializePlain | 1,718.5 ms | 33.79 ms |  54.56 ms | 285000.0000 |          - |     - | 1153.03 MB |
|       Newtonsoft_SerializePickled | 2,288.0 ms | 25.30 ms |  21.13 ms | 307000.0000 | 43000.0000 |     - | 1232.83 MB |
|      MessagePack_DeserializePlain |   586.0 ms | 11.58 ms |  11.89 ms | 113000.0000 |  2000.0000 |     - |  452.13 MB |
| MessagePack_DeserializeCompressed |   620.9 ms | 12.37 ms |  20.32 ms | 113000.0000 |  2000.0000 |     - |  452.12 MB |
|    MessagePack_DeserializePickled |   705.9 ms | 19.34 ms |  52.60 ms | 139000.0000 | 20000.0000 |     - |   557.4 MB |
|      ProtobufNet_DeserializePlain |   771.3 ms | 12.71 ms |  18.23 ms | 121000.0000 |          - |     - |  482.79 MB |
|    ProtobufNet_DeserializePickled |   845.0 ms | 14.73 ms |  13.06 ms | 148000.0000 |  4000.0000 |     - |   593.8 MB |
|         Protobuf_DeserializePlain |   545.1 ms |  7.08 ms |   5.91 ms | 129000.0000 |  1000.0000 |     - |  518.34 MB |
|       Protobuf_DeserializePickled |   743.8 ms | 28.11 ms |  82.01 ms | 154000.0000 | 22000.0000 |     - |  617.75 MB |
|   SystemTextJson_DeserializePlain | 1,882.1 ms | 27.80 ms |  21.70 ms | 125000.0000 | 16000.0000 |     - |  498.96 MB |
| SystemTextJson_DeserializePickled | 2,075.7 ms | 43.62 ms | 122.31 ms | 176000.0000 |  1000.0000 |     - |  706.18 MB |
|       Newtonsoft_DeserializePlain | 3,098.0 ms | 60.45 ms |  97.61 ms | 255000.0000 | 54000.0000 |     - | 1021.27 MB |
|     Newtonsoft_DeserializePickled | 3,301.8 ms | 65.39 ms | 114.53 ms | 307000.0000 | 38000.0000 |     - | 1228.71 MB |

Serialized data sizes for the different options:

_msgpack_plain         : 11012 bytes
_msgpack_comp          : 7382 bytes
_msgpack_pickled       : 6996 bytes
_protobufnet_plain     : 11610 bytes
_protobufnet_pickled   : 7346 bytes
_protobuf_plain        : 10393 bytes
_protobuf_pickled      : 7164 bytes
_systemtextjson_plain  : 21686 bytes
_systemtextjson_pickled: 8360 bytes
_newtonsoft_plain      : 21671 bytes
_newtonsoft_pickled    : 8349 bytes

The *Plain varients use the respective technology directly in their best light, using reusable buffers
when possible.

The *Compressed variants use built-in compression functionality when available.

The *Pickled vriants use an external LZ4 compression library.
