using System.Diagnostics;

namespace WWMM
{
    public class MemoryManager
    {
        public readonly byte[] nopBytes = [0x90, 0x90, 0x90];

        public byte[] hpOriginalBytesFound = null;
        public byte[] sandOriginalBytesFound = null;

        private readonly byte[][] healthAobPatterns = [
            [0xD9, 0x5B, 0x00, 0xD9, 0x83], // standardna GOG/CD verzija
            [0xD9, 0x5F, 0x00, 0xD9, 0x87], // alt1
            [0xD9, 0x59, 0x00, 0xD9, 0x81], // alt2
            [0xD9, 0x9E, 0xFF, 0xFF, 0x00, 0x00] // stari no-CD patch
        ];

        private readonly byte[][] sandAobPatterns = [
            [0xFF, 0x8E, 0x80, 0x01, 0x00, 0x00],       // standardna GOG/CD verzija
            [0x83, 0x8E, 0x80, 0x01, 0x00, 0x00, 0x01], // alt1
            [0xFF, 0x8E, 0xFF, 0xFF, 0x00, 0x00]        // stari no-CD patch
        ];

        public IntPtr hpFindAobAddress(IntPtr processHandle, Process gameProcess)
        {
            ProcessModule mainModule = gameProcess.MainModule;
            IntPtr currentAddress = mainModule.BaseAddress;
            int totalSize = mainModule.ModuleMemorySize;

            int chunkSize = 4096 * 16; // 64 KB blokovi
            byte[] buffer = new byte[chunkSize];

            for (int offset = 0; offset < totalSize; offset += chunkSize)
            {
                IntPtr readAddress = IntPtr.Add(currentAddress, offset);
                int bytesToRead = Math.Min(chunkSize, totalSize - offset);

                if (NativeSetup.ReadProcessMemory(processHandle, readAddress, buffer, bytesToRead, out int bytesRead))
                {
                    foreach (byte[] pattern in healthAobPatterns)
                    {
                        for (int i = 0; i < bytesRead - pattern.Length; i++)
                        {
                            bool match = true;
                            for (int j = 0; j < pattern.Length; j++)
                            {
                                // 0xFF se tretira kao bilo koji bajt (wildcard)
                                if (pattern[j] != 0xFF && buffer[i + j] != pattern[j])
                                {
                                    match = false;
                                    break;
                                }
                            }

                            if (match)
                            {
                                // cuvanje prva 3 originalna bajta zarad kasnijeg gasenja cheata
                                hpOriginalBytesFound = new byte[3];
                                Array.Copy(buffer, i, hpOriginalBytesFound, 0, 3);

                                return IntPtr.Add(readAddress, i);
                            }
                        }
                    }
                }
            }

            return IntPtr.Zero;
        }

        public IntPtr sandFindAobAddress(IntPtr processHandle, Process gameProcess)
        {
            ProcessModule mainModule = gameProcess.MainModule;
            IntPtr currentAddress = mainModule.BaseAddress;
            int totalSize = mainModule.ModuleMemorySize;

            int chunkSize = 4096 * 16; // 64 KB po bloku
            byte[] buffer = new byte[chunkSize];

            for (int offset = 0; offset < totalSize; offset += chunkSize)
            {
                IntPtr readAddress = IntPtr.Add(currentAddress, offset);
                int bytesToRead = Math.Min(chunkSize, totalSize - offset);

                if (NativeSetup.ReadProcessMemory(processHandle, readAddress, buffer, bytesToRead, out int bytesRead))
                {
                    foreach (byte[] pattern in sandAobPatterns)
                    {
                        for (int i = 0; i < bytesRead - pattern.Length; i++)
                        {
                            bool match = true;
                            for (int j = 0; j < pattern.Length; j++)
                            {
                                if (pattern[j] != 0xFF && buffer[i + j] != pattern[j])
                                {
                                    match = false;
                                    break;
                                }
                            }

                            if (match)
                            {
                                // Sačuvaj tačnu dužinu i vrijednosti originalnih bajtova
                                sandOriginalBytesFound = new byte[pattern.Length];
                                Array.Copy(buffer, i, sandOriginalBytesFound, 0, pattern.Length);

                                return IntPtr.Add(readAddress, i);
                            }
                        }
                    }
                }
            }

            return IntPtr.Zero;
        }
    }
}
