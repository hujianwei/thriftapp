using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ThriftApp.Lib;
using Thrift.Transport;
using Thrift.Protocol;

namespace ThriftApp.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TTransport transport = new TSocket("localhost", 7911);
                TProtocol protocol = new TBinaryProtocol(transport);
                IAgent.Client client = new IAgent.Client(protocol);

                transport.Open();
                Console.WriteLine("client开始....");
                var result = client.getAll();
                foreach(var item in result)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
            catch(Exception e)
            {
                System.IO.File.WriteAllText(@"E:\thrift\error1.txt", e.Message);
            }
            Console.ReadLine();
        }
    }
}
