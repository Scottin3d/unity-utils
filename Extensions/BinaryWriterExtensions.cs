using System.IO;
using In3d.Utilities.Helpers;

namespace UnityUtils.Extensions
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
