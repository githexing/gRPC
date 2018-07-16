using Grpc.Core;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
//using UWebCore.Grpc;

namespace GrpcClient
{
    class Tools
    { 
        /// <summary>
        /// DateTime转换成时间戳
        /// </summary>
        /// <param name="time">DateTime</param>
        /// <returns></returns>
        public static long ToUnixTime()
        {
            DateTimeOffset dto = new DateTimeOffset(DateTime.Now);
            return dto.ToUnixTimeSeconds();
        }
        public static string ToSHA1(string str)
        {
            byte[] cleanBytes = Encoding.UTF8.GetBytes(str);
            byte[] hashedBytes = SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {

            const string Host = "dopengrpc.ujuz.cn"; const int Port = 16881;
            var ssl = new SslCredentials(File.ReadAllText(@"ssl/DigiCert_Global_Root_CA.pem"));
            Channel channel = new Channel($"{Host}:{Port}", ssl);


            //Channel channel = new Channel("dopengrpc.ujuz.cn:16881", ChannelCredentials.Insecure); 
            //var client = new GStationedAgent.GStationedAgentClient(channel);
            //var client_ = new GStationedAgent.GStationedAgentClient(channel);
            //var client_ = new GQueryParamsAgent.(channel);

            Metadata header = new Metadata();
            header.Add("citycode", "500000");
            header.Add("device", "php");
            header.Add("time", Tools.ToUnixTime().ToString());

            string tmp = string.Empty;
            foreach (var item in header)
            {
                tmp += item.Key + "=" + item.Value + "&";
            }
            string sign = Tools.ToSHA1(tmp + "[C@Ha!Rt#(YJkj)erP?]");
            //Console.WriteLine(tmp);
            //Console.WriteLine(Tools.CheckFrom(tmp, sign) + " " + sign);
            //Console.WriteLine(Tools.ToSHA1("123789"));//c75c6abebd904a02e62cfe65e0a82dd55414a217
            header.Add("sign", sign);

            try
            {
                //var replynAgent = client_.agentlist(new GQueryParamsAgent { Index = 1, Size = 10, HouseType = 3, HouseId = 1531436571818, CityCode = "520100" }, header);
                //for (int i = 0; i < replynAgent.Data.Count; i++)
                //{
                //    GResultStationedAgent agent = replynAgent.Data[i].Unpack<GResultStationedAgent>();
                //    Console.WriteLine($"来自 {Host}:{Port} :" + replynAgent.Code + " " + agent.Name + " " + agent.Phone + " " + agent.Company);
                //    Thread.Sleep(200);
                //}
                //Console.WriteLine($"来自 {Host}:{Port} :" + replynAgent.Code + " " + replynAgent.Message);
                //Console.WriteLine($"来自 {Host}:{Port} :" + replynAgent.ToJson());

                //var Agent = client_.getList(new GQueryChannelPushLogGetList { ChannelName = "安居客", PortName = "端口名称", PushStatus = "0", HouseType="1" }, header);
                //for (int i = 0; i < Agent.Data.Count; i++)
                //{

                //    GResultChannelPushLog agent = Agent.Data[i].Unpack<GResultChannelPushLog>();
                //    Console.WriteLine($"来自 {Host}:{Port} :" + Agent.Code + " " + agent.AgentId );
                //    Thread.Sleep(200);
                //}

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            channel.ShutdownAsync().Wait();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 任意键退出...");
            Console.ReadKey();
            //channel.ShutdownAsync().Wait();
            //Console.WriteLine("任意键退出...");
            //Console.ReadKey();
        }
    }
}
