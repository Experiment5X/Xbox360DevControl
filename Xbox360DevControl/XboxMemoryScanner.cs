using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace XboxCheatEngine
{
    public class XboxMemoryScanner
    {
        #region Private Variables

        CommittedMemoryBlock? memoryBlock;
        XboxDevConsole console;

        #endregion

        public XboxMemoryScanner(XboxDevConsole console, CommittedMemoryBlock? memoryBlock = null)
        {
            this.console = console;
            this.memoryBlock = memoryBlock;
        }

        public IEnumerable<uint> FindValue(ulong value, BitWidth bitWidth)
        {
            if (memoryBlock == null)
            {
                foreach (CommittedMemoryBlock block in console.CommittedMemory)
                    foreach (uint addr in FindValue(block, value, bitWidth))
                        yield return addr;
            }
            else
            {
                foreach (uint addr in FindValue((CommittedMemoryBlock)memoryBlock, value, bitWidth))
                    yield return addr;
            }
        }

        private IEnumerable<uint> FindValue(CommittedMemoryBlock memBlock, ulong value, BitWidth bitWidth)
        {
            byte[] buffer = new byte[0x10000];
            uint bytesLeft = memBlock.Size;
            uint pos = memBlock.Base;

            while (bytesLeft != 0)
            {
                uint bytesToRead = (bytesLeft > 0x10000) ? 0x10000 : bytesLeft;
                console.GetMemory(pos, bytesToRead, buffer);

                // search for the value inside the buffer recieved from the console
                for (int i = 0; i < bytesToRead / (int)bitWidth; i++)
                {
                    // deterimine the offset into the buffer for the next value
                    int offset = i * (int)bitWidth;

                    // get the correct value at the current position
                    ulong curValue = 0;
                    switch (bitWidth)
                    {
                        case BitWidth.Byte8:
                            curValue = buffer[offset];
                            break;
                        case BitWidth.Word16:
                            curValue = BitConverterBigEndian.ToUInt16(buffer, offset);
                            break;
                        case BitWidth.Dword32:
                            curValue = BitConverterBigEndian.ToUInt32(buffer, offset);
                            break;
                        case BitWidth.Qword64:
                            curValue = BitConverterBigEndian.ToUInt64(buffer, offset);
                            break;
                    }

                    // if it matches, then return address it was found at
                    if (curValue == value)
                        yield return pos + (uint)offset;
                }

                // advance to the next value in the buffer
                pos += bytesToRead;
                bytesLeft -= bytesToRead;
            }
        }
    }

    public enum BitWidth : byte
    {
        Byte8 = 1,
        Word16 = 2,
        Dword32 = 4,
        Qword64 = 8,
        Any = 0xFF
    }

    class BitConverterBigEndian
    {
        public static ushort ToUInt16(byte[] buffer, int startIndex)
        {
            ushort toReturn = 0;
            for (int i = 0; i < 2; i++)
                toReturn |= (ushort)((ushort)buffer[startIndex + i] << ((1 - i) * 8));
            return toReturn;
        }

        public static uint ToUInt32(byte[] buffer, int startIndex)
        {
            uint toReturn = 0;
            for (int i = 0; i < 4; i++)
                toReturn |= (uint)((uint)buffer[startIndex + i] << ((3 - i) * 8));
            return toReturn;
        }

        public static ulong ToUInt64(byte[] buffer, int startIndex)
        {
            ulong toReturn = 0;
            for (int i = 0; i < 8; i++)
                toReturn |= (ulong)((ulong)buffer[startIndex + i] << ((7 - i) * 8));
            return toReturn;
        }
    }
}
