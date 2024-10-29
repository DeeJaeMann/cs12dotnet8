using Microsoft.Win32.SafeHandles; // For SafeFileHandle
using System.Text; // For Encoding

using SafeFileHandle handle = File.OpenHandle(path: "coffee.txt",
    mode: FileMode.OpenOrCreate,
    access: FileAccess.ReadWrite);

// Write string encoded as byte array
// Store in read-only memory buffer to file
string message = "Cafe $4.39";
ReadOnlyMemory<byte> buffer = new(Encoding.UTF8.GetBytes(message));
await RandomAccess.WriteAsync(handle, buffer, fileOffset: 0);

// Read from file, get length of file, allocate memory buffer for contents and read file
long length = RandomAccess.GetLength(handle);
Memory<byte> contentBytes = new(new byte[length]);
await RandomAccess.ReadAsync(handle, contentBytes, fileOffset: 0);
string content = Encoding.UTF8.GetString(contentBytes.ToArray());
WriteLine($"Content of file: {content}");