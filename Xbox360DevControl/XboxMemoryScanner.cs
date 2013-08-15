using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace XboxCheatEngine
{
    public class XboxMemoryScanner
    {
        #region Private Variables

        List<CommittedMemoryBlock> memoryBlocks;
        XboxDevConsole console;
        List<uint> prevScanResults;
        BitWidth prevBitWidth;

        #endregion

        public XboxMemoryScanner(XboxDevConsole console, List<CommittedMemoryBlock> memoryBlocks = null)
        {
            this.console = console;
            this.memoryBlocks = memoryBlocks;
        }

        public async Task<List<uint>> FindValue(ulong value, BitWidth bitWidth)
        {
            prevBitWidth = bitWidth;
            prevScanResults = new List<uint>();

            // if the caller didn't specify which memory blocks to search, we'll just search all of them
            if (memoryBlocks == null)
            {
                foreach (CommittedMemoryBlock block in console.CommittedMemory)
                    prevScanResults.AddRange(await FindValue(block, value, bitWidth));
                return prevScanResults;
            }
            else
            {
                foreach (CommittedMemoryBlock block in memoryBlocks)
                    prevScanResults.AddRange(await FindValue(block, value, bitWidth));
                return prevScanResults;
            }
        }

        public async Task<List<uint>> NarrowResults(ulong value)
        {
            byte[] buffer = new byte[(int)prevBitWidth];
            List<uint> newResults = new List<uint>();

            int i = 0;
            foreach (uint address in prevScanResults)
            {
                console.GetMemory(address, (uint)prevBitWidth, buffer);
                if (GetValue(buffer, 0, prevBitWidth) == value)
                    newResults.Add(address);

                if (i++ % 1000 == 0)
                    await Task.Delay(10);
            }

            prevScanResults = newResults;
            return newResults;
        }

        private async Task<List<uint>> FindValue(CommittedMemoryBlock memBlock, ulong value, BitWidth bitWidth)
        {
            List<uint> toReturn = new List<uint>();
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
                    ulong curValue = GetValue(buffer, offset, bitWidth);

                    // if it matches, then return address it was found at
                    if (curValue == value)
                        toReturn.Add(pos + (uint)offset);

                    if (i % 250 == 0)
                        await Task.Delay(10);
                }

                await Task.Delay(20);

                // advance to the next value in the buffer
                pos += bytesToRead;
                bytesLeft -= bytesToRead;

            }

            return toReturn;
        }

        private ulong GetValue(byte[] buffer, int offset, BitWidth bitWidth)
        {
            switch (bitWidth)
            {
                case BitWidth.Byte8:
                     return buffer[offset];
                case BitWidth.Word16:
                     return BitConverterBigEndian.ToUInt16(buffer, offset);
                case BitWidth.Dword32:
                     return BitConverterBigEndian.ToUInt32(buffer, offset);
                case BitWidth.Qword64:
                     return BitConverterBigEndian.ToUInt64(buffer, offset);
            }

            return 0;
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
