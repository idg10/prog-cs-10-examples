using Microsoft.Win32.SafeHandles;

using System.Buffers.Binary;

using SafeFileHandle fh = File.OpenHandle(
    "RandomFileAccess.exe", options: FileOptions.Asynchronous);

static void ReadAll(SafeFileHandle fh, Span<byte> buffer, long offset)
{
    int soFar = 0;
    do
    {
        int read = RandomAccess.Read(fh, buffer[soFar..], offset + soFar);
        if (read == 0)
        {
            throw new InvalidOperationException("Reached end of file before filling buffer");
        }
        soFar += read;
    } while (soFar < buffer.Length);
}

var stubSignature = new byte[2];
ReadAll(fh, stubSignature, 0);
if (stubSignature[0] != (byte)'M' || stubSignature[1] != (byte)'Z')
{
    Console.WriteLine("No 'MZ' at start of file - not an EXE file");
}

var stubPeOffset = new byte[4];
ReadAll(fh, stubPeOffset, 0x3c);
int peHeaderOffset = BinaryPrimitives.ReadInt32LittleEndian(stubPeOffset);

var signatureAndHeader = new byte[24];
ReadAll(fh, signatureAndHeader, peHeaderOffset);
if (signatureAndHeader[0] != (byte)'P' ||
    signatureAndHeader[1] != (byte)'E' ||
    signatureAndHeader[2] != 0 ||
    signatureAndHeader[3] != 0)
{
    Console.WriteLine("No 'MZ' at start of file - not an EXE file");
}
