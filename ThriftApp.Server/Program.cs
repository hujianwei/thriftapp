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
            TServerSocket serverTransport = new TServerSocket(7912, 0, false);
            IAgent.Processor processor = new IAgent.Processor(new AgentImpl());
            //TServer server1 = new TSimpleServer(processor, serverTransport);
            TServer server = new TThreadPoolServer(processor, serverTransport, new TTransportFactory(), factory);
            


            Console.WriteLine("Starting server on port 7912 ...");
            server.Serve();
        }


    }

    public class AgentImpl : IAgent.Iface
    {
        public AgentImpl()
        {

        }
        static IList<AppAgent> result = new List<AppAgent>();
        static readonly object objAsync = new object();
        public  List<AppAgent> getAll()
        {
             List<AppAgent> list = new List<AppAgent>();
            if(result == null|| result.Count>1000)
                list = new List<AppAgent>();
            else
            {
                for(int i=0;i<1000;i++)
                {
                    AppAgent agent = new AppAgent();
                    agent.AppCode = DateTime.Now.Ticks.ToString()+"_"+i.ToString();
                    agent.Name = agent.AppCode.GetHashCode().ToString();                    
                    list.Add(agent);
                }
            }
            lock(objAsync)
            {
                result.Clear();
                result = result.Concat(list).ToList();
            }
            return  list;
        }

        public AppAgent getByCode(string code)
        {
            return result.Where(c => c.AppCode == code).FirstOrDefault();

        }

    }

}
