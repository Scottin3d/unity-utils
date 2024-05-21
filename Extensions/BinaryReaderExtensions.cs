using System.IO;
using In3d.Utilities.Helpers;

namespace UnityUtils.Extensions
{
public static class BinaryReaderExtensions {
    public static SerializableGuid Read(this BinaryReader reader) {
        return new SerializableGuid(reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32());
    }
}
}
