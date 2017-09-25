using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ThriftApp.Lib;
using Thrift.Transport;
using Thrift.Protocol;
using System.Threading;

namespace ThriftApp.Client
{
    class Program
    {
        static string rootDir = AppDomain.CurrentDomain.BaseDirectory;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(new ThreadStart(ClientResponse));
                thread.Start();
            }
        }

        static void ClientResponse()
        {
            while (true)
            {
                try
                {
                    TTransport transport = new TSocket("192.168.1.55", 8888);
                    TProtocol protocol = new TBinaryProtocol(transport);
                    IAgent.Client client = new IAgent.Client(protocol);

                    transport.Open();
                    Console.WriteLine("client开始....");
                    var result = client.getAll();
                    foreach (var item in result)
                    {
                        Console.WriteLine(item.Name);
                    }
                   
                }
                catch (Exception e)
                {
                    System.IO.File.WriteAllText($"{rootDir}error1.txt", e.Message);
                }
                Thread.Sleep(10);
            }
            Console.ReadLine();
        }

    }



}
