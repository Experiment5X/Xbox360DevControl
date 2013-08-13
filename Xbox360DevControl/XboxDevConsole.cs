using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XDevkit;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace XboxCheatEngine
{
    public class XboxDevConsole
    {
        #region Private Variables

        XboxConsole                     console;
        XboxManagerClass                xboxManager = new XboxManagerClass();
        uint                            consoleConnection;
        List<CommittedMemoryBlock>      committedMemory = new List<CommittedMemoryBlock>();
        List<Module>                    modules = new List<Module>();

        #endregion

        #region Properties

        public      bool        Connected           { get; private set; }
        public      string      IPAddress           { get; private set; }
        public      string      Type                { get; private set; }
        public      string      CurrentTitle        { get; private set; }
        public      string      Features            { get; private set; }
        public      string      Name                { get; private set; }
        public      bool        HDDEnabled          { get; private set; }
        public      string      Platform            { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      Version     BaseKernelVersion   { get; private set; }
        public      Version     KernelVersion       { get; private set; }
        public      Version     XDKVersion          { get; private set; }
        /*public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }
        public      string      Motherboard         { get; private set; }*/


        public List<CommittedMemoryBlock> CommittedMemory
        {
            get
            {
                return committedMemory;
            }
        }

        public List<Module> Modules
        {
            get
            {
                return modules;
            }
        }

        #endregion

        public XboxDevConsole(string name)
        {
            console = xboxManager.OpenConsole(name);

            // create a connection to the console so we can communicate with it
            Connect();

            // the features are flags, so we need to check for all of them
            Features = "";
            foreach (XboxConsoleFeatures feature in Enum.GetValues(typeof(XboxConsoleFeatures)))
                if (((uint)console.ConsoleFeatures & (uint)feature) != 0)
                    Features += feature.ToString() + "|";
            Features = (Features.Length != 0) ? Features.Substring(0, Features.Length - 1) : "None";

            Type = console.ConsoleType.ToString();
            Name = console.Name;
            CurrentTitle = console.RunningProcessInfo.ProgramName;

            // format the IP address, it's in the wrong endian so the .Net classes parse it backwards
            uint ipAddress = console.IPAddress;
            IPAddress = "";
            for (int i = 24; i >= 0; i -= 8)
                IPAddress += ((ipAddress >> i) & 0xFF).ToString() + ".";
            IPAddress = IPAddress.Substring(0, IPAddress.Length - 1);

            // organize a list of all of the heap memory allocated
            string response = SendTextCommand("walkmem");
            foreach (string resp in RecieveStrings())
                committedMemory.Add(new CommittedMemoryBlock(resp));


            response = SendTextCommand("systeminfo");

            console.ReceiveSocketLine(consoleConnection, out response);
            HDDEnabled = (response.Replace("HDD=", "") == "Enabled");

            // this contains the type, that's already been parsed
            console.ReceiveSocketLine(consoleConnection, out response);

            console.ReceiveSocketLine(consoleConnection, out response);
            string[] settings = response.Split(new char[] { ' ' });
            Platform = settings[0].Replace("Platform=", "");
            Motherboard = settings[1].Replace("System=", "");

            console.ReceiveSocketLine(consoleConnection, out response);
            settings = response.Split(new char[] { ' ' });
            BaseKernelVersion = new Version(settings[0].Replace("BaseKrnl=", ""));
            KernelVersion = new Version(settings[1].Replace("Krnl=", ""));
            XDKVersion = new Version(settings[2].Replace("XDK=", ""));

            // retrieve the . at the end
            console.ReceiveSocketLine(consoleConnection, out response);


            // organize a list of all of the modules loaded in memory
            response = SendTextCommand("modules");
            foreach (string resp in RecieveStrings())
                modules.Add(new Module(resp));
        }

        public void Connect()
        {
            if (Connected)
                throw new Exception("XboxDevConsole: Already connected to console.\n");

            try
            {
                consoleConnection = console.OpenConnection(null);
                Connected = true;
            }
            catch (Exception ex)
            {
                throw new Exception("XboxDevConsole: Console not found.\n\n" + ex.Message);
            }
        }

        public void Disconnect()
        {
            try
            {
                SendTextCommand("bye");
                console.CloseConnection(consoleConnection);
                Connected = false;
            }
            catch (Exception ex)
            {
                throw new Exception("XboxDevConsole: Could not disconnect from console.\n\n" + ex.Message);
            }
        }

        public string SendTextCommand(string command)
        {
            try
            {
                string response;
                console.SendTextCommand(consoleConnection, command, out response);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("XboxDevConsole: Command error. Either the connection to the console was lost, or the command doesn't exist.\n");
            }
        }

        public IEnumerable<string> RecieveStrings()
        {
            string response;
            while (true)
            {
                // read the next string from the console
                console.ReceiveSocketLine(consoleConnection, out response);

                // this response signifies that there's no more data
                if (response == ".")
                    break;

                yield return response;
            }
        }

        public string RecieveString()
        {
            string response;
            console.ReceiveSocketLine(consoleConnection, out response);
            return response;
        }

        public byte[] RecieveBinaryData(uint length)
        {
            byte[] toReturn = new byte[length];
            uint bytesReceived;
            console.ReceiveBinary(consoleConnection, toReturn, length, out bytesReceived);

            if (bytesReceived != length)
                throw new Exception("XboxDevConsole: Couldn't recieve all binary data requested.\n");

            return toReturn;
        }

        public void GetMemory(uint address, uint length, byte[] buffer)
        {
            uint bytesRead;

            console.DebugTarget.GetMemory(address, length, buffer, out bytesRead);

            if (bytesRead != length)
                throw new Exception("XboxDevConsole: Couldn't read all bytes requested.\n");
        }

        public void Screenshot()
        {
            /*SendTextCommand("screenshot");
            string response = RecieveString();

            uint imageSize = 0x7E9000;//Convert.ToUInt32(Regex.Matches(response, @"framebuffersize=0x(\w+)")[0].Groups[1].ToString(), 16);
            int width = Convert.ToInt32(Regex.Matches(response, @"width=0x(\w+)")[0].Groups[1].ToString(), 16);
            int height = Convert.ToInt32(Regex.Matches(response, @"height=0x(\w+)")[0].Groups[1].ToString(), 16);

            BinaryWriter bmpWriter = new BinaryWriter(File.Open("C:\\Users\\Adam\\Desktop\\sickimage.bmp", FileMode.CreateNew));
            bmpWriter.Write((short)0x424D);
            bmpWriter.Write(imageSize);
            bmpWriter.Write((int)0);
            bmpWriter.Write((int)14);
            bmpWriter.Write(RecieveBinaryData(imageSize), 0, (int)imageSize);
            bmpWriter.Close();*/

            console.ScreenShot("C:\\Users\\Adam\\Desktop\\balls.bmp");
        }
    }

    public struct CommittedMemoryBlock
    {
        public      uint        Base            { get; private set; }
        public      uint        Size            { get; private set; }
        public      string      Protection      { get; private set; }

        public CommittedMemoryBlock(string memBlock) :
            this()
        {
            // parse the response from the xbox
            MatchCollection matches = Regex.Matches(memBlock, @"\w+=0x(.{8})");

            Base =          Convert.ToUInt32(matches[0].Groups[1].ToString(), 16);
            Size =          Convert.ToUInt32(matches[1].Groups[1].ToString(), 16);
            uint prot =     Convert.ToUInt32(matches[2].Groups[1].ToString(), 16);

            Protection = "";
            foreach (XboxMemoryRegionFlags flag in Enum.GetValues(typeof(XboxMemoryRegionFlags)))
                if ((prot & (uint)flag) == (uint)flag)
                    Protection += flag.ToString() + "|";
            Protection = (Protection == "") ? "None" : Protection.Substring(0, Protection.Length - 1);
        }
    }

    public struct Module
    {
        public      string      Name            { get; private set; }
        public      uint        BaseAddress     { get; private set; }
        public      uint        Size            { get; private set; }
        public      uint        Check           { get; private set; }
        public      DateTime    Timestamp       { get; private set; }
        public      uint        DataAddress     { get; private set; }
        public      uint        DataSize        { get; private set; }
        public      uint        Thread          { get; private set; }
        public      uint        OSize           { get; private set; }

        public Module(string moduleInfo) :
            this()
        {
            // parse the response from the xbox
            MatchCollection matches = Regex.Matches(moduleInfo, @"\w=(\S+)");

            Name = matches[0].Groups[1].ToString().Replace("\"", "");

            matches =           Regex.Matches(moduleInfo, @"\w=0x(\S+)");
            BaseAddress =       Convert.ToUInt32(matches[0].Groups[1].ToString(), 16);
            Size =              Convert.ToUInt32(matches[1].Groups[1].ToString(), 16);
            Check =             Convert.ToUInt32(matches[2].Groups[1].ToString(), 16);
            Timestamp =         new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds((double)Convert.ToUInt32(matches[3].Groups[1].ToString(), 16));
            DataAddress =       Convert.ToUInt32(matches[4].Groups[1].ToString(), 16);
            DataSize =          Convert.ToUInt32(matches[5].Groups[1].ToString(), 16);
            Thread =            Convert.ToUInt32(matches[6].Groups[1].ToString(), 16);
            OSize =             Convert.ToUInt32(matches[7].Groups[1].ToString(), 16);
        }
    }
}
