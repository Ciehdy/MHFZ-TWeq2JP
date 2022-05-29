class Program
{

    static int soStringHead = 0x64; static int soStringBody = 0x68; static int soStringArm = 0x6C; static int soStringWaist = 0x70; static int soStringLeg = 0x74;
    static int eoStringHead = 0x60; static int eoStringBody = 0x64; static int eoStringArm = 0x68; static int eoStringWaist = 0x6C; static int eoStringLeg = 0x70;
    static int soStringRanged = 0x84; static int soStringMelee = 0x88;

    static int soHead = 0x50; static int soBody = 0x54; static int soArm = 0x58; static int soWaist = 0x5C; static int soLeg = 0x60;
    static int eoHead = 0xE8; static int eoBody = 0x50; static int eoArm = 0x54; static int eoWaist = 0x58; static int eoLeg = 0x5C;

    static int soRanged = 0x80; static int soMelee = 0x7C;
    static int eoRanged = 0x7C; static int eoMelee = 0x90;
    static void Main(string[] args)
    {
        byte[] twbin = File.ReadAllBytes(".\\mhfdat-tw.bin");

        int[] ofHead = { 9675864, 9676368, 9676872, 9677376, 9673992, 9674496, 9673416, 9673488, 9673272, 9673344, 9673200, 9673128 };
        int[] ofBody = { 8587792, 8588296, 8588800, 8589304, 8586568, 8587072, 8585992, 8586064, 8585848, 8585920, 8585704, 8585776 };
        int[] ofArm = { 7500368, 7500872, 7501376, 7501880, 7499144, 7499648, 7498568, 7498640, 7498424, 7498496, 7498280, 7498352 };
        int[] ofWaist = { 6412944, 6413448, 6413952, 6414456, 6411720, 6412224, 6411144, 6411216, 6411000, 6411072, 6410856, 6410928 };
        int[] ofLeg = { 5325520, 5326024, 5326528, 5327032, 5324296, 5324800, 5323720, 5323792, 5323576, 5323648, 5323432, 5323504 };

        File.Copy(".\\mhfdat.bin", ".\\output\\mhfdat.bin", true);
        MemoryStream msInput = new MemoryStream(File.ReadAllBytes(".\\mhfdat.bin"));
        BinaryReader brInput = new BinaryReader(msInput);
        BinaryWriter brOutput = new BinaryWriter(File.Open(".\\output\\mhfdat.bin", FileMode.Open));

        int sOffset = 0;

        for (int i = 0; i < 10; i++)
        {
            brInput.BaseStream.Seek(soHead, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x59E + i * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("頭 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofHead[i]).Take(72).ToArray());


            brInput.BaseStream.Seek(soBody, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x4B1 + i * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("胴 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofBody[i]).Take(72).ToArray());

            brInput.BaseStream.Seek(soArm, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x4A9 + i * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("腕 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofArm[i]).Take(72).ToArray());

            brInput.BaseStream.Seek(soWaist, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x506 + i * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("腰 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofWaist[i]).Take(72).ToArray());

            brInput.BaseStream.Seek(soLeg, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x4AB + i * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("脚 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofLeg[i]).Take(72).ToArray());
        }
        for (int i = 10; i < 12; i++)
        {
            brInput.BaseStream.Seek(soHead, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x2FEE + (i - 10) * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("頭 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofHead[i]).Take(72).ToArray());


            brInput.BaseStream.Seek(soBody, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x906 + (i - 10) * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("胴 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofBody[i]).Take(72).ToArray());

            brInput.BaseStream.Seek(soArm, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x8F9 + (i - 10) * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("腕 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofArm[i]).Take(72).ToArray());

            brInput.BaseStream.Seek(soWaist, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x998 + (i - 10) * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("腰 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofWaist[i]).Take(72).ToArray());

            brInput.BaseStream.Seek(soLeg, SeekOrigin.Begin); sOffset = brInput.ReadInt32() + (0x8FC + (i - 10) * 3) * 72;
            brOutput.BaseStream.Seek(sOffset, SeekOrigin.Begin);
            Console.WriteLine("脚 Offset: " + brOutput.BaseStream.Position);
            brOutput.BaseStream.Write(twbin.Skip(ofLeg[i]).Take(72).ToArray());
        }
        brInput.Close();
        brOutput.Flush();
        brOutput.Close();
    }
}
