# SerializationBenchmark

Compare serialization to a byte buffer for different packages and options.

|                            Method |       Mean |    Error |    StdDev |     Median |       Gen 0 |      Gen 1 | Gen 2 |  Allocated |
|---------------------------------- |-----------:|---------:|----------:|-----------:|------------:|-----------:|------:|-----------:|
|        MessagePack_SerializePlain |   285.8 ms |  5.16 ms |   6.34 ms |   285.2 ms |   2000.0000 |          - |     - |    9.61 MB |
|   MessagePack_SerializeCompressed |   459.8 ms |  7.74 ms |   8.28 ms |   457.0 ms |   2000.0000 |          - |     - |    9.61 MB |
|      MessagePack_SerializePickled |   665.7 ms |  8.36 ms |   7.82 ms |   667.0 ms |  19000.0000 |          - |     - |    76.6 MB |
|        ProtobufNet_SerializePlain |   966.4 ms | 15.07 ms |  14.10 ms |   962.9 ms |  11000.0000 |          - |     - |   44.25 MB |
|      ProtobufNet_SerializePickled | 1,431.0 ms | 11.22 ms |   9.95 ms | 1,432.1 ms |  28000.0000 |          - |     - |  114.67 MB |
|           Protobuf_SerializePlain |   407.7 ms |  7.97 ms |   8.19 ms |   404.6 ms |   3000.0000 |          - |     - |   13.73 MB |
|         Protobuf_SerializePickled |   832.8 ms | 10.12 ms |   8.45 ms |   833.4 ms |  20000.0000 |          - |     - |   82.34 MB |
|     SystemTextJson_SerializePlain |   665.1 ms |  9.16 ms |   8.57 ms |   667.4 ms |  56000.0000 |          - |     - |  227.05 MB |
|   SystemTextJson_SerializePickled | 1,245.4 ms | 21.79 ms |  20.39 ms | 1,238.6 ms |  25000.0000 |          - |     - |   99.72 MB |
|         Newtonsoft_SerializePlain | 1,379.4 ms | 17.30 ms |  15.33 ms | 1,382.7 ms | 285000.0000 |          - |     - | 1152.95 MB |
|       Newtonsoft_SerializePickled | 2,489.2 ms | 48.54 ms |  45.41 ms | 2,505.1 ms | 307000.0000 | 43000.0000 |     - | 1233.14 MB |
|      MessagePack_DeserializePlain |   557.3 ms | 10.15 ms |   7.93 ms |   555.1 ms | 113000.0000 |  2000.0000 |     - |  452.12 MB |
| MessagePack_DeserializeCompressed |   594.9 ms | 11.35 ms |  10.61 ms |   598.0 ms | 113000.0000 |  2000.0000 |     - |  452.12 MB |
|    MessagePack_DeserializePickled |   595.6 ms |  5.96 ms |   5.58 ms |   594.8 ms | 139000.0000 | 20000.0000 |     - |   557.4 MB |
|      ProtobufNet_DeserializePlain |   675.9 ms |  3.07 ms |   2.72 ms |   676.3 ms | 121000.0000 |          - |     - |  482.79 MB |
|    ProtobufNet_DeserializePickled |   744.8 ms |  7.39 ms |   6.91 ms |   743.9 ms | 148000.0000 |  4000.0000 |     - |   593.8 MB |
|         Protobuf_DeserializePlain |   473.5 ms |  2.97 ms |   2.78 ms |   473.0 ms | 129000.0000 |  1000.0000 |     - |  518.34 MB |
|       Protobuf_DeserializePickled |   534.5 ms |  2.70 ms |   2.11 ms |   534.3 ms | 155000.0000 |          - |     - |  617.83 MB |
|   SystemTextJson_DeserializePlain | 1,518.7 ms |  6.53 ms |   5.79 ms | 1,517.5 ms | 125000.0000 | 16000.0000 |     - |  498.96 MB |
| SystemTextJson_DeserializePickled | 1,630.6 ms |  8.88 ms |   8.30 ms | 1,631.5 ms | 176000.0000 |  1000.0000 |     - |   706.1 MB |
|       Newtonsoft_DeserializePlain | 2,668.6 ms | 46.57 ms |  41.29 ms | 2,679.5 ms | 255000.0000 | 54000.0000 |     - | 1021.35 MB |
|     Newtonsoft_DeserializePickled | 2,896.3 ms | 54.84 ms | 147.31 ms | 2,843.6 ms | 307000.0000 | 38000.0000 |     - | 1228.49 MB |

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
