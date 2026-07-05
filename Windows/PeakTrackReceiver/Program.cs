using System.Net;
using System.Net.Sockets;
using System.Text;

Console.WriteLine("==================================");
Console.WriteLine(" PeakTrack Receiver");
Console.WriteLine(" Waiting for phone...");
Console.WriteLine(" Port: 5005");
Console.WriteLine("==================================");

UdpClient udp = new UdpClient(5005);

while (true)
{
    IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);

    byte[] data = udp.Receive(ref endpoint);

    string message = Encoding.UTF8.GetString(data);

    Console.Clear();

    Console.WriteLine("PeakTrack Receiver");
    Console.WriteLine();
    Console.WriteLine($"Phone: {endpoint.Address}");
    Console.WriteLine();
    Console.WriteLine(message);
}