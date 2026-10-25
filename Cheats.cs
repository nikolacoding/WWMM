using System.Diagnostics;

namespace WWMM {
    public class Cheats {
        private MemoryManager memoryManager = new MemoryManager();

        private IntPtr godModeAddress = IntPtr.Zero;
        public bool isGodModeActive = false;
        public bool EnableGodMode(bool enable)
        {
            Process[] processes = Process.GetProcessesByName("POP2");
            if (processes.Length == 0){
                MessageBox.Show("The game (process) 'POP2.exe' doesn't seem to be running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Process gameProcess = processes[0];
            IntPtr processHandle = NativeSetup.OpenProcess(NativeSetup.PROCESS_ALL_ACCESS, false, gameProcess.Id);

            if (processHandle == IntPtr.Zero){
                MessageBox.Show("Run this as administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try {
                if (godModeAddress == IntPtr.Zero) {
                    godModeAddress = memoryManager.hpFindAobAddress(processHandle, gameProcess);
                }

                if (godModeAddress == IntPtr.Zero) {
                    MessageBox.Show("Unable to locate the required AOB pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                byte[] bytesToWrite = enable ? memoryManager.nopBytes : memoryManager.hpOriginalBytesFound;
                bool success = NativeSetup.WriteProcessMemory(processHandle, godModeAddress, bytesToWrite, bytesToWrite.Length, out _);

                if (success) isGodModeActive = enable;
                return success;
            }
            finally {
                NativeSetup.CloseHandle(processHandle);
            }
        }

        private IntPtr infiniteSandAddress = IntPtr.Zero;
        public bool isInfiniteSandActive = false;
        public bool EnableInfiniteSand(bool enable) {
            Process[] processes = Process.GetProcessesByName("POP2");
            if (processes.Length == 0)
            {
                MessageBox.Show("The game (process) 'POP2.exe' doesn't seem to be running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Process gameProcess = processes[0];
            IntPtr processHandle = NativeSetup.OpenProcess(NativeSetup.PROCESS_ALL_ACCESS, false, gameProcess.Id);

            if (processHandle == IntPtr.Zero)
            {
                MessageBox.Show("Run this as administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                if (infiniteSandAddress == IntPtr.Zero)
                {
                    infiniteSandAddress = memoryManager.sandFindAobAddress(processHandle, gameProcess);
                }

                if (infiniteSandAddress == IntPtr.Zero)
                {
                    MessageBox.Show("Unable to locate the required AOB pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                byte[] bytesToWrite;
                if (enable)
                {
                    bytesToWrite = new byte[memoryManager.sandOriginalBytesFound.Length];
                    for (int i = 0; i < bytesToWrite.Length; i++)
                    {
                        bytesToWrite[i] = 0x90;
                    }
                }
                else
                {
                    bytesToWrite = memoryManager.sandOriginalBytesFound;
                }

                bool success = NativeSetup.WriteProcessMemory(processHandle, infiniteSandAddress, bytesToWrite, bytesToWrite.Length, out _);

                if (success)
                {
                    isInfiniteSandActive = enable;
                }

                return success;
            }
            finally
            {
                NativeSetup.CloseHandle(processHandle);
            }
        }
    }
}
