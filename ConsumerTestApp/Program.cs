using org.apache.rocketmq.client.consumer;
using org.apache.rocketmq.client.producer;
using org.apache.rocketmq.common.consumer;
using org.apache.rocketmq.common.message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerTestApp
{
    class Program
    {
        private static DefaultMQProducer _producer;
        public static UTF8Encoding encoder;

        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                encoder = new UTF8Encoding();
                _producer = new DefaultMQProducer("prod900900");
                _producer.setNamesrvAddr("localhost:9876");
               // _producer.setVipChannelEnabled(false);
                _producer.start();
                bool printvalue = true;
                Console.WriteLine("Enter y to send message");

                while (printvalue)
                {
                    string line = Console.ReadLine();
                    if(line != "y")
                    {
                        printvalue = false;
                    }



                    p.sendMessage("topicF");


                }
                _producer.shutdown();

            }
            catch (Exception ex)
            {

            }
            Console.WriteLine("Enter to exit");

            Console.ReadLine();
        }

        public async Task sendMessage(string toipcName)
        {
            try
            {
                var message = Guid.NewGuid().ToString(); ;
                byte[] data = encoder.GetBytes(message);
                Message msg = new Message(toipcName, "*", "skey_02", data);
                MessageQueueSelector qs = new QueueSelector();
                string hh = "c091e548-b45a-49b4-b8ec-2cb5e2_global";
                SendResult result = _producer.send(msg);
                Console.WriteLine("Message send :" + result.getMsgId());

                //Message msg2 = new Message("251122b1-fec6-491d-969a-44a87138fc31", "dca90c36-da58-4fef-b3f8-2f7fec99d138", "skey_03", data);

                //for(int i = 0; i < 10; i++)
                //{
                //    SendResult result = _producer.send(msg, qs, 0);
                //    Console.WriteLine("Message send :" + result.getMsgId());
                //}

                //Parallel.For(0, 10000,
                //   index => {
                //       SendResult result = _producer.send(msg, qs, 0);
                //       SendResult result2 = _producer.send(msg2, qs, 0);
                //       Console.WriteLine("Message send :" + result.getMsgId());
                //   });
            }

            catch (Exception e)

            {
                e.GetBaseException();

            }

        }

        //static void Main(string[] args)
        //{
        //    try
        //    {
        //        string topic = "testTopic103";
        //        DefaultMQPushConsumer _consumer = new DefaultMQPushConsumer("cg_03");
        //        _consumer.setNamesrvAddr("localhost:9876");
        //        _consumer.setConsumeFromWhere(ConsumeFromWhere.CONSUME_FROM_LAST_OFFSET);
        //        _consumer.subscribe(topic, "EntityTag");

        //        RoutingListener listener = new RoutingListener();
        //        _consumer.registerMessageListener(listener);
        //        _consumer.start();

        //        //_consumer.createTopic("TBW102", topic, 4);

        //        Console.ReadKey();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
    }
}
