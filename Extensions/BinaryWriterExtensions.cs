﻿using System.IO;
using Utilities.Helpers;
using Utilities.Serializables;

namespace Utilities.Extensions
{
public static class BinaryWriterExtensions {
    public static void Write(this BinaryWriter writer, SerializableGuid guid) {
        writer.Write(guid.Part1);
        writer.Write(guid.Part2);
        writer.Write(guid.Part3);
        writer.Write(guid.Part4);
    }
}
}
