using java.util;
using org.apache.rocketmq.client.consumer.listener;
using org.apache.rocketmq.common.message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerTestApp
{
    class RoutingListener: MessageListenerOrderly
    {
        public RoutingListener()
        {
        }

        public ConsumeOrderlyStatus consumeMessage(List msgs, ConsumeOrderlyContext context)
        {
            try
            {
                var messageList = msgs.iterator();
                while (messageList.hasNext())
                {
                    MessageExt msg = (MessageExt)messageList.next();
                    byte[] msgbody = msg.getBody();
                    string body = Encoding.UTF8.GetString(msgbody);
                    Console.WriteLine("===> consumed msg :"+ body);
                }
            }
            catch (Exception ex)
            {
            }
            return ConsumeOrderlyStatus.SUCCESS;
        }
    }
}
