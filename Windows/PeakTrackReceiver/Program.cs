using System.Net;
using System.Net.Sockets;
using System.Text;

Console.Title = "PeakTrack Receiver";

UdpClient udp = new UdpClient(5005);

bool mouseControl = false;

Console.WriteLine("====================================");
Console.WriteLine(" PeakTrack Receiver");
Console.WriteLine(" Waiting for phone...");
Console.WriteLine("====================================");
if (Console.KeyAvailable)
{
    var key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.F8)
    {
        mouseControl = !mouseControl;
    }
}

while (true)
{
    IPEndPoint endpoint = new(IPAddress.Any, 0);

    byte[] data = udp.Receive(ref endpoint);

    string message = Encoding.UTF8.GetString(data);

    Console.Clear();

    Console.WriteLine("========== PeakTrack ==========");
    Console.WriteLine();
    Console.WriteLine($"Connected Phone: {endpoint.Address}");
    Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Mouse Control: {(mouseControl ? "ON" : "OFF")}");

    string[] values = message.Split(',');

    if (values.Length == 3)
    {
        Console.WriteLine($"Yaw   : {values[0]}°");
        Console.WriteLine($"Pitch : {values[1]}°");
        Console.WriteLine($"Roll  : {values[2]}°");
    }
    else
    {
        Console.WriteLine("Received:");
        Console.WriteLine(message);
    }
}