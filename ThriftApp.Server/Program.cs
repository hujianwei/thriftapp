using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Thrift;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;
using Thrift.Collections;
using ThriftApp.Lib;

namespace ThriftApp.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TBinaryProtocol.Factory factory = new TBinaryProtocol.Factory();
            TServerSocket serverTransport = new TServerSocket(7911, 0, false);
            IAgent.Processor processor = new IAgent.Processor(new AgentImpl());
            //TServer server1 = new TSimpleServer(processor, serverTransport);
            TServer server = new TThreadPoolServer(processor, serverTransport, new TTransportFactory(), factory);
            


            Console.WriteLine("Starting server on port 7911 ...");
            server.Serve();
        }


    }

    public class AgentImpl : IAgent.Iface
    {
        public AgentImpl()
        {
            AppAgent agent = new AppAgent();
            agent.AppCode = "1234";
            agent.Name = "测试";
            list.Add(agent);
            agent = new AppAgent();
            agent.AppCode = "1235";
            agent.Name = "1111测试";
            list.Add(agent);
        }
        private List<AppAgent> list = new List<AppAgent>();
        public List<AppAgent> getAll()
        {
            return list;
        }

        public AppAgent getByCode(string code)
        {
            return list.Where(c => c.AppCode == code).FirstOrDefault();

        }

    }

}
